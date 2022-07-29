using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
   public void Restart()
    {
        SceneManager.LoadScene("gameLevel");
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
