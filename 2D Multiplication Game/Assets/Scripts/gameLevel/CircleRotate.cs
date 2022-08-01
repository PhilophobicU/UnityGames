using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleRotate : MonoBehaviour
{
    GameManager gm;
    string _result;
    private void Awake()
    {
        gm = Object.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }

            if (gameObject.name == "leftOutline")
            {
                _result = GameObject.Find("leftQuestionText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "middleOutline")
            {
                _result = GameObject.Find("middleQuestionText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "rightOutline")
            {
                _result = GameObject.Find("rightQuestionText").GetComponent<Text>().text;
            }
        }
        gm.CheckResult(int.Parse(_result));
    }
}
