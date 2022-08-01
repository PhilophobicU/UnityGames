using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startImage;
    void Start()
    {
        if (PlayerPrefs.HasKey("buttonScene"))
        {
            //Debug.Log(PlayerPrefs.GetString("buttonScene"));
        }
       
        StartCoroutine(StartGameRoutine());
    }
    
    IEnumerator StartGameRoutine()
    {
        startImage.GetComponent<RectTransform>().DOScale(1.3f, .5f);
        yield return new WaitForSeconds(.6f);
        startImage.GetComponent<RectTransform>().DOScale(0, .5f);
        startImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        yield return new WaitForSeconds(.6f);

        StartGame();
    }
    void StartGame()
    {
        Debug.Log("Game has started");
    }
}
