using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RaffleGameManager : MonoBehaviour
{
    public GameObject interactButtons;
    public GameObject moneyLabels;

    public AudioManager audioManager;

    public GameObject blackFade;

    public TicketManager ticketManager;
    public TMP_Text moneyCount; 

    public bool gameRiggedCorrectly = false;
    public bool hasMoney = false;
    private bool playedPoorAudio = false;

    private bool blockPoorAudio = false;

    public DrawManager drawManager;
    private string nextScene;

    void Start()
    {
        LeanTween.alpha(blackFade.GetComponent<RectTransform>(), 0f, 1f);
        audioManager.Play("Opening");
        StaticData.RunWithDelay(ticketManager.GiveOneTicket, (StaticData.IGNORE_AUDIO ? 2f : 20f));
        StaticData.RunWithDelay(ShowUIElements, (StaticData.IGNORE_AUDIO ? 4f : 32f));
    }

    public void ShowUIElements(){
        interactButtons.SetActive(true);
        moneyLabels.SetActive(true);
    }

    public void BeginRaffleScene(){
        StaticData.RunWithDelay(ticketManager.GiveOneTicket, 2f);
    }

    void Update(){
        
    }

    public void DrawClicked(){
        interactButtons.SetActive(false);
        if(gameRiggedCorrectly){
            audioManager.Play("Win");
            StaticData.RunWithDelay(drawManager.Draw, 2f);
            nextScene = "ToBeContinued";
            StaticData.RunWithDelay(FadeOutToScene, 66f);
        }else{
            audioManager.Play("Death");
            StaticData.RunWithDelay(drawManager.Draw, 3f);
            nextScene = "Raffle";
            StaticData.RunWithDelay(FadeOutToScene, 19f);
        }
    }

    public void BuyClicked(){
        if(hasMoney){
            moneyCount.text = "$0";
            ticketManager.GiveManyTickets();
            gameRiggedCorrectly = true;
            audioManager.Play("Rich");
            blockPoorAudio = true;
            StaticData.RunWithDelay(UnblockPoorAudio, 10f);
            hasMoney = false;
        }else{
            if(blockPoorAudio){
                return;
            }

            if(!playedPoorAudio){
                audioManager.Play("Poor");
                playedPoorAudio = true;
            }
        }
    }

    public void UnblockPoorAudio(){
        blockPoorAudio = false;
    }

    public void AquireGold(){
        moneyCount.text = "$500";
        hasMoney = true;
    }

    public void FadeOutToScene(){
        LeanTween.alpha(blackFade.GetComponent<RectTransform>(), 1f, 1f).setOnComplete(LoadNextScene);
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(nextScene);
    }

}
