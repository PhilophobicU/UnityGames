using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject startBTN, exitBTN;
    void Start()
    {
        FadeIn();
    }

    void FadeIn()
    {
        startBTN.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        exitBTN.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
    }
    public void GameLevel()
    {
        SceneManager.LoadScene("gameLevel");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
