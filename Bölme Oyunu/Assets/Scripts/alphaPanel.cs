using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class alphaPanel : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.GetComponent<CanvasGroup>().DOFade(0, 2f);
    }
}
