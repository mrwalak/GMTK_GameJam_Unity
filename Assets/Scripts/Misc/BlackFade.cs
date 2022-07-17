using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    private Image image;

    void Awake(){
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 1);
    }

}
