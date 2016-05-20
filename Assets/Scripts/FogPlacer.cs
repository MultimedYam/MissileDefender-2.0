using UnityEngine;
using System.Collections;

public class FogPlacer : MonoBehaviour {

    public GameObject _WorldBuilder;
    WorldBuilder builderScript;
    

    // Use this for initialization
    void Start ()
    {
        builderScript = _WorldBuilder.GetComponent<WorldBuilder>();

        transform.localScale = new Vector3(transform.localScale.x * builderScript.GridX, transform.localScale.y * 1, transform.localScale.z * (builderScript.GridY - Mathf.CeilToInt(builderScript.GridY / 2)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(builderScript.GetLastTilePosition().x / 2,
                                                                                                                     0.01f,
                                        (builderScript.GetTilePosition(0, Mathf.CeilToInt(builderScript.GridY / 2)).z + builderScript.GetLastTilePosition().z) / 2);
    }
}
