using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ViewBehaviour : MonoBehaviour
{
    public GameObject LobbyManager;

    private NetworkLobbyManager manager;
	
    void Start()
    {
        if (LobbyManager != null)
        {
            manager = LobbyManager.GetComponent<NetworkLobbyManager>();
        }
    }

    public void Host()
    {
        manager.StartHost();
    }

    public void Join()
    {
        manager.StartClient();
    }
}
