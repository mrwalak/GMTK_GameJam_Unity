using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public Sprite[] crackProgression;
    public Sprite gold;
    public Sprite holeMask;

    public SpriteRenderer holeRenderer;
    public SpriteRenderer holeMaskRenderer;
    public SpriteRenderer goldRenderer;

    private int holeProgression_i = 0;
    private bool goldTaken = false;

    private RaffleGameManager gameManager;

    void Awake(){
        gameManager = (RaffleGameManager)FindObjectOfType(typeof(RaffleGameManager));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ShovelHead"){
            Vector2 v = other.gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity;
            if(v.magnitude < 4f){
                return;
            }
            
            if(holeProgression_i < (crackProgression.Length - 1)){
                holeProgression_i++;
                UpdateAppearance();
            }
        }
    }

    void UpdateAppearance(){
        holeRenderer.sprite = crackProgression[holeProgression_i];
        if(holeProgression_i == crackProgression.Length - 1){
            holeMaskRenderer.sprite = holeMask;
            goldRenderer.sprite = gold;
        }
    }

    void OnMouseDown(){
        if(goldTaken){
            return;
        }

        if(holeProgression_i == (crackProgression.Length - 1)){
            goldRenderer.sprite = null;
            gameManager.AquireGold();
            goldTaken = true;
        }
    }
}
