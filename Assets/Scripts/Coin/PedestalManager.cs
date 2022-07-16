using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public GameObject pedestalPrefab;

    void Start()
    {
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            GameObject pedestalObj = Instantiate(pedestalPrefab, transform);
            pedestalObj.transform.position = new Vector2(CoinGameManager.GetLaneXCoord(i), -4f);
        }    
    }
}
