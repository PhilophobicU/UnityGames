using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private int totalPoints;
    private int pointIncrease;
    [SerializeField] private Text pointValue;
    void Start()
    {
        pointValue.text = totalPoints.ToString();
    }

    public void AddPoints(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                pointIncrease = 5;
                break;
            case "medium":
                pointIncrease = 10;
                break;
            case "hard":
                pointIncrease = 15;
                break;
        }
        totalPoints += pointIncrease;
        pointValue.text = totalPoints.ToString();
    }

}
