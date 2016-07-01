using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IngameCanvas : MonoBehaviour {

    public GameObject GameManager;
    public Text SelectedTurret;
    public Text SelectedProjectile;
    public Text CitiesLeft;

    public Text Notification;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.GetComponent<GameActions>().gameStarted)
        {
            Canvas canvas = GetComponent<Canvas>();
            canvas.enabled = true;
            canvas.worldCamera = GameManager.GetComponent<GameActions>().getActiveCamera();
            canvas.planeDistance = 0.02f;

            SelectedTurret.text = GameManager.GetComponent<GameActions>().activeTurret.ToString();
            SelectedProjectile.text = GameManager.GetComponent<GameActions>().ActiveTurret.GetComponent<TurretFiringBehaviour>().selectedProjectile.ToString();

            CitiesLeft.text = GameManager.GetComponent<GameActions>().Cities.Count.ToString();

        }
	}

    public void SetNotificationText(string text)
    {

    }
}
