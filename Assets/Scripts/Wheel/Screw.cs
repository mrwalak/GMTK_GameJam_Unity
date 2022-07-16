using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    public Sprite unscrewedSprite;
    public Vector2 displaceDirection;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;

    private float displaceAmount = 0.1f;
    private float mouseOverAngleChange = 45f;
    private float unscrewVelocity = 2f*360f;
    
    private bool isScrewing = false;
    private float screw_t = 0;
    private float timeToUnscrew = 1f;

    public Vector2 startPos;
    private Vector2 endPos;
    private Vector2 startScale = new Vector2(1f, 1f);
    private Vector2 endScale = new Vector2(1.1f, 1.1f);

    private Vector2 popOffScale = new Vector2(1.3f, 1.3f);
    public bool isPopped = false;

    void Awake(){
        startPos = transform.position;
        endPos = startPos + displaceDirection.normalized * displaceAmount;
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    void OnMouseEnter(){
        transform.Rotate(new Vector3(0, 0, mouseOverAngleChange));
    }

    void OnMouseExit(){
        transform.Rotate(new Vector3(0, 0, -mouseOverAngleChange));
    }

    void OnMouseDown(){
        isScrewing = true;
    }

    void OnMouseUp(){
        isScrewing = false;
    }

    void PopScrew(){
        isPopped = true;
        spriteRenderer.sprite = unscrewedSprite;
        transform.localScale = popOffScale;
        body.isKinematic = false;
    }

    void Update(){
        if(isPopped){
            return;
        }

        if(isScrewing){
            screw_t += Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, unscrewVelocity * Time.deltaTime));

            float t = Mathf.Clamp(screw_t/timeToUnscrew, 0.0f, 1.0f);
            transform.position = Vector2.Lerp(startPos, endPos, t);
            transform.localScale = Vector2.Lerp(startScale, endScale, t);

            if(screw_t >= timeToUnscrew){
                PopScrew();
            }
        }
    }
}
