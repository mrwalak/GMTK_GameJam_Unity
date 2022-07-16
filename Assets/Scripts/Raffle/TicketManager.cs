using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    public GameObject ticketPrefab;

    private const int MANY_TICKET_NUM = 100;
    private const int MANY_TICKET_PRETEND_NUM = 500;
    private const float MANY_TICKET_DELAY = 0.05f;

    private float ticketSpam_t = -1;
    private int ticketSpamCount = 0;

    public void GiveOneTicket(){
        GameObject ticketObj = Instantiate(ticketPrefab, transform);
        Ticket ticket = ticketObj.GetComponent<Ticket>();
        ticket.FadeInShow();
    }

    public void GiveManyTickets(){
        ticketSpam_t = 0;
    }

    public void GiveOneOfManyTickets(){
        GameObject ticketObj = Instantiate(ticketPrefab, transform);
        Ticket ticket = ticketObj.GetComponent<Ticket>();
        ticket.SnapInShow();
    }

    void Update(){
        if(ticketSpam_t >= 0){
            ticketSpam_t += Time.deltaTime;
            while(ticketSpam_t > MANY_TICKET_DELAY && ticketSpamCount < MANY_TICKET_NUM){
                GiveOneOfManyTickets();
                ticketSpamCount++;
                ticketSpam_t -= MANY_TICKET_DELAY;
            }

            if(ticketSpamCount >= MANY_TICKET_NUM){
                ticketSpam_t = -1;
            }
        }
    }

}
