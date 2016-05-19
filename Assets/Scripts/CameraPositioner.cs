using UnityEngine;
using System.Collections;

public class CameraPositioner : MonoBehaviour
{
    public GameObject _WorldBuilder;
    WorldBuilder builderScript;

    private Vector3 CameraPosition;
    void Start()
    {
        builderScript = _WorldBuilder.GetComponent<WorldBuilder>();
    }

    void Update()
    {
        Vector3 derivedPositions = builderScript.GetLastTilePosition();
        CameraPosition = new Vector3(derivedPositions.x / 2, derivedPositions.z, derivedPositions.z / 2);
        transform.position = CameraPosition;
    }
}
