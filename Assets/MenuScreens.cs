using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScreens : MonoBehaviour
{
    public Text TitleText;
    public GameObject WinLossPanel;

    public GameObject PausePanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }
	public void WinScreen()
    {
        WinLossPanel.SetActive(true);
        TitleText.text = "YOU WON!";
        Time.timeScale = 0;
    }

    public void LossScreen()
    {
        WinLossPanel.SetActive(true);
        TitleText.text = "YOU LOST.";
        Time.timeScale = 0;
    }

    public void PauseScreen()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePauseScreen()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
