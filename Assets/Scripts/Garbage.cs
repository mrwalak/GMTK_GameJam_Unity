using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public float rotVelocity = 360.0f; // Degrees per second
    public float sample;

    private float rot = 0.0f;

    public void SetRotation(float deg){
        transform.eulerAngles = new Vector3(
            gameObject.transform.eulerAngles.x,
            gameObject.transform.eulerAngles.y,
            deg
        );
    }

    void Update(){
        rot += rotVelocity * Time.deltaTime;
        SetRotation(rot);
    }
}
