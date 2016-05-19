using UnityEngine;
using System.Collections;

public class TileObjectSpawner : MonoBehaviour {

    public GameObject City;
    public GameObject Turret;

    private GameObject spawn = null;
    private Vector3 pos;
	
	// Update is called once per frame
	void Update ()
    {
        pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y = 0;
    }

    public void MoveTileObject()
    {
        print("Move city");
        spawn.transform.position = pos;
    }

    public void SpawnCity()
    {
        print("Spawn City");
        spawn = Instantiate(City, pos, Quaternion.identity) as GameObject;
    }

    public void SpawnTurret()
    {
        spawn = Instantiate(Turret, pos, Quaternion.identity) as GameObject;
    }

    public void DropTileObject()
    {
        print("Placed City");
        Transform hit = GetComponent<GameInputManager>().GetRayHit();
        
        if (hit.tag == "Tile")
        {
            if (hit.GetComponent<TileBehaviour>().IsTaken() == false)
            {
                hit.GetComponent<TileBehaviour>().AttachToTile(spawn);
                spawn.transform.position = hit.transform.position;
                return;
            }
        }

        Destroy(spawn);
        spawn = null;
    }
}
