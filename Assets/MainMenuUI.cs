using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

	// Use this for initialization
	public void StartAIGame()
    {
        SceneManager.LoadScene("StrategicPlacement");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
