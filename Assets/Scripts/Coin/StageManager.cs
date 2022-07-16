using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public LightsManager lightsManager;
    public PedestalManager pedestalManager;
    public CoinManager coinManager;
    public GameObject bigSign;

    public void FlipCoins(bool flipAll){
        coinManager.FlipCoins(flipAll);
    }

    public void ToTenCoinFlip(){
        lightsManager.ToTenCoinFlip();
        pedestalManager.ToTenCoinFlip();
        coinManager.ToTenCoinFlip();
    }

    public void ShowLightSwitch(){
        LeanTween.moveY(bigSign, 7.2f, 3f);
    }
}
