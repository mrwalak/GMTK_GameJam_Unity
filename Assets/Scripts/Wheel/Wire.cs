using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public WireHinge[] hinges;
    public Color color;
    public Sprite hingeSprite;
    public GameObject connectorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < hinges.Length; i++){
            hinges[i].SetHingeSprite(hingeSprite);
            hinges[i].SetConnectorPrefab(connectorPrefab);
            hinges[i].SetColor(color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
