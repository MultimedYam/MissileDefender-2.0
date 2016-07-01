using UnityEngine;
using System.Collections;

public class MouseTileBehaviour : MonoBehaviour
{
    public Material del;

    GameObject GM;

    void Start()
    {
        GM = GameObject.Find("Game Manager");
    }

    void OnMouseExit()
    {
        if (GM.GetComponent<GameActions>().gameStarted != true)
        {
            GetComponent<MeshRenderer>().material = del;
        }
    }
}
