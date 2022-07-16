using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;
    public LightsManager lightsManager;
    
    public Vector2 mouseOverScale_1 = new Vector2(.7f, .7f);
    public Vector2 normalScale_1 = new Vector2(.6f, .6f);

    private bool lightsOn = true;

    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = onSprite;
    }

    void OnMouseEnter(){
        if(MouseIsUnobstructed()){
            transform.localScale = mouseOverScale_1;
        }
    }

    void OnMouseExit(){
        transform.localScale = normalScale_1;
    }

    void UpdateAppearance(){
        if(lightsOn){
            lightsManager.LightsOn();
            spriteRenderer.sprite = onSprite;
        }else{
            lightsManager.LightsOff();
            spriteRenderer.sprite = offSprite;
        }
    }

    private bool MouseIsUnobstructed(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        return (hit.transform.gameObject.GetComponent<LightSwitch>() != null);
    }

    void OnMouseDown(){
        if(MouseIsUnobstructed()){
            lightsOn = !lightsOn;
            UpdateAppearance();
        } 
    }
}
