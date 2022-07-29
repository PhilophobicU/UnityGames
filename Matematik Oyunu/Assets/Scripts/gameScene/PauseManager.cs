using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void ReturnGame()
    {
        pausePanel.SetActive(false);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("menuLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
