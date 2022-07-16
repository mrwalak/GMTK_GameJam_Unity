using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : MonoBehaviour
{
    public Sprite[] jarProgression;
    public int[] numTicketsToProgress;
    int currentProgression_i = 0;
    public SpriteRenderer jarProgressionSprite;
    
    public static int ticketCount = 0; // This is bad, but whatever. It's a game jam

    void Update(){
        while(numTicketsToProgress[currentProgression_i] < ticketCount && (currentProgression_i < jarProgression.Length - 1)){
            currentProgression_i++;
        }

        jarProgressionSprite.sprite = jarProgression[currentProgression_i];
    }
}
