using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelParent : MonoBehaviour
{
    private Camera mainCamera;

    public GameObject hingeTarget;
    public HingeJoint2D hinge;
    public Rigidbody2D hingeBody;

    private bool isDragging = false;

    void Awake(){
        mainCamera = Camera.main;
    }

    public void ClickBegan(){
        // Start drag
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        hingeTarget.transform.position = mousePos;

        Vector2 newAnchor = hinge.gameObject.transform.InverseTransformPoint(mousePos);
        hinge.anchor = newAnchor;
        Vector2 newConnectedAnchor = hingeTarget.transform.InverseTransformPoint(mousePos);
        hinge.connectedAnchor = newConnectedAnchor;

        hinge.enabled = true;
        hingeBody.isKinematic = false;
        isDragging = true;
    }

    void Update(){
        if(isDragging){
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            hingeTarget.transform.position = mousePos;
        }
    }

    public void ClickEnded(){
        hinge.enabled = false;
        isDragging = false;
    }
}
