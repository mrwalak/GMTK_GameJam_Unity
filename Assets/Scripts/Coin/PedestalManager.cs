using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public GameObject pedestalPrefab;

    private GameObject[] pedestals;

    void Start()
    {
        pedestals = new GameObject[CoinGameManager.NUM_COINS];
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            GameObject pedestalObj = Instantiate(pedestalPrefab, transform);
            pedestalObj.transform.position = new Vector2(
                CoinGameManager.GetLaneXCoord(i), (i == 0 ? -4f : -6.5f));
            pedestals[i] = pedestalObj;
        }    
    }

    public void ToTenCoinFlip(){
        for(int i = 1; i < CoinGameManager.NUM_COINS; i++){
            LeanTween.moveY(pedestals[i], -4f, 3f).setDelay(i*0.1f);
        }
    }
}
