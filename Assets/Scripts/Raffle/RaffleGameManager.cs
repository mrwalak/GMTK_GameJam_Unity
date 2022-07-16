using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaffleGameManager : MonoBehaviour
{
    public TicketManager ticketManager;
    public TMP_Text moneyCount; 

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
        if(hasMoney){
            moneyCount.text = "$0";
            ticketManager.GiveManyTickets();
        }
    }

    public void AquireGold(){
        moneyCount.text = "$500";
        hasMoney = true;
    }

}
