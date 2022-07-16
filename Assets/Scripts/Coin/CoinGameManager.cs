using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinGameManager : MonoBehaviour
{
    private float height;
    private float width;
    private static float laneStart_x;
    private static float lane_dx;

    public const int NUM_COINS = 10;
    public const float PERCENT_PADDING = 0.1f;
    public CoinGameState gameState = CoinGameState.FirstFlip;

    public StageManager stageManager;
    public FlipButton flipButton;

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
            RunWithDelay(stageManager.ToTenCoinFlip, 3f);
            RunWithDelay(flipButton.Show, 6f);
            gameState = CoinGameState.SecondFlip;
        }else if(gameState == CoinGameState.SecondFlip){
            Debug.Log("Finished second flip");
            stageManager.ShowLightSwitch();
        }
        
    }

    public void RunWithDelay(Action withDelay, float delay){
        LeanTween.value(gameObject, 0f, 1f, delay).setOnComplete(withDelay);
    }

}
