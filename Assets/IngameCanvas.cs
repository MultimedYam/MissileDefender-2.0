using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IngameCanvas : MonoBehaviour {

    public GameObject GameManager;
    public Text SelectedTurret;
    public Text SelectedProjectile;
    public Text CitiesLeft;
    public Text TurretsLeft;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.GetComponent<GameActions>().gameStarted)
        {
            GetComponent<Canvas>().worldCamera = GameManager.GetComponent<GameActions>().getActiveCamera();

            SelectedTurret.text = GameManager.GetComponent<GameActions>().activeTurret.ToString();
            SelectedProjectile.text = GameManager.GetComponent<GameActions>().ActiveTurret.GetComponent<TurretFiringBehaviour>().selectedProjectile.ToString();

            CitiesLeft.text = GameManager.GetComponent<GameActions>().Cities.Count.ToString();
            TurretsLeft.text = GameManager.GetComponent<GameActions>().DefenseTowers.Count.ToString();

        }
	}
}
