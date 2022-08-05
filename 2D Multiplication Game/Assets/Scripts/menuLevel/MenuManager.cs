using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;
    [SerializeField] GameObject audioPanel;

    bool soundPanel;
    
    void Start()
    {
        soundPanel = false;
        audioPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, -43, 0);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    public void Play()
    {
        if (PlayerPrefs.GetInt("SoundState") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("menuTab2");
    }

    public void Settings()
    {
        if (PlayerPrefs.GetInt("SoundState") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        if (!soundPanel)
        {
            audioPanel.GetComponent<RectTransform>().DOLocalMoveX(175, .5f);
            soundPanel = true;
        }
        else
        {
            audioPanel.GetComponent<RectTransform>().DOLocalMoveX(0, .5f);
            soundPanel = false;
        }
    }

    public void Exit()
    {
        if (PlayerPrefs.GetInt("SoundState") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        Application.Quit();
    }
}
