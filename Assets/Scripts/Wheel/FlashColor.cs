using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public Color color;

    private SpriteRenderer spriteRenderer;

    private const float PERIOD = 0.25f;
    private bool isFlashing = false;
    private bool isColored = false;
    private float t = 0;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartFlash(){
        isFlashing = true;
    }

    void Update(){
        if(!isFlashing){
            return;
        }

        t += Time.deltaTime;
        if(t > PERIOD){
            t -= PERIOD;
            isColored = !isColored;
            UpdateAppearance();
        }
    }

    void UpdateAppearance(){
        if(isColored){
            spriteRenderer.color = color;
        }else{
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }


}
