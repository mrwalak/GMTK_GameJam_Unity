using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticData : MonoBehaviour
{
    public static bool IGNORE_AUDIO = false;

    public static bool CAN_CHEAT_COINS = false;


    public static int RunWithDelay(Action onComplete, float delay){
        return LeanTween.value(0f, 1f, delay).setOnComplete(onComplete).id;
    }
}
