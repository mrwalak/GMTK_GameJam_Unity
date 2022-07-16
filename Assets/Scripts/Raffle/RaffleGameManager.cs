using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaffleGameManager : MonoBehaviour
{
    public TicketManager ticketManager;

    public bool hasMoney = false;

    void Start()
    {
        StaticData.RunWithDelay(ticketManager.GiveOneTicket, 2f);
    }

    void Update(){
        
    }

    public void DrawClicked(){

    }

    public void BuyClicked(){

    }

}
