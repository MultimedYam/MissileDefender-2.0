using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour {

    private GameObject attachedObject;

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
}
