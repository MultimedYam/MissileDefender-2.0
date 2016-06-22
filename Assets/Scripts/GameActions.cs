using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameActions : MonoBehaviour {

    public List<GameObject> DefenseTowers = new List<GameObject>();
    public List<GameObject> Cities = new List<GameObject>();
    public GameObject Player;
    public GameObject ActiveTurret;
    public GameObject _WorldBuilder;
    private WorldBuilder _WBScript;
    private bool gameStarted = false;

    public GameObject inComingProjectile;

    void Start()
    {
        _WBScript = _WorldBuilder.GetComponent<WorldBuilder>();
    }

	public void StartGame()
    {
        gameStarted = true;
        if (DefenseTowers.Count > 0)
        {
            ActiveTurret = DefenseTowers[0].transform.Find("TurretHousing").gameObject;
            ActiveTurret.transform.FindChild("TurretCamera").gameObject.SetActive(true);
            
        }

        int middleTile = Mathf.CeilToInt(_WBScript.TotalTiles/2);

        for (int i = middleTile; i < _WBScript.TotalTiles; i++)
        {
            GameObject selectedTile = _WBScript.WorldGrid[i];
            selectedTile.transform.position = new Vector3(selectedTile.transform.position.x, 10, selectedTile.transform.position.z);
            selectedTile.transform.Rotate(new Vector3(180, 0, 0));
        }

    }

    void Update()
    {
        if (gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("Projectile Spawned");
                ActiveTurret.GetComponent<TurretFiringBehaviour>().FireProjectile();
                Player.GetComponent<MessageBehaviour>().SendProjectileFired();
            }
        }
    }

    public void LaunchIncomingProjectile(int DestPos)
    {
        int TotalTiles = _WorldBuilder.GetComponent<WorldBuilder>().TotalTiles / 2;
        int actualDestination = DestPos - TotalTiles;
        int actualSource = Random.Range(TotalTiles / 2, TotalTiles);

        Vector3 source = _WorldBuilder.GetComponent<WorldBuilder>().GetTileByPosition(actualSource).position;
        Transform destination = _WorldBuilder.GetComponent<WorldBuilder>().GetTileByPosition(actualDestination);
        GameObject incomingObject = Instantiate(inComingProjectile, source, Quaternion.identity) as GameObject;
        incomingObject.transform.LookAt(destination);
    }
}
