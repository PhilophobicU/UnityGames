using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CirclesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] circles;
    
    void Start()
    {
        CircleScaleDown();
    }

    public void CircleScaleDown()
    {
        foreach (var circle in circles)
        {
            circle.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
    public void CircleScaleUp(int circleNumber)
    {
        circles[circleNumber].GetComponent<RectTransform>().DOScale(1,0.3f);

        if (circleNumber % 5 == 0)
        {
            CircleScaleDown();
        }
    }
}
