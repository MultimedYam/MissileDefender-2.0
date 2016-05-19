using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    private bool ready = false;

    public int MaxCities = 3;
    public int MaxDefence = 3;

	public bool IsReady()
    {
        return ready;
    }

    public void ToggleReady()
    {
        ready = !ready;
    }
}
