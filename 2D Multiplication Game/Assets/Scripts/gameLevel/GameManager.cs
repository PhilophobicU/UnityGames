using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startImage;
    [SerializeField] private Text questionText,leftCircleText,middleCircleText,rightCircleText,correctTxt,wrongTxt,scoreTxt;
    string sceneLayout;
    int correctC,wrongC,scoreC;
    int firstNm;
    int secondNm;
    int result,falseResult1,falseResult2;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("buttonScene"))
        {
            sceneLayout = PlayerPrefs.GetString("buttonScene");
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
        Question();
    }
    
    void Fenn()
    {
        switch (sceneLayout)
        {
            case "iki":
                firstNm = 2;
                break;
            case "uc":
                firstNm = 3;
                break;
            case "dort":
                firstNm = 4;
                break;
            case "bes":
                firstNm = 5;
                break;
            case "alti":
                firstNm = 6;
                break;
            case "yedi":
                firstNm = 7;
                break;
            case "sekiz":
                firstNm = 8;
                break;
            case "dokuz":
                firstNm = 9;
                break;
            case "mix":
                firstNm = Random.Range(2,10);
                break;
        }
    }
    void Question()
    {
        Fenn();
        secondNm = Random.Range(2,10);
        result = firstNm * secondNm;
        int random = Random.Range(1,100);
        if (random <= 50)
        {
            questionText.text = firstNm.ToString() + " x " + secondNm.ToString();
        }
        else
        {
            questionText.text = secondNm.ToString()+ " x " + firstNm.ToString();
        }
        ResultToText();
    }

    void ResultToText()
    {
        falseResult1 = result - Random.Range(2, 10);

        if (result > 10)
        {
            falseResult2 = result - Random.Range(2, 8);
        }
        else
        {
            falseResult2 = Mathf.Abs(result - Random.Range(1, 5));
        }







        int random = Random.Range(1,100);
        
        if (random <= 33)
        {
            leftCircleText.text = result.ToString();
            middleCircleText.text = falseResult1.ToString();
            rightCircleText.text = falseResult2.ToString();

        }
        else if (random > 33 && random < 66)
        {
            leftCircleText.text = falseResult1.ToString();
            middleCircleText.text = result.ToString();
            rightCircleText.text = falseResult2.ToString();
        }
        else
        {
            leftCircleText.text = falseResult1.ToString();
            middleCircleText.text = falseResult2.ToString();
            rightCircleText.text = result.ToString();
        }
    }
    public void CheckResult(int textResult)
    {
        if (textResult == result)
        {
            correctC++;
            scoreC += 20;
        }
        else
        {
            wrongC++;
        }
        correctTxt.text = correctC.ToString() + " DOGRU";
        wrongTxt.text = wrongC.ToString() + " YANLIS";
        scoreTxt.text = scoreC.ToString() + " PUAN";
        Question();
    }
}
