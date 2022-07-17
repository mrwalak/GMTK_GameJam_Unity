using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethManager : MonoBehaviour
{
    public GameObject teethPrefab;
    public GameObject chewedGum;

    private bool teethAlreadyActive = false;
    private GameObject activeTeethObj;
    private Teeth activeTeeth;

    private float height;
    private float width;
    private const float EXTRA_WIDTH = 8f;

    void Awake(){
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        Debug.Log("Width = " + width);
    }

    public void ToothSignClicked(){
        if(teethAlreadyActive){
            if(!activeTeeth.IsChewingGum()){
                Destroy(activeTeethObj);
            }else{
                return; // Can't create new teeth when chewing gum
            }
        }

        activeTeethObj = Instantiate(teethPrefab);
        activeTeeth = activeTeethObj.GetComponent<Teeth>();
        teethAlreadyActive = true;
    }

    void Update(){
        if(teethAlreadyActive){
            if(activeTeeth.GetPosition().x > width + EXTRA_WIDTH){
                if(activeTeeth.IsChewingGum()){
                    SpitGum();
                }
                Destroy(activeTeethObj);
                teethAlreadyActive = false;
            }
        }
    }

    public void SpitGum(){
        Instantiate(chewedGum);
    }


}
