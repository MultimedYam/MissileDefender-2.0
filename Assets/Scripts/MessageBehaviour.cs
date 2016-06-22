using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class MessageBehaviour : NetworkBehaviour
{
    [SerializeField]
    public static NetworkClient client;

    public GameObject _NetworkManager;
    public GameObject GameActor;

    const short ReadyMsg = 1001;
    const short ProjectileMsg = 1002;

    const short TileHitMsg = 1003;


    void Start()
    {
        _NetworkManager = GameObject.Find("Lobby Manager");
        GameActor = GameObject.Find("Game Manager");
    }

    void LateUpdate()
    {
        client = _NetworkManager.GetComponent<NetworkManager>().client;
        if (client != null)
        {
            SetupClient(client);
            print(client.ToString());
        }
    }

    public void SetupClient(NetworkClient _client)
    {
        if (_client != null)
        {
            client = _client;
            print("Client set.");

            if (client.isConnected)
            {
                NetworkServer.RegisterHandler(ReadyMsg, OnReadyReceived);
                NetworkServer.RegisterHandler(ProjectileMsg, OnProjectileFiredReceived);
                NetworkServer.RegisterHandler(TileHitMsg, OnTileHitReceived);
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

    public void ProjecTileHit(int x, int y)
    {
        var Destination = new IntegerMessage(x*y);
        client.Send(TileHitMsg, Destination);

    }

    public void OnTileHitReceived(NetworkMessage incomingMessage)
    {
        var TileHitMessage = incomingMessage.ReadMessage<IntegerMessage>();
        GameActor.GetComponent<GameActions>().LaunchIncomingProjectile(TileHitMessage.value);
    }
    void OnReadyReceived(NetworkMessage netMsg)
    {
        var ReadyMessage = netMsg.ReadMessage<EmptyMessage>();
        Debug.Log("Player is Ready to proceed" + ReadyMessage);
    }

    void OnProjectileFiredReceived(NetworkMessage netMsg)
    {
        var ProjectileMessage = netMsg.ReadMessage<StringMessage>();
        Debug.Log("Network Message: " + ProjectileMessage.value);
    }

}
