using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Sprite headsSprite;
    public Sprite tailsSprite;

    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = headsSprite;
    }

    void Flip(){
        
    }
}
