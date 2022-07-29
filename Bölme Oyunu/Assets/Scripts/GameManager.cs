using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject karePrefab;
    [SerializeField] private Transform karePanel;
    [SerializeField] private Transform QuestionPanel;
    [SerializeField] private Text QuestionText;
    [SerializeField] private GameObject ResultPanel;

    List<int> numbersInSquares = new List<int>();

    private int dividend, divisor,answer;
    private int buttonValue;
    private int remainingHP;
    private int questionNumber;

    private string difficultySetting;

    private bool answerNow;


    [SerializeField] private AudioSource aSource;
    public AudioClip buttonSound;
    


    private GameObject currentSquare;
    private GameObject[] karelerDizisi = new GameObject[25];
    [SerializeField] private Sprite[] sprites;

    HpControl hp;
    PointsManager pmanager;
    private void Awake()
    {

        aSource = GetComponent<AudioSource>();
       remainingHP = 3;
        ResultPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
       hp = Object.FindObjectOfType<HpControl>();
       pmanager = Object.FindObjectOfType<PointsManager>();

        hp.CheckHealth(remainingHP);
    }
    void Start()
    {
        QuestionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        CreateBoxes();
        
        
    }
    void ButtonPressed()
    {
        if (answerNow)
        {
            aSource.PlayOneShot(buttonSound);
            buttonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);

            currentSquare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            CheckAnswer();
        }       
    }

    void CheckAnswer()
    {
        if (buttonValue == answer)
        {
            currentSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            currentSquare.transform.GetChild(0).GetComponent<Text>().text = "";
            currentSquare.transform.GetComponent<Button>().interactable = false;

            pmanager.AddPoints(difficultySetting);

            numbersInSquares.RemoveAt(questionNumber);

            Debug.Log(numbersInSquares.Count);
            if (numbersInSquares.Count > 0)
            {
                QuestionPanelOpen();
            }
            else
            {
                GameOver();

            }
        }

        else
        {
            remainingHP--;
            hp.CheckHealth(remainingHP);
        }

        if (remainingHP <= 0)
        {
            GameOver();
        }

    }
    public void CreateBoxes()
    {
        for (int i = 0; i < karelerDizisi.Length; i++)
        {
            GameObject kare = Instantiate(karePrefab, karePanel);

            kare.transform.GetChild(1).GetComponent<Image>().sprite = sprites[Random.Range(0,sprites.Length)];

            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButtonPressed());

            karelerDizisi[i] = kare;
        }
        ChangeText();
        StartCoroutine(Fade());
        Invoke("QuestionPanelOpen", 2f);
    }

    IEnumerator Fade()
    {
        foreach (var kares in karelerDizisi)
        {
            kares.GetComponent<CanvasGroup>().DOFade(1, 0.07f);

            yield return new WaitForSeconds(0.1f);
        }
    }

    void ChangeText()
    {
        foreach (var kare in karelerDizisi)
        {
            int randomNumber = Random.Range(1, 13);

            numbersInSquares.Add(randomNumber);

            kare.transform.GetChild(0).GetComponent<Text>().text = randomNumber.ToString();  
        }
    }
    void QuestionPanelOpen()
    {
        AskQuestion();
        answerNow = true;
        QuestionPanel.GetComponent<RectTransform>().DOScale(1, 0.6f).SetEase(Ease.OutBack);
    }

    void AskQuestion()
    {
        divisor = Random.Range(2, 11);
        questionNumber = Random.Range(0, numbersInSquares.Count);
        answer = numbersInSquares[questionNumber];
        dividend = answer * divisor;

        if (dividend <= 40)
        {
            difficultySetting = "easy";
        }
        else if (dividend > 40 && dividend <= 60)
        {
            difficultySetting = "medium";
        }
        else
        {
            difficultySetting = "hard";
        }

        QuestionText.text = (dividend.ToString() + " : " + divisor.ToString());
    }
    private void GameOver()
    {
        answerNow = false;
        ResultPanel.GetComponent<RectTransform>().DOScale(1, 0.6f).SetEase(Ease.OutBack);
    }
}


// soruyu sor olu?tur 
// rastgeke de?erlerini tutan bir liste olu?tur
// bölen say? 2,11 aras?