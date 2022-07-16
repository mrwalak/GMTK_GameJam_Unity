using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticData : MonoBehaviour
{
    public static void  RunWithDelay(Action onComplete, float delay){
        LeanTween.value(0f, 1f, delay).setOnComplete(onComplete);
    }
}
