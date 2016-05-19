using UnityEngine;
using System.Collections;

public class ConsumableSpawner : MonoBehaviour
{

    Vector3 mousePosition, targetPosition;

    //To Instantiate TargetObject at mouse position
    public GameObject targetObject;

    float distance = 10f;

    public void SpawnCity()
    {
        while (Input.GetMouseButtonDown(0))
        {
            //To get the current mouse position
            mousePosition = Input.mousePosition;

            //Convert the mousePosition according to World position
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));

            //Set the position of targetObject
            targetObject.transform.position = targetPosition;

            if (Input.GetMouseButtonUp(0))
            {
                //create the instance of targetObject and place it at given position.
                Instantiate(targetObject, targetObject.transform.position, targetObject.transform.rotation);
            }
        }
    }
}