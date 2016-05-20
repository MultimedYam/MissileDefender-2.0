using UnityEngine;
using System.Collections;

public class GameInputManager : MonoBehaviour
{
    public Material UnselectedMaterial;
    public Material SelectedMaterial;


    RaycastHit hit;
    void Start()
    {
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.tag == "Tile")
                hit.transform.GetComponent<MeshRenderer>().material = SelectedMaterial;
        }
          
    }

    public Transform GetRayHit()
    {
        return hit.transform;
    }
}