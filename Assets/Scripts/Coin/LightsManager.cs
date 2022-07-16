using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.Universal;

public class LightsManager : MonoBehaviour
{
    public GameObject lightPrefab;

    private Light2D[] lights;

    void Start()
    {
        lights = new Light2D[CoinGameManager.NUM_COINS];
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            GameObject lightObj = Instantiate(lightPrefab, transform);
            lightObj.transform.position = new Vector2(CoinGameManager.GetLaneXCoord(i), 5.7f);
            lights[i] = lightObj.GetComponent<Light2D>();
            if(i != 0){
                lights[i].enabled = false;
            }
        }    
    }

    public void ToTenCoinFlip(){
        for(int i = 1; i < CoinGameManager.NUM_COINS; i++){
            lights[i].enabled = true;
        }
    }

    public void LightsOn(){
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            lights[i].enabled = true;
        }
    }

    public void LightsOff(){
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            lights[i].enabled = false;
        }
    }
}
