using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject winTicket;
    public GameObject loseTicket;


    private float height;
    private float width;

    private RaffleGameManager manager;

    void Awake(){
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        manager = (RaffleGameManager)FindObjectOfType(typeof(RaffleGameManager));
    }

    public void Draw(){
        if(manager.gameRiggedCorrectly){
            winTicket.SetActive(true);
        }else{
            loseTicket.SetActive(true);
            StaticData.RunWithDelay(HumiliateLoss, 3.5f);
        }

        LeanTween.moveY(gameObject, 7f, 3f).setEase(LeanTweenType.easeInQuad);
        LeanTween.scale(gameObject, new Vector3(3, 3, 1), 3f).setEase(LeanTweenType.easeInQuad);
        LeanTween.alpha(gameObject, 0f, 0f);
        LeanTween.alpha(gameObject, 1f, 3f);
    }

    public void HumiliateLoss(){
        LeanTween.move(gameObject, new Vector3(0, -3.55f, 8), 1f).setEase(LeanTweenType.easeOutExpo);
        LeanTween.scale(gameObject, new Vector3(15, 15, 1), 1f).setEase(LeanTweenType.easeOutExpo);
    }
}
