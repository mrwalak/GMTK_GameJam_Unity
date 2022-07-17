using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public bool isRigged = false;

    public Sprite gumRigged;
    public Sprite pipRigged;

    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GumRig(){
        isRigged = true;
        spriteRenderer.sprite = gumRigged;
    }

    public void PipRig(){
        isRigged = true;
        spriteRenderer.sprite = pipRigged;
    }
}
