using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontPanel : MonoBehaviour
{
    public Screw[] screws;
    private Vector2[] hingePoints = new Vector2[]{
        new Vector2(-3.65f, -2.15f),
        new Vector2(-3.65f, 2.15f),
        new Vector2(3.65f, 2.15f),
        new Vector2(3.65f, -2.15f)
    };
    
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private HingeJoint2D hinge;

    private bool isSwinging = false;
    private bool isDropped = false;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        hinge = GetComponent<HingeJoint2D>();
    }

    void Update(){
        if(isDropped){
            return;
        }

        int numPopped = 0;
        int lastRemaining_i = -1;
        for(int i = 0; i < screws.Length; i++){
            if(screws[i].isPopped){
                numPopped++;
            }else{
                lastRemaining_i = i;
            }
        }

        if(numPopped == 3){
            if(!isSwinging){
                isSwinging = true;
                hinge.anchor = hingePoints[lastRemaining_i];
                body.isKinematic = false;
            }    
        } else if(numPopped == 4){
            hinge.enabled = false;
            boxCollider.enabled = true;
            isDropped = true;
        }
    }
}
