using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWheel : MonoBehaviour
{
    public GameObject wheelPinPrefab;

    private float radius = 3.30f; // Kind of bad practice, but whatever, its a game jam
    private const int NUM_PINS = 50;
    private const float STROKE_OFFSET = 0.1f;

    void Awake(){

    }

    void Start(){
        float rotSlice = 2.0f * Mathf.PI / NUM_PINS;
        for(int i = 0; i < NUM_PINS; i++){
            GameObject pin = Instantiate(wheelPinPrefab, transform);
            Vector2 position = new Vector2(
                radius * Mathf.Cos(rotSlice*i),
                radius * Mathf.Sin(rotSlice*i)
            );
            if(i == 13){
                pin.transform.localPosition = new Vector2(-0.1341f, 3.3078f);
            }else if(i == 12){
                pin.transform.localPosition = new Vector2(0.0765f, 3.3104f);
            }else{
                pin.transform.localPosition = position;
            }
            
            
            
        }
    }


    // (-0.1341, 3.3078) 13
    // (0.0765, 3.3104) 12
}
