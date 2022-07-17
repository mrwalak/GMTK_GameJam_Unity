using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelGameManager : MonoBehaviour
{
    public GameObject spinButton;
    public GameObject blackFade;
    public GameObject compMask;

    public WireToggle cheatCheck;

    public AudioManager audioManager;

    public CircleCollider2D[] screwColliders;

    public Color red;
    public Color green;
    
    public FlashColor winFlash;
    public FlashColor dieFlash;

    void Start()
    {
        LeanTween.alpha(blackFade.GetComponent<RectTransform>(), 0f, 1f);

        for(int i = 0; i < screwColliders.Length; i++){
            screwColliders[i].enabled = false;
        }

        audioManager.Play("Opening");
        StaticData.RunWithDelay(FadeOutCompMask, (StaticData.IGNORE_AUDIO ? 1f: 30f));
    }

    public void FadeOutCompMask(){
        LeanTween.alpha(compMask.GetComponent<RectTransform>(), 0f, 1f).setOnComplete(AllowForSpin);

        for(int i = 0; i < screwColliders.Length; i++){
            screwColliders[i].enabled = true;
        }
    }

    public void SpinClicked(){
        audioManager.Play("Spin");
        spinButton.SetActive(false);
    }

    public void AllowForSpin(){
        spinButton.SetActive(true);
    }

    public void SpinResults(){
        if(cheatCheck.isRigged){
            // Win!!!
            audioManager.Play("Win");
            StaticData.RunWithDelay(RevealWin, (StaticData.IGNORE_AUDIO ? 1f : 8f));
            StaticData.RunWithDelay(NextLevel, (StaticData.IGNORE_AUDIO ? 4f : 33f));
        }else{
            
            // Lose
            audioManager.Play("Death");
            StaticData.RunWithDelay(RevealLoss, (StaticData.IGNORE_AUDIO ? 1f : 4f));
            StaticData.RunWithDelay(RestartLevel, (StaticData.IGNORE_AUDIO ? 4f : 20f));
        }
    }

    public void RevealWin(){
        winFlash.color = red;
        winFlash.StartFlash();
    }

    public void RevealLoss(){
        dieFlash.color = red;
        dieFlash.StartFlash();
    }

    public void RestartLevel(){
        SceneManager.LoadScene("Wheel");
    }

    public void NextLevel(){
        SceneManager.LoadScene("Raffle");
    }

    public void PanelExposed(){
        audioManager.Play("Panel");
    }
}
