using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldBuilder : MonoBehaviour {

    [Range(5,10)]
    public int GridX;
    [Range(5, 10)]
    public int GridY;
    [Range(0, 1)]
    public float Padding;

    public int TotalTiles { get; private set; }

    public GameObject GridTile;
    public List<GameObject> WorldGrid;

    [HideInInspector]
    public GameObject TileHolder;

	// Use this for initialization
	void Start ()
    {
	    for (int Y = 0; Y < GridY; Y++)
        {
            for (int X = 0; X < GridX; X++)
            {
                var Tile = (GameObject)Instantiate(GridTile, new Vector3(X + (X * Padding), 0, Y + (Y * Padding)), Quaternion.identity);
                WorldGrid.Add(Tile);
                TotalTiles++;
                Tile.transform.SetParent(TileHolder.transform);

                Tile.GetComponent<TileBehaviour>().SetGridPosition(X, Y);
            }
        }
	}
	
	public Vector3 GetFirstTilePosition()
    {
        if (WorldGrid.Count > 0)
            return WorldGrid[0].transform.position;

        return Vector3.zero;
    }

    public Vector3 GetLastTilePosition()
    {
        if (WorldGrid.Count > 0)
            return WorldGrid[WorldGrid.Count - 1].transform.position;

        return Vector3.zero;
    }

    public Vector3 GetTilePosition(int x, int y)
    {
        if (WorldGrid.Count > 0)
        {
            return WorldGrid[x+(y*GridX)].transform.position;
        }

        return Vector3.zero;
    }

    public Transform GetTileByPosition(int position)
    {
        return WorldGrid[position - 1].transform;
    }
}
