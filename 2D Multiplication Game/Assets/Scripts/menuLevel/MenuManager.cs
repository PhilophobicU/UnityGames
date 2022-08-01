using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    
    void Start()
    {
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    public void Play()
    {
        SceneManager.LoadScene("menuTab2");
    }

    public void Settings()
    {
        Debug.Log("It'll build further days");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
