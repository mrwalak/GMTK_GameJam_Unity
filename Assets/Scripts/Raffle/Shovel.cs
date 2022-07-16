using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{

    Vector2 normalScale = new Vector2(.65f, .65f);
    Vector2 mouseOverScale = new Vector2(.75f, .75f);

    private bool isDragging = false;
    private bool hasBeenFound = false;
    private HingeJoint2D hinge;
    private ShovelParent shovelParent;

    void Awake(){
        hinge = GetComponent<HingeJoint2D>();
        shovelParent = transform.parent.GetComponent<ShovelParent>();
    }

    private bool MouseIsUnobstructed(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        return (hit.transform.gameObject == gameObject);
    }

    void OnMouseEnter(){
        if(MouseIsUnobstructed()){
            if(!hasBeenFound){
                transform.localScale = mouseOverScale;
            }
        }
    }

    void OnMouseExit(){
        if(!hasBeenFound){
            transform.localScale = normalScale;
        }
    }

    void OnMouseDown(){
        if(MouseIsUnobstructed()){
            transform.position = new Vector3(
                transform.position.x, transform.position.y, -1
            );
            hasBeenFound = true;
            transform.localScale = normalScale;

            shovelParent.ClickBegan();
        } 
    }

    void OnMouseUp(){
        shovelParent.ClickEnded();
    }
}
