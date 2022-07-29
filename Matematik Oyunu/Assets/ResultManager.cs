using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private Text correctText,wrongText,scoreText;

    private int scoreTime;
    private int finalScore, scoreInc, totalScore;
    private bool timeEnd = true;

    private void Awake()
    {
        scoreTime = 10;
        timeEnd = true;
    }
    public void ShowResults(int correct, int wrong, int score)
    {
        correctText.text = correct.ToString();
        wrongText.text = wrong.ToString();
        scoreText.text = score.ToString();

        totalScore = score;
        scoreInc = totalScore / 10;

        StartCoroutine(ShowResultSteps());

    }
    IEnumerator ShowResultSteps()
    {
        while (timeEnd)
        {
            yield return new WaitForSeconds(.1f);

            finalScore += scoreInc;

            if (finalScore > totalScore)
            {
                finalScore = totalScore;
            }
            scoreText.text = finalScore.ToString();

            if (scoreTime <= 0)
            {
                timeEnd = false;
            }

            scoreTime--;

        }
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("menuLevel");
    }
    public void Restartgame()
    {
        SceneManager.LoadScene("gameLevel");
    }
}
