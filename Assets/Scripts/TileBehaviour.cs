using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileBehaviour : MonoBehaviour {

    private GameObject attachedObject;
    int[] GridPosition = new int[2];
    
    public Material Blocked;
    public Material Missed;
    public Material Hit;

	public void AttachToTile(GameObject TileAttachable)
    {
        if (TileAttachable != null)
        {
            attachedObject = TileAttachable;
        }
    }

    public bool IsTaken()
    {
        if (attachedObject != null)
            return true;
        return false;
    }

    public void SetGridPosition(int x, int y)
    {
        GridPosition[0] = x;
        GridPosition[1] = y;
    }

    public int[] GetGridPosition()
    {
        return GridPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString() + " collided");

        int MissileHit = GameObject.Find("AI").GetComponent<AIBehaviour>().ReceiveMissile(GridPosition[0], GridPosition[1]);

        Material currentMat = GetComponent<MeshRenderer>().material;
        IngameCanvas cv = GameObject.Find("In-Game Canvas").GetComponent<IngameCanvas>();
        switch (MissileHit)
        {
            case -1:
                {

                    GetComponent<MeshRenderer>().material = Blocked;
                    break;
                }
            case 0:
                {

                    GetComponent<MeshRenderer>().material = Missed;
                    break;
                }
            case 1:
                {
                    GetComponent<MeshRenderer>().material = Hit;
                    break;
                }
        }
        print("Missile hit: " + MissileHit);
    }
}
