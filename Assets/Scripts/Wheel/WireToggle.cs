using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireToggle : MonoBehaviour
{
    public bool canCheat = false;

    public Color originalColor;
    public Color cheatColor;

    public bool isRigged = false;
    public SpriteRenderer spriteRenderer;

    public WireToggle link;

    public void OnClick(){
        if(!canCheat){
            return;
        }

        isRigged = !isRigged;
        link.LinkedClick();
        UpdateAppearance();
    }

    public void LinkedClick(){
        isRigged = !isRigged;
        UpdateAppearance();
    }

    public void UpdateAppearance(){
        if(isRigged){
            spriteRenderer.color = cheatColor;
        }else{
            spriteRenderer.color = originalColor;
        }
    }
}
