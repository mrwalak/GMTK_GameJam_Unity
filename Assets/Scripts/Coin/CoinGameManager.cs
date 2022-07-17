using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CoinGameManager : MonoBehaviour
{
    public bool turnedLightsOff = false;
    private int tweenToCancelDeath;

    private float height;
    private float width;
    private static float laneStart_x;
    private static float lane_dx;

    public const int NUM_COINS = 10;
    public const float PERCENT_PADDING = 0.1f;
    public CoinGameState gameState = CoinGameState.FirstFlip;

    public StageManager stageManager;
    public FlipButton flipButton;

    public GameObject blackFade;
    public AudioManager audioManager;

    public GameObject showSign;
    public GameObject light;

    public enum CoinGameState{
        FirstFlip = 0,
        SecondFlip = 1
    }

    // Start is called before the first frame update
    void Awake()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        laneStart_x = -width * (1f - (PERCENT_PADDING * 2f));
        lane_dx = (2f * width * (1f - 2f*PERCENT_PADDING)) / ((float) NUM_COINS - 1);
    }

    void Start(){
        LeanTween.alpha(blackFade.GetComponent<RectTransform>(), 0f, 1f);
        audioManager.Play("Opening");
        StaticData.RunWithDelay(CoinIn, (StaticData.IGNORE_AUDIO ? 1f :54f));
    }

    public void CoinIn(){
        stageManager.gameObject.SetActive(true);
        audioManager.Play("Opening_2");
        StaticData.RunWithDelay(SignIn, (StaticData.IGNORE_AUDIO ? 1f :22f));
    }

    public void SignIn(){
        showSign.SetActive(true);
        light.SetActive(true);
        
        audioManager.Play("Opening_3");
        StaticData.RunWithDelay(FlipOptionIn, (StaticData.IGNORE_AUDIO ? 1f :37f));
    }

    public void FlipOptionIn(){
        flipButton.gameObject.SetActive(true);
    }

    public static float GetLaneXCoord(int i){
        return laneStart_x + i*lane_dx;
    }

    public void FlipClicked(){
        if(gameState == CoinGameState.FirstFlip){
            stageManager.FlipCoins(false);
            flipButton.Hide();

        }else if(gameState == CoinGameState.SecondFlip){
            stageManager.FlipCoins(true);
            flipButton.Hide();
        }
    }

    public void OnFlipComplete(){
        if(gameState == CoinGameState.FirstFlip){
            Debug.Log("Finished first flip");
            audioManager.Play("10_Coin_Opening");
            StaticData.RunWithDelay(TenCoinsIn, (StaticData.IGNORE_AUDIO ? 1f :7f));
            gameState = CoinGameState.SecondFlip;
        }else if(gameState == CoinGameState.SecondFlip){
            Debug.Log("Finished second flip");
            audioManager.Play("Coin_Loss");
            tweenToCancelDeath = StaticData.RunWithDelay(DieIfNoLightsOut, (StaticData.IGNORE_AUDIO ? 77f :77f));
            stageManager.ShowLightSwitch();
        }
        
    }

    public void DieIfNoLightsOut(){
        SceneManager.LoadScene("Coin");
    }

    public void TenCoinsIn(){
        stageManager.ToTenCoinFlip();
        StaticData.RunWithDelay(AllowTenCoinsFlip, (StaticData.IGNORE_AUDIO ? 1f :22f));
    }

    public void AllowTenCoinsFlip(){
        flipButton.Show();
    }

    public void RunWithDelay(Action withDelay, float delay){
        LeanTween.value(gameObject, 0f, 1f, delay).setOnComplete(withDelay);
    }

    public void CancelDeath(){
        Debug.Log("Canceling death");
        LeanTween.cancel(tweenToCancelDeath);
    }

    public void BeginCheat(){
        audioManager.Play("Lights_Off");
    }

    public void DoneCheating(){
        Debug.Log("Done cheating");
        audioManager.Play("Ending");
        StaticData.RunWithDelay(ToNextScene, (StaticData.IGNORE_AUDIO ? 1f :45f));
    }

    public void ToNextScene(){
        SceneManager.LoadScene("Wheel");
    }

}
