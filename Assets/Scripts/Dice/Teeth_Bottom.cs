using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth_Bottom : MonoBehaviour
{
    public bool isChewingGum = false;
    private GameObject gumObj;
    private Gum gum;

    private float nextRandomBoost_t = -1;
    private Rigidbody2D body;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "UnchewedGum" && !isChewingGum){
            isChewingGum = true;
            gumObj = collisionInfo.gameObject;
            gum = gumObj.GetComponent<Gum>();
            gum.BeginChew();
            gumObj.GetComponent<BoxCollider2D>().enabled = false;

            gumObj.transform.parent = gameObject.transform;
            gumObj.transform.eulerAngles = new Vector3(0, 0, 90f);
            gumObj.transform.localPosition = new Vector2(2, 0.7f);
            gumObj.transform.GetComponent<Rigidbody2D>().isKinematic = true;

            nextRandomBoost_t = Time.time + Random.value * 1f;
        }
    }

    void Update(){
        if(isChewingGum){
            if(Time.time > nextRandomBoost_t){
                nextRandomBoost_t = Time.time + Random.value * 1f;
                RandomBoost();
            }
        }
    }

    void RandomBoost(){
        body.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
    }
}
