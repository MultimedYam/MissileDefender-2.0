using UnityEngine;
using System.Collections;

public class MouseTileBehaviour : MonoBehaviour
{
    public Material del;


    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = del;
    }
}
