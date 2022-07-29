using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resultManager : MonoBehaviour
{
    [SerializeField] private Text correctTxt, wrongTxt, pointsTxt;
    [SerializeField] private GameObject[] stars;

    public void Results(int correct,int wrong,int point)
    {
        correctTxt.text = correct.ToString();
        wrongTxt.text = wrong.ToString();
        pointsTxt.text = point.ToString();

        foreach (var item in stars)
        {
            item.SetActive(false);
        }

        if (correct == 0)
        {

        }
        else if (correct == 1)
        {
            stars[0].SetActive(true);
        }
        else if (correct == 2)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
