using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class serverScript : MonoBehaviour
{
    public bool isAtStartup = true;
    public int xyz = 0;
    public static NetworkClient myClient;
    public static short Message = 12355;



    // Use this for initialization
    void Start()
    {
        SetupServer();
        SetupLocalClient();

    }

    // Update is called once per frame
    void Update()
    {
    }

    // Create a server and listen on a port
    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        isAtStartup = false;
    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.RegisterHandler(serverScript.Message, OnMessage);
        myClient.Connect("145.24.190.187", 4444);
        isAtStartup = false;
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.RegisterHandler(serverScript.Message, OnMessage);
        isAtStartup = false;
    }
    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
    public void OnMessage(NetworkMessage netMsg)
    {
        StringMessage sm = netMsg.ReadMessage<StringMessage>();
        Debug.Log("OnScoreMessage " + sm.value);

        if (sm.value == "Achterkant")
        {
            Debug.Log("Achterkant disabled");

            GameObject go1 = GameObject.Find("Voorkant1");
            go1.active = false;
            GameObject go2 = GameObject.Find("Achterkant1");
            go2.active = true;
            GameObject go3 = GameObject.Find("Voorkant2");
            go3.active = false;
            GameObject go4 = GameObject.Find("Achterkant2");
            go4.active = true;
        }
        else if (sm.value == "Voorkant")
        {
            Debug.Log("Voorkant disabled");

            GameObject go1 = GameObject.Find("Voorkant1");
            go1.active = true;
            GameObject go2 = GameObject.Find("Achterkant1");
            go2.active = false;
            GameObject go3 = GameObject.Find("Voorkant2");
            go3.active = true;
            GameObject go4 = GameObject.Find("Achterkant2");
            go4.active = false;

        }
    }
}