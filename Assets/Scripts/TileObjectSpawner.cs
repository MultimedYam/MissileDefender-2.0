using UnityEngine;
using System.Collections;

public class TileObjectSpawner : MonoBehaviour {

    public GameObject GameManager;

    public GameObject City;
    public GameObject Turret;


    private int CitiesSpawned = 0;
    private int DefenseSpawned = 0;
    private GameObject spawn = null;
    private Vector3 pos;
    private Transform hit;

    // Update is called once per frame
    void Update ()
    {
        pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y = 0;


        hit = GetComponent<GameInputManager>().GetRayHit();
    }

    public void MoveTileObject()
    {
        if (spawn != null)
            spawn.transform.position = pos;
    }

    public void SpawnCity()
    {
        if (CitiesSpawned != GameManager.GetComponent<GameAttributes>().MaxAllowedCities)
        {
            spawn = Instantiate(City, pos, Quaternion.identity) as GameObject;
        }
    }

    public void SpawnTurret()
    {
        if (DefenseSpawned != GameManager.GetComponent<GameAttributes>().MaxAllowedDefense)
        {
            spawn = Instantiate(Turret, pos, Quaternion.identity) as GameObject;
        }
    }

    public void DropTileObject()
    {
        print("Placed City");


        if (hit != null && hit.tag == "Tile")
        {
            if (hit.GetComponent<TileBehaviour>().IsTaken() == false)
            {
                hit.GetComponent<TileBehaviour>().AttachToTile(spawn);
                spawn.transform.position = hit.transform.position;

                switch (spawn.transform.tag)
                {
                    case "City":
                        {
                            spawn.transform.SetParent(GameManager.transform.Find("SpawnedCities"));
                            GameManager.GetComponent<GameActions>().Cities.Add(spawn);
                            CitiesSpawned++;
                            spawn = null;
                            return;
                        }
                    case "Defense":
                        {
                            spawn.transform.SetParent(GameManager.transform.Find("SpawnedDefense"));
                            GameManager.GetComponent<GameActions>().DefenseTowers.Add(spawn);
                            DefenseSpawned++;
                            spawn = null;
                            return;
                        }
                }

                return;
            }
        }
        else if (hit == null)
        {
            if (spawn != null)
                Destroy(spawn);
        }
    }
}
