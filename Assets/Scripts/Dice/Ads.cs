using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads : MonoBehaviour
{
    public GameObject swipeMotion;
    public GameObject[] ads;

    private const float IDLE_CHANGE_TIME = 10000f;
    private float idleCounter_t = 0f;
    private bool isChanging = false;

    private int visible_i = 0;

    void Update(){
        if(isChanging){
            return;
        }

        idleCounter_t += Time.deltaTime;
        if(idleCounter_t > IDLE_CHANGE_TIME){
            ChangeAd();
            idleCounter_t = 0;
        }
    }

    void OnMouseDown(){
        if(!isChanging){
            ChangeAd();
        }
    }

    public void ChangeAd(){
        isChanging = true;
        visible_i++;
        if(visible_i == ads.Length){
            visible_i = 0;
        }
        LeanTween.moveLocal(swipeMotion, new Vector3(
            swipeMotion.transform.localPosition.x + 2, 
            swipeMotion.transform.localPosition.y,
            swipeMotion.transform.localPosition.z
        ), 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(PrepareForNextChange);
    }

    public void PrepareForNextChange(){
        int adToMove = (visible_i - 1);
        if(adToMove < 0){
            adToMove = ads.Length - 1;
        }

        ads[adToMove].transform.localPosition = new Vector2(
            ads[adToMove].transform.localPosition.x - 2f * ads.Length,
            ads[adToMove].transform.localPosition.y
        );

        idleCounter_t = 0;
        isChanging = false;
    }
}
