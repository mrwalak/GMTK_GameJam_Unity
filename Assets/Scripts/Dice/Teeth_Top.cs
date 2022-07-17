using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth_Top : MonoBehaviour
{
    public Rigidbody2D bottomTeethBody;
    public Teeth teethParent;

    private Rigidbody2D body;

    public Vector2 jumpImpulse = new Vector2(1000, 1000);
    private const float TOP_TEETH_VELOCITY = 4f;
    private const float DELAY_TO_JUMP = 0.2f;
    private float timeSinceLastHit_t = 0;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(body.rotation < -10f){
            body.angularVelocity = 360f * (Random.value * 2f);
            DoAJump();
            timeSinceLastHit_t = 0;
        }else{
            timeSinceLastHit_t += Time.deltaTime;
        }

    }

    public void DoAJump(){
        bottomTeethBody.AddForce(jumpImpulse, ForceMode2D.Impulse);
    }

}
