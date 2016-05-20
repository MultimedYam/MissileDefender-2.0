using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour {

    private GameObject attachedObject;
    int[] GridPosition = new int[2];

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
}
