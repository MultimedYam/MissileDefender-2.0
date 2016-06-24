using UnityEngine;
using System.Collections;

public class IngameCanvas : MonoBehaviour {

    public GameObject GameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.GetComponent<GameActions>().gameStarted)
        {
            GetComponent<Canvas>().worldCamera = GameManager.GetComponent<GameActions>().getActiveCamera();
        }
	}
}
