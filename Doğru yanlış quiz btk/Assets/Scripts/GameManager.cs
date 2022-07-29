using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    resultManager rresultManeger;

    private Question currentQuestion;
    public Question[] questions;
    public static List<Question> unansweredQuestions;

    [SerializeField] private Text QuestionText;
    [SerializeField] private Text correctValue, wrongValue;
    [SerializeField] private GameObject correctButton, wrongButton;
    [SerializeField] private GameObject resultPanel;

    private int correctCount, wrongCount,totalPoints;
    void Start()
    {
        if ((unansweredQuestions == null) || (unansweredQuestions.Count == 0))
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        PickRandomQuestion();
        Debug.Log("Current Question is : " + currentQuestion.question + " and its answer is " + currentQuestion.isTrue);
    }
    void PickRandomQuestion()
    {
        wrongButton.GetComponent<RectTransform>().DOLocalMoveX(320f, .2f);
        correctButton.GetComponent<RectTransform>().DOLocalMoveX(-320f, .2f);

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        QuestionText.text = currentQuestion.question;
        Debug.Log(currentQuestion.isTrue);
        if (currentQuestion.isTrue)
        {
            correctValue.text = "Dogru bildiniz";
            wrongValue.text = "Yanlis bildiniz";
        }
        else
        {
            correctValue.text = "Yanlis bildiniz";
            wrongValue.text = "Dogru bildiniz";
        }
    }
    public void CorrectButton()
    {
        if (currentQuestion.isTrue)
        {
            correctCount++;
            totalPoints += 100;
        }
        else
        {
            wrongCount++;
        }
        wrongButton.GetComponent<RectTransform>().DOLocalMoveX(1000f, .2f);
        StartCoroutine(WaitAfterQuestionAnswered());
    }
    public void WrongButton()
    {
        if (!currentQuestion.isTrue)
        {
            correctCount++;
            totalPoints += 100;
        }
        else
        {
            wrongCount++;
        }
        correctButton.GetComponent<RectTransform>().DOLocalMoveX(-1000f, .2f);
        StartCoroutine(WaitAfterQuestionAnswered());
    }
    IEnumerator WaitAfterQuestionAnswered()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(1f);

        if (unansweredQuestions.Count <= 0)
        {
            resultPanel.SetActive(true);
            rresultManeger = Object.FindObjectOfType<resultManager>();
            rresultManeger.Results(correctCount, wrongCount, totalPoints);
        }
        else
        {
            PickRandomQuestion();
        }
        
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
