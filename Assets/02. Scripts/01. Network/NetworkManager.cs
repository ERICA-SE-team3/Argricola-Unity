using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using StompHelper;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    WebSocket ws;
    StompMessageSerializer serializer = new StompMessageSerializer();
    String clientId = "1";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("NetworkManager Start");
        ws = new WebSocket("ws://172.17.75.214:8080/ws");

        ws.OnMessage += ws_OnMessage;
        ws.OnClose += ws_OnClose;
        ws.OnOpen += ws_OnOpen;
        ws.OnError += ws_OnError;
        ws.Connect();
        Debug.Log("NetworkManager Start End");
    }

    void ws_OnOpen(object sender, EventArgs e)
    {
        Debug.Log("ws_OnOpen says: " + e.ToString());
        ConnectStomp();
    }
    private void ConnectStomp()
    {
        var connect = new StompMessage(StompFrame.CONNECT);
        connect["accept-version"] = "1.2";
        connect["host"] = "";
        // first number Zero mean client not able to send Heartbeat, 
        //Second number mean Server will sending heartbeat to client instead
        connect["heart-beat"] = "0,10000";
        ws.Send(serializer.Serialize(connect));
    }

    void ws_OnMessage(object sender, MessageEventArgs e)
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine(" ws_OnMessage says: " + e.Data);
        StompMessage msg = serializer.Deserialize(e.Data);
        if (msg.Command == StompFrame.CONNECTED)
        {
            Debug.Log(e.Data);
            SubscribeStomp();
        }
        else if (msg.Command == StompFrame.MESSAGE)
        {
            Debug.Log(e.Data);
        }
    }
    private void SubscribeStomp()
    {
        var sub = new StompMessage(StompFrame.SUBSCRIBE);
        //unique Key per subscription
        sub["id"] = "sub-0"; 
        sub["destination"] = "/sub/channel/" + clientId;
        ws.Send(serializer.Serialize(sub));

        // var sub1 = new StompMessage(StompFrame.SUBSCRIBE);
        // //unique Key per subscription
        // sub1["id"] = "sub-1";
        // sub1["destination"] = "/queue/message-" + clientId;
        // ws.Send(serializer.Serialize(sub1));
    }

    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("ws_OnClose says: " + e.ToString());
        ConnectStomp();
    }

     void ws_OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log(DateTime.Now.ToString() + " ws_OnError says: " + e.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Serialize()
    {

    }



    void Parse(string json)
    {
        GameMessage message = JsonUtility.FromJson<GameMessage>(json);
    }

    public void SendMessage()
    {
        GameMessage message = new GameMessage();
        message.brick = 1;
        string json = JsonUtility.ToJson(message);

        StompMessageBody body = new StompMessageBody();
        body.channelId = clientId;
        body.data = json;
        body.sender = clientId;
        body.type = StompFrame.SEND;
        string body_json = JsonUtility.ToJson(body);

        var pub = new StompMessage(StompFrame.SEND,body_json);
        pub["destination"] = "/pub/hello";
        ws.Send(serializer.Serialize(pub));
    }
}

[System.Serializable]
public class StompMessageBody
{
    public string data;
    public string type;
    public string channelId;
    public string sender;
}

[System.Serializable]
public class GameMessage
{
    public int brick;
}
