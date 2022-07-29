using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] private GameObject countdownFrame;
    [SerializeField] private Text countdownText;

    GameManager gm;
    private void Awake()
    {
        gm = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
       StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        countdownText.text = "3";

        yield return new WaitForSeconds(1);

        countdownFrame.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.5f);
        countdownFrame.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);

        yield return new WaitForSeconds(1);
        countdownText.text = "2";

        countdownFrame.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.5f);
        countdownFrame.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);

        yield return new WaitForSeconds(1);
        countdownText.text = "1";

        countdownFrame.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.5f);
        countdownFrame.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);

        yield return new WaitForSeconds(.5f);
        gm.GameStart();
        StopAllCoroutines();
    }

}
