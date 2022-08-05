using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    int timeC;
    bool time;
    void Start()
    {
        time = true;
        timeC = 90;
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (time)
        {
            yield return new WaitForSeconds(1f);

            

            if (timeC < 10)
            {
                timeText.text = "0" + timeC.ToString();
            }
            else
            {
                timeText.text = timeC.ToString();
            }

            if (timeC <= 0)
            {
                time = false;
                timeText.text = "";
            }
            timeC--;
        }
    }
   
}
