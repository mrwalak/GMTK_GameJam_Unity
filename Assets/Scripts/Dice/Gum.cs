using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : MonoBehaviour
{
    public Vector2 mouseOverScale = new Vector2(0.5f, 0.5f);
    public Vector2 normalScale = new Vector2(0.37f, 0.37f);

    private Rigidbody2D body;

    public bool requireNoObstructions = true;
    public bool hasBeenFound = false;

    private bool isBeingDragged = false;
    private Vector2 dragOffset;

    private bool isBeingChewed = false;

    // Cancel all mouse control
    public void BeginChew(){
        isBeingChewed = true;
    }

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void OnMouseEnter(){
        if(hasBeenFound){
            return;
        }

        if(requireNoObstructions){
            if(MouseIsUnobstructed()){
                transform.localScale = mouseOverScale;
            }
        }else{
            transform.localScale = mouseOverScale;
        }
    }

    void OnMouseExit(){
        if(hasBeenFound){
            return;
        }

        transform.localScale = normalScale;
    }

    void Update(){
        if(isBeingChewed){
            return;
        }

        if(isBeingDragged){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + dragOffset;
        }
    }

    void OnMouseDown(){
        if(hasBeenFound){
            if(isBeingDragged){
                isBeingDragged = false;
                body.isKinematic = false;
            }else{
                isBeingDragged = true;
                body.isKinematic = true;
                body.velocity = new Vector2(0, 0);
                body.angularVelocity = 0;

                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = transform.position;
                dragOffset = myPos - mousePos;
            }

            return;
        }

        if(MouseIsUnobstructed()){
            hasBeenFound = true;
            transform.parent = null;
            transform.position = new Vector3(
                transform.position.x, transform.position.y, -5
            );
            LeanTween.scale(gameObject, new Vector3(0.5f, 0.5f, 1), 1.0f).setEase(LeanTweenType.easeOutQuad);
            body.isKinematic = false;
            body.angularVelocity = 15f;
        }
    }

    private bool MouseIsUnobstructed(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        return (hit.transform.gameObject == gameObject);
    }
}
