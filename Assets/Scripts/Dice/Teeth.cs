using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth : MonoBehaviour
{
    public Vector2 jumpImpulse = new Vector2(1, 1);
    private Rigidbody2D body;

    public Teeth_Bottom bottomTeeth;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    public void DoAJump(){
        body.AddForce(jumpImpulse);
    }

    public bool IsChewingGum(){
        return bottomTeeth.isChewingGum;
    }

    public Vector2 GetPosition(){
        return bottomTeeth.gameObject.transform.position;
    }

}
