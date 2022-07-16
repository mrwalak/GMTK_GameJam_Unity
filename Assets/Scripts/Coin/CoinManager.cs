using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    private Coin[] coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = new Coin[CoinGameManager.NUM_COINS];
        
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            GameObject coinObj = Instantiate(coinPrefab, transform);
            coinObj.transform.position = new Vector2(CoinGameManager.GetLaneXCoord(i), 0 );
            coins[i] = coinObj.GetComponent<Coin>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
