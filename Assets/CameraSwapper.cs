using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSwapper : MonoBehaviour
{
    public List<Camera> CameraList = new List<Camera>();

    public Camera ActiveCamera;
    int CurrentCam = 0;
    
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (GameObject CameraObj in GameObject.FindGameObjectsWithTag("Camera"))
        {
            print("Camera");
            CameraList.Add(CameraObj.GetComponent<Camera>());
        }

        for (int i = 0; i < CameraList.Count; i++)
        {
            if (CurrentCam == i)
            {
                CameraList[CurrentCam].gameObject.SetActive(true);
            }
            else
            {
                CameraList[CurrentCam].gameObject.SetActive(false);
            }
        }
	}

    public void Next()
    {
        CurrentCam++;
    }
}
