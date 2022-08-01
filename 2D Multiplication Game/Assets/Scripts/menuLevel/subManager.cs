using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class subManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    void Start()
    {
        panel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        panel.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    public void ButtonClickString(string buttonToScene)
    {
        PlayerPrefs.SetString("buttonScene", buttonToScene);
        SceneManager.LoadScene("gameLevel");
    }

   public void ReturnButton()
    {
        SceneManager.LoadScene("menuLevel");
    }
}
