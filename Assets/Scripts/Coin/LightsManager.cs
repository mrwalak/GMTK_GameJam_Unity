using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public GameObject lightPrefab;

    private 

    void Start()
    {
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            GameObject lightObj = Instantiate(lightPrefab, transform);
            lightObj.transform.position = new Vector2(CoinGameManager.GetLaneXCoord(i), 5.7f);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
