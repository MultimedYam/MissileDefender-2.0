using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class MessageBehaviour : NetworkBehaviour
{
    [SerializeField]
    public NetworkClient client;

    public GameObject NetworkManager;   
    NetworkLobbyManager lobbymanager;

    const short ReadyMsg = 1001;
    const short ProjectileMsg = 1002;


    void Start()
    {
        NetworkManager = GameObject.Find("Lobby Manager");
        lobbymanager = NetworkManager.GetComponent<NetworkLobbyManager>();
        SetupClient(lobbymanager.client);
    }

    public void SetupClient(NetworkClient _client)
    {
        if (_client != null)
        {
            client = _client;

            if (client.isConnected)
            {
                NetworkServer.RegisterHandler(ReadyMsg, OnReadyReceived);
                NetworkServer.RegisterHandler(ProjectileMsg, OnProjectileFiredReceived);

                Debug.Log("Connected to " + client.serverIp);
            }
        }
    }

    public void SendReadyToStart()
    {
        var msg = new EmptyMessage();
        client.Send(ReadyMsg, msg);
    }

    public void SendProjectileFired()
    {
        var msf = new StringMessage("Projectile Fired");
        client.Send(ProjectileMsg, msf);
    }

    void OnReadyReceived(NetworkMessage netMsg)
    {
        var ReadyMessage = netMsg.ReadMessage<EmptyMessage>();
        Debug.Log("Player is Ready to proceed" + ReadyMessage);
    }

    void OnProjectileFiredReceived(NetworkMessage netMsg)
    {
        var ProjectileMessage = netMsg.ReadMessage<StringMessage>();
        Debug.Log("Network Message: " + ProjectileMessage);
    }

}
