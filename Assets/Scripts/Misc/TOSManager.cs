using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TOSManager : MonoBehaviour
{
    public GameObject emptyBox;
    public GameObject checkedBox;

    public GameObject blackFade;

    public void Start(){
        Debug.Log("START");
        LeanTween.alpha(blackFade.GetComponent<RectTransform>(), 0f, 1f);
    }

    public void AgreeClicked(){
        emptyBox.SetActive(false);
        checkedBox.SetActive(true);
        StaticData.RunWithDelay(ToCoins, 2f);
    }

    public void ToCoins(){
        LeanTween.alpha(blackFade.GetComponent<RectTransform>(), 1f, 1f).setOnComplete(LoadNextScene);
    }

    public void LoadNextScene(){
        SceneManager.LoadScene("Coin");
    }
}
