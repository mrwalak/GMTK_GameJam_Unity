using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGameManager : MonoBehaviour
{
    private float height;
    private float width;
    private static float laneStart_x;
    private static float lane_dx;

    public const int NUM_COINS = 10;
    public const float PERCENT_PADDING = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        laneStart_x = -width * (1f - (PERCENT_PADDING * 2f));
        lane_dx = (2f * width * (1f - 2f*PERCENT_PADDING)) / ((float) NUM_COINS - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float GetLaneXCoord(int i){
        return laneStart_x + i*lane_dx;
    }
}
