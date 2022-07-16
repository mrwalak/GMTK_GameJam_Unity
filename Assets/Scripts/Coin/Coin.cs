using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public Sprite headsSprite;
    public Sprite tailsSprite;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;
    private const float FLIP_VELOCITY = 5f;
    private const float FLIP_RANDOM_DELTA = 1f;

    private bool isFlipping = false;
    private int flipFrameCount = 0;
    private float distToGround;
    private const float RAYCAST_ERROR = 0.01f;
    private CircleCollider2D circleCollider;

    private int layerMask;
    private float groundedCount_t = 0;
    private const float GROUNDED_COUNT_TO_END = 0.5f;
    private int forcedOutcome = 0;

    private Action onFlipComplete;
    private bool canTamper = false;
    private bool isHeads = true;
    private bool isSecondFlip = false;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeToHeads();
        body = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        distToGround = circleCollider.radius + RAYCAST_ERROR;

        layerMask = (1 <<  LayerMask.NameToLayer("Coin"));
        layerMask |= (1 << LayerMask.NameToLayer("Ignore Raycast"));
        layerMask = ~layerMask;
    }

    // -1 is forced tails, 0 is no forced outcome, 1 is forced heads
    public void Flip(int forcedOutcome, bool isSecondFlip){
        body.isKinematic = false;
        body.velocity = new Vector2(0, FLIP_VELOCITY + UnityEngine.Random.value * FLIP_RANDOM_DELTA);
        isFlipping = true;
        groundedCount_t = 0;
        this.forcedOutcome = forcedOutcome;
        this.isSecondFlip = isSecondFlip;
    }

    public void Reset(){
        transform.position = new Vector2(transform.position.x, 0);
        body.isKinematic = true;
    }

    public void SetOnFlipComplete(Action callback){
        onFlipComplete = callback;
    }

    void Update(){
        if(isFlipping){
            flipFrameCount++;
            if(flipFrameCount % 10 == 0){
                RandomSprite();
            }

            if(IsGrounded()){
                groundedCount_t += Time.deltaTime;
                if(groundedCount_t >= GROUNDED_COUNT_TO_END){
                    isFlipping = false;
                    ProcessForcedOutcome();
                    if(onFlipComplete != null){
                        onFlipComplete();
                    }
                    if(isSecondFlip){
                        canTamper = true;
                    }
                }
            }else{
                groundedCount_t = 0;
            }
        }
    }

    bool IsGrounded(){
        return Physics2D.Raycast(circleCollider.bounds.center, Vector2.down, distToGround, layerMask);
    }

    void ChangeToHeads(){
        isHeads = true;
        spriteRenderer.sprite = headsSprite;
    }

    void ChangeToTails(){
        isHeads = false;
        spriteRenderer.sprite = tailsSprite;
    }

    void ProcessForcedOutcome(){
        if(forcedOutcome == -1){
            ChangeToTails();
        }else if(forcedOutcome == 1){
            ChangeToHeads();
        }else{
            // Do nothing... leave at whatever we are on
        }
    }

    void RandomSprite(){
        float rand = UnityEngine.Random.value;
        if(rand > 0.5f){
            ChangeToHeads();
        }else{
            ChangeToTails();
        }
    }

    void OnMouseDown(){
        // You need another case here where you try to tamper but lights are on
        if(canTamper){
            if(isHeads){
                ChangeToTails();
            }else{
                ChangeToHeads();
            }
        }
    }


}
