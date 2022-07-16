using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOnMouseOver : MonoBehaviour
{
    public Vector2 mouseOverScale = new Vector2(1.1f, 1.1f);
    public Vector2 normalScale = new Vector2(1f, 1f);

    public bool requireNoObstructions = false;

    void OnMouseEnter(){
        if(requireNoObstructions){
            if(MouseIsUnobstructed()){
                transform.localScale = mouseOverScale;
            }
        }else{
            transform.localScale = mouseOverScale;
        }
    }

    void OnMouseExit(){
        transform.localScale = normalScale;
    }

    private bool MouseIsUnobstructed(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        return (hit.transform.gameObject == gameObject);
    }
}
