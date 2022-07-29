using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel,timerPanel,resultPanel, text,topSquare,bottomSquare,biggerNumberImage;

    [SerializeField] private Text topText,bottomText,scoreText;

    int topValue,bottomValue,correctValue,buttonValue;

    TimerScript timerScript;
    CirclesManager circlesManager;
    TrueFalseManager trueFalseManager;
    ResultManager resultManager;
    AudioSource audioSource;

    [SerializeField] private AudioClip endClip, startClip, correctClip, wrongClip;

    int gameCount, gameStageNumber;

    int increaseAmount, totalScore,correctAnswer,wrongAnswer;

    private void Awake()
    {
        topText.text = "";
        bottomText.text = "";
        timerScript = Object.FindObjectOfType<TimerScript>();
        circlesManager = Object.FindObjectOfType<CirclesManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
        audioSource = this.GetComponent<AudioSource>();
    }
    
    

    void Start()
    {
        AppearPanels();
        SlideSquares();
    }

    private void AppearPanels()
    {
        timerPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        text.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }   
    private void SlideSquares()
    {
        topSquare.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        bottomSquare.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
    }

    public void GameStart()
    {
        timerScript.TimerStart();
        audioSource.PlayOneShot(startClip);
        GameStage();
        text.GetComponent<CanvasGroup>().DOFade(0, .2f);
        biggerNumberImage.GetComponent<CanvasGroup>().DOFade(1, .2f);
    }

    void GameStage()
    {
        if (gameCount < 5)
        {
            gameStageNumber = 1;
            increaseAmount = 25;
        }
        else if(gameCount >= 5 && gameCount < 10)
        {
            gameStageNumber = 2;
            increaseAmount = 50;
        }
        else if (gameCount >= 10 && gameCount < 15)
        {
            gameStageNumber = 3;
            increaseAmount = 75;
        }
        else if (gameCount >= 15 && gameCount < 20)
        {
            gameStageNumber = 4;
            increaseAmount = 100;
        }
        else if (gameCount >= 20 && gameCount < 25)
        {
            gameStageNumber = 5;
            increaseAmount = 125;
        }
        else
        {
            gameStageNumber = Random.Range(1, 6);
        }

        switch (gameStageNumber)
        {
            case 1:
                FunctionNumberOne();
                    break;
            case 2:
                FunctionNumberTwo();
                break;
            case 3:
                FunctionNumberThree();
                break;
            case 4:
                FunctionNumberFour();
                break;
            case 5:
                FunctionNumberFive();
                break;
        }
    }

    void FunctionNumberOne()
    {
        int rn = Random.Range(1, 50);

        if (rn >= 25)
        {
            topValue = Random.Range(2, 50);
            bottomValue = Mathf.Abs(topValue - Random.Range(1,11));
        }
        else
        {
            topValue = Random.Range(2, 50);
            bottomValue = topValue + Random.Range(1, 11);
        }

        if (topValue > bottomValue)
        {
            correctValue = topValue;
        }
        else if(topValue < bottomValue)
        {
            correctValue = bottomValue;
        }
        else
        {
            FunctionNumberOne();
                return;
        }
        Debug.Log(correctValue);
        topText.text = topValue.ToString();
        bottomText.text = bottomValue.ToString();
    }
    void FunctionNumberTwo()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 20);

        int thirdNumber = Random.Range(1, 10);
        int fourthNumber = Random.Range(1, 20);

        topValue = firstNumber + secondNumber;
        bottomValue = thirdNumber + fourthNumber;

        if (topValue > bottomValue)
        {
            correctValue = topValue;
        }
        else if (topValue < bottomValue)
        {
            correctValue = bottomValue;
        }
        else
        {
            FunctionNumberTwo();
            return;
        }

        topText.text = firstNumber + " + " + secondNumber;
        bottomText.text = thirdNumber + " + " + fourthNumber;



    }
    void FunctionNumberThree()
    {
        int firstNumber = Random.Range(11, 30);
        int secondNumber = Random.Range(1, 11);

        int thirdNumber = Random.Range(11, 40);
        int fourthNumber = Random.Range(1, 11);

        topValue = Mathf.Abs(firstNumber - secondNumber);
        bottomValue = Mathf.Abs(thirdNumber - fourthNumber);

        if (topValue > bottomValue)
        {
            correctValue = topValue;
        }
        else if (topValue < bottomValue)
        {
            correctValue = bottomValue;
        }
        else
        {
            FunctionNumberThree();
            return;
        }

        topText.text = firstNumber + " - " + secondNumber;
        bottomText.text = thirdNumber + " - " + fourthNumber;
    }
    void FunctionNumberFour()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 10);

        int thirdNumber = Random.Range(1, 10);
        int fourthNumber = Random.Range(1, 10);

        topValue = Mathf.Abs(firstNumber * secondNumber);
        bottomValue = Mathf.Abs(thirdNumber * fourthNumber);

        if (topValue > bottomValue)
        {
            correctValue = topValue;
        }
        else if (topValue < bottomValue)
        {
            correctValue = bottomValue;
        }
        else
        {
            FunctionNumberFour();
            return;
        }

        topText.text = firstNumber + " x " + secondNumber;
        bottomText.text = thirdNumber + " x " + fourthNumber;
    }
    void FunctionNumberFive()
    {
        int divisor1 = Random.Range(2, 10);
        topValue = Random.Range(2, 10);
        int dividend1 = divisor1 * topValue;

        int divisor2 = Random.Range(2, 10);
        bottomValue = Random.Range(2, 10);
        int dividend2 = divisor2 * bottomValue;

        if (topValue > bottomValue)
        {
            correctValue = topValue;
        }
        else if (topValue < bottomValue)
        {
            correctValue = bottomValue;
        }
        else
        {
            FunctionNumberFive();
            return;
        }

        topText.text = dividend1 + " / " + divisor1;
        bottomText.text = dividend2 + " / " + divisor2;


    }
    public void SetButtonValue(string buttonName)
    {
        if (buttonName == "topButton")
        {
            buttonValue = topValue;
        }
        else if (buttonName == "bottomButton")
        {
            buttonValue = bottomValue;
        }

        if (buttonValue == correctValue)
        {
            trueFalseManager.TrueFalse(true);
            totalScore += increaseAmount;
            audioSource.PlayOneShot(correctClip);
            scoreText.text = totalScore.ToString();
            correctAnswer++;
            circlesManager.CircleScaleUp(gameCount % 5);
            gameCount++;    
            GameStage();
        }
        else
        {
            trueFalseManager.TrueFalse(false);
            audioSource.PlayOneShot(wrongClip);
            wrongAnswer++;
            WrongAnswer();
        }
    }
    void WrongAnswer()
    {
        gameCount -= (gameCount % 5 + 5);

        if (gameCount < 0)
        {
            gameCount = 0;
        }
        GameStage();
        circlesManager.CircleScaleDown();
    }
    public void PausePanelActivate()
    {
        pausePanel.SetActive(true);
    }
    public void GameOver()
    {
        resultPanel.SetActive(true);
        audioSource.PlayOneShot(endClip);
        resultManager = Object.FindObjectOfType<ResultManager>();

        resultManager.ShowResults(correctAnswer,wrongAnswer,totalScore);
    }
}
