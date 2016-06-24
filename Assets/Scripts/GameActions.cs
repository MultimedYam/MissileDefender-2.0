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
    public bool gameStarted = false;

    int TotalTiles;
    int activeTurret = 0;

    public GameObject inComingProjectile;

    void Start()
    {
        _WBScript = _WorldBuilder.GetComponent<WorldBuilder>();

    }

	public void StartGame()
    {
        gameStarted = true;

        TotalTiles = _WorldBuilder.GetComponent<WorldBuilder>().TotalTiles;
        if (DefenseTowers.Count > 0)
        {
            ActiveTurret = DefenseTowers[activeTurret].transform.Find("TurretHousing").gameObject;
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
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                print("Projectile Spawned");
                ActiveTurret.GetComponent<TurretFiringBehaviour>().FireProjectile();
//                Player.GetComponent<MessageBehaviour>().SendProjectileFired();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                ActiveTurret.GetComponent<TurretFiringBehaviour>().ChangeProjectile();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                activeTurret = ++activeTurret % DefenseTowers.Count;
                ActiveTurret.transform.FindChild("TurretCamera").gameObject.SetActive(false);
                ActiveTurret = DefenseTowers[activeTurret].transform.Find("TurretHousing").gameObject;
                ActiveTurret.transform.FindChild("TurretCamera").gameObject.SetActive(true);
            }


        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Launch Incoming");
            LaunchIncomingProjectile(Random.Range(TotalTiles/ 2, TotalTiles));
        }
    }

    public void LaunchIncomingProjectile(int DestPos)
    {
        int actualDestination = TotalTiles - DestPos;
        int actualSource = Random.Range(TotalTiles / 2, TotalTiles);

        Vector3 source = _WorldBuilder.GetComponent<WorldBuilder>().GetTileByPosition(actualSource).position;
        print("Source set.");
        Transform destination = _WorldBuilder.GetComponent<WorldBuilder>().GetTileByPosition(actualDestination);
        print("Destination set.");
        GameObject incomingObject = Instantiate(inComingProjectile, source, Quaternion.identity) as GameObject;
        incomingObject.transform.LookAt(destination);
    }

    public Camera getActiveCamera()
    {
        return ActiveTurret.transform.FindChild("TurretCamera").GetComponent<Camera>();
    }
}
