using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timer;
    [SerializeField] private int time = 90;
    private bool timePass;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        timer.text = time.ToString();
        timePass = true;
        
    }
    public void TimerStart()
    {
        StartCoroutine(TimerDown());
    }
    private IEnumerator TimerDown()
    {
       

        while (timePass)
        {
            
  
            if (time <= 9)
            { 
                timer.text = "0" + time.ToString();
            }
            else
            {
                timer.text = time.ToString();
            }

            if (time == 0)
            {
                timePass = false;
                gameManager.GameOver();
            }
            yield return new WaitForSeconds(1);
            time--;

        }
    }
}
