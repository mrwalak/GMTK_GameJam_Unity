using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireHinge : MonoBehaviour
{
    public Sprite hingeSprite;
    public GameObject connectedTo;

    private SpriteRenderer spriteRenderer;
    private GameObject connectorPrefab;
    private float wireWidth = 0.2f;

    private GameObject connectorObj;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start(){
        
    }

    public void SetWireWidth(float width){
        width = wireWidth;
    }

    public void SetHingeSprite(Sprite sprite){
        hingeSprite = sprite;
        spriteRenderer.sprite = hingeSprite;
    }

    public void SetConnectorPrefab(GameObject obj){
        connectorPrefab = obj;
        connectorObj = Instantiate(connectorPrefab, transform);
    }

    public void SetColor(Color color){
        spriteRenderer.color = color;
        if(connectorObj != null){
            connectorObj.GetComponent<SpriteRenderer>().color = color;
        }
    }

    void Update(){
        Vector2 startPos = transform.position;
        Vector2 endPos = connectedTo.transform.position;
        Vector2 dir = endPos - startPos;

        float dist = Vector2.Distance(startPos, endPos);
        connectorObj.transform.localScale = new Vector2(dist, wireWidth);
        connectorObj.transform.position = (startPos + endPos)/2;
        connectorObj.transform.position = new Vector3(
            connectorObj.transform.position.x,
            connectorObj.transform.position.y,
            transform.parent.transform.position.z
        );
        connectorObj.transform.right = -dir;
    }


}
