using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class subManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;
    void Start()
    {
        panel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        panel.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    public void ButtonClickString(string buttonToScene)
    {
        if (PlayerPrefs.GetInt("SoundState") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        PlayerPrefs.SetString("buttonScene", buttonToScene);
        SceneManager.LoadScene("gameLevel");
    }

   public void ReturnButton()
    {
        if (PlayerPrefs.GetInt("SoundState") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        SceneManager.LoadScene("menuLevel");
    }
}
