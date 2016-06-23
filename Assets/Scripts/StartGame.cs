using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System.Collections;

public class StartGame : NetworkBehaviour
{

    const short StartMessage = 1100;


    public bool OtherPlayerReadyState;
    public bool PlayerReadyState;

    NetworkClient m_client;

    void Awake()
    {
        if (NetworkManager.singleton.client != null)
        Init(NetworkManager.singleton.client);
    }

    void Update()
    {
        if (PlayerReadyState == true && OtherPlayerReadyState == true)
        {
            //Continue to game screen
            //GameActions.StartGame
            GameActions Actor = GameObject.Find("Game Manager").GetComponent<GameActions>();

            if( Actor.gameStarted == false)
            {
                Actor.StartGame();
            }
        }
    }

    public void Init(NetworkClient client)
    {
        m_client = NetworkManager.singleton.client;
        if (m_client.isConnected)
        {
            NetworkServer.RegisterHandler(StartMessage, OnClientReadyToBegin);
        }
    }

    public void SendReadyToBeginMessage()
    {
        var Startmsg = new IntegerMessage(NetworkManager.singleton.client.connection.connectionId);
        NetworkManager.singleton.client.Send(StartMessage, Startmsg);
    }

    void OnClientReadyToBegin(NetworkMessage netMsg)
    {
        var startMessage = netMsg.ReadMessage<IntegerMessage>();
        
        if(startMessage.value != NetworkManager.singleton.client.connection.connectionId)
        {
            OtherPlayerReadyState = !OtherPlayerReadyState;

            Debug.Log("Player: " + startMessage.value + " changed ready state to: " + OtherPlayerReadyState.ToString());
        }
        else
        {
            PlayerReadyState = !PlayerReadyState;
            Debug.Log("Player: " + startMessage.value + " changed ready state to: " + PlayerReadyState.ToString());
        }
    }
}
