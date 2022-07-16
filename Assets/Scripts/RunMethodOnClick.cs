using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RunMethodOnClick : MonoBehaviour
{
    public EventTrigger.TriggerEvent onClick;

    void OnMouseDown(){
        onClick.Invoke(null);
    }
}
