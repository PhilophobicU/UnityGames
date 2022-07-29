using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField] private GameObject trueImage, falseImage;
    void Start()
    {
        trueImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseImage.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    public void TrueFalse(bool check)
    {
        if (check)
        {
            trueImage.GetComponent<RectTransform>().DOScale(1, 0.2f).SetEase(Ease.OutBack);
        }

        else
        {
            falseImage.GetComponent<RectTransform>().DOScale(1, 0.2f).SetEase(Ease.OutBack);
        }

        Invoke("Nep", 0.6f);
    }
   
    public void Nep()
    {
        trueImage.GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.InBack);
        falseImage.GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.InBack);
    }
}
