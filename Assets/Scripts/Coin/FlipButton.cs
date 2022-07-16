using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipButton : MonoBehaviour
{
    public CoinGameManager gameManager;

    public Vector2 mouseOverScale = new Vector2(1.1f, 1.1f);
    public Vector2 normalScale = new Vector2(1.0f, 1.0f);

    void Awake(){
        transform.localScale = normalScale;
    }

    void OnMouseEnter(){
        transform.localScale = mouseOverScale;
    }

    void OnMouseExit(){
        transform.localScale = normalScale;
    }

    void OnMouseDown(){
        gameManager.FlipClicked();
    }

    public void Hide(){
        gameObject.SetActive(false);
    }

    public void Show(){
        gameObject.SetActive(true);
    }


}
