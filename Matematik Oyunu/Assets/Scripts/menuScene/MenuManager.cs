using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform Brain;
    [SerializeField] private Transform StartBtn;
    void Start()
    {
        Brain.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        StartBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-230f,1f).SetEase(Ease.OutBack);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("gameLevel");
    }
}
