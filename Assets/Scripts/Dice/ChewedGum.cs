using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewedGum : MonoBehaviour
{
    private Rigidbody2D body;

    private bool isBeingDragged = false;
    private Vector2 dragOffset;

    private GameObject diceInBounds;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void Start(){
        body.velocity = new Vector2(-4, 10);
        body.angularVelocity = -45f;
    }

    void Update(){
        if(isBeingDragged){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + dragOffset;
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                -5
            );
        }
    }

    void OnMouseDown(){
        if(isBeingDragged){
            // Check if in dice collider
            if(diceInBounds != null && !diceInBounds.GetComponent<Dice>().isRigged){
                diceInBounds.GetComponent<Dice>().GumRig();
                Destroy(gameObject);
            }

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
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Dice"){
            diceInBounds = other.gameObject;
            Debug.Log("Dice in bounds");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Dice"){
            Debug.Log("Leaving dice bounds");
            if(diceInBounds == other.gameObject){
                diceInBounds = null;
            }
        }
    }

}
