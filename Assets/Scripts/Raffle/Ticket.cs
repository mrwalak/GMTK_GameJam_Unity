using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public Vector2 showTicketPosition = new Vector2(0, -3.55f);
    public Vector2 showTicketScale = new Vector2(1f, 1f);
    public Vector2 jarTicketPosition = new Vector2(3.113f, -1.598f);
    public Vector2 jarTicketScale = new Vector2(0.054f, 0.054f);
    public Vector2 apexPosition = new Vector2(2.7f, 1.75f);

    private const float positionVariation = 0.5f;
    private const float rotationVariation = 30f;

    private const float TIME_TO_APEX = 0.4f;
    private const float DIVE_TIME = 1.5f;
    private const float ROTATION_MIN = 1 * 360f;
    private const float ROTATION_MAX = 3 * 360f;

    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetOpacity(0f);
    }

    public void FadeInShow(bool forceCenter = false){
        transform.position = showTicketPosition;
        transform.localScale = showTicketScale;
        LeanTween.alpha(gameObject, 1f, 1f).setOnComplete(FadeInDone);
    }

    public void SnapInShow(){
        transform.position = showTicketPosition;
        transform.localScale = showTicketScale;
        transform.position = new Vector2(
            transform.position.x + (positionVariation * Random.value), 
            transform.position.y + (positionVariation * Random.value)
        );
        transform.Rotate(new Vector3(0, 0, Random.value*rotationVariation - (rotationVariation/2f)));
        SetOpacity(1f);
        StaticData.RunWithDelay(DiveIntoJar, 1f);
    }

    public void SetOpacity(float f){
        Color color = spriteRenderer.color;
        Color newColor = new Color(color.r, color.g, color.b, f);
        spriteRenderer.color = newColor;
    }

    public void DiveIntoJar(){
        LeanTween.moveX(gameObject, jarTicketPosition.x, DIVE_TIME).setOnComplete(DiveDone);
        LeanTween.scale(gameObject, jarTicketScale, DIVE_TIME);
        LeanTween.alpha(gameObject, 0f, DIVE_TIME).setEase(LeanTweenType.easeInExpo);
        LeanTween.moveY(gameObject, apexPosition.y, TIME_TO_APEX).setEase(LeanTweenType.easeOutQuad).setOnComplete(DiveApex);
        float rotate = Mathf.Lerp(ROTATION_MIN, ROTATION_MAX, Random.value);
        LeanTween.rotateZ(gameObject, rotate, DIVE_TIME).setEase(LeanTweenType.easeInExpo);
    
    }

    public void DiveApex(){
        LeanTween.moveY(gameObject, jarTicketPosition.y, DIVE_TIME - TIME_TO_APEX).setEase(LeanTweenType.easeInQuad);
    }

    public void DiveDone(){
        // Increment jar counter first
        Destroy(gameObject);
    }

    public void FadeInDone(){
        StaticData.RunWithDelay(DiveIntoJar, 2f);
    }


}
