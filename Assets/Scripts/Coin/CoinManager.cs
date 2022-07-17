using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    private Coin[] coins;

    private CoinGameManager gameManager;

    void Awake(){
        gameManager = (CoinGameManager)FindObjectOfType(typeof(CoinGameManager));
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = new Coin[CoinGameManager.NUM_COINS];
        
        for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
            GameObject coinObj = Instantiate(coinPrefab, transform);
            coinObj.transform.position = new Vector2(CoinGameManager.GetLaneXCoord(i), 0 );
            coins[i] = coinObj.GetComponent<Coin>();
            if(i != 0){
                coins[i].gameObject.SetActive(false);
            }
        }
    }

    // if flipAll is true, all coins flip (duh)
    // if flipAll is false, only the first coin flips
    public void FlipCoins(bool flipAll){
        if(flipAll){
            int forcedTails = Random.Range(0, 10);
            for(int i = 0; i < CoinGameManager.NUM_COINS; i++){
                coins[i].Flip((i == forcedTails) ? -1 : 0, true);
            }
        }else{
            coins[0].SetOnFlipComplete(gameManager.OnFlipComplete);
            coins[0].Flip(1, false);
        }
    }

    public void ToTenCoinFlip(){
        coins[0].Reset();
        for(int i = 1; i < CoinGameManager.NUM_COINS; i++){
            coins[i].gameObject.SetActive(true);
        }
    }

    public bool AllCoinsAreHeads(){
        bool allHeads = true;
        for(int i = 0; i < coins.Length; i++){
            allHeads = allHeads && (coins[i].isHeads);
        }
        return allHeads;
    }
}
