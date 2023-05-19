using System;
using UnityEngine;
using WebSocketSharp;
using StompHelper;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour
{
    
    public static NetworkManager instance;
    public string url = "ws://172.17.75.214:8080/ws";
    public string msgDesination = "/pub/hello";
    WebSocket ws;
    StompMessageSerializer serializer = new StompMessageSerializer();
    String clientId = "1";
    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetWebSocket(url);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetWebSocket(string url)
    {
        ws = new WebSocket(url);

        ws.OnOpen += ws_OnOpen;
        ws.OnMessage += ws_OnMessage;
        ws.OnError += ws_OnError;
        ws.OnClose += ws_OnClose;
        ws.Connect();
    }

    void ws_OnOpen(object sender, EventArgs e)
    {
        Debug.Log("ws_OnOpen says: " + e.ToString());
        ConnectStomp();
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
            Parse(msg.Body);
        }
    }
    
    void ws_OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log(DateTime.Now.ToString() + " ws_OnError says: " + e.ToString());
    }

    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("ws_OnClose says: " + e.ToString());
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

    private void SubscribeStomp()
    {
        var sub = new StompMessage(StompFrame.SUBSCRIBE);
        //unique Key per subscription
        sub["id"] = "sub-0"; 
        sub["destination"] = "/sub/channel/" + clientId;
        ws.Send(serializer.Serialize(sub));
    }

    void Parse(string json)
    {
        MessageData message = JsonUtility.FromJson<MessageData>(json);
    }

    public void SendMessage()
    {
        MessageData message = new MessageData();
        message.player = new PlayerData();
        string data_json = JsonUtility.ToJson(message);

       _SendMessage(data_json);
    }

    public void SendMessage(MessageData data)
    {
        string data_json = JsonUtility.ToJson(data);

        _SendMessage(data_json);
    }

    void _SendMessage(string data_json)
    {
        StompMessageBody body = new StompMessageBody();
        body.channelId = clientId;
        body.data = data_json;
        body.sender = clientId;
        body.type = StompFrame.SEND;
        string body_json = JsonUtility.ToJson(body);

        var pub = new StompMessage(StompFrame.SEND,body_json);
        pub["destination"] = msgDesination;
        ws.Send(serializer.Serialize(pub));
    }
}

[System.Serializable]
public class MessageData
{
    public PlayerData player; 
}

[System.Serializable]
public class PlayerData
{
    public bool isFirstPlayer = false;
    public int pig,cow,sheep;
    public int wheat,vegetable;
    public int wood,rock,reed,dirt;
    public int food,begging;
    public int family,fence,shed,room;
    public List<int> card_owns;
    public List<int> card_hands;
    public int Jobs {
        get         { return CountJobs(); }
        private set { ; }
    }

    int CountJobs()
    {
        // Count Job cars at card_owns
        return 0;
    }

    public void Init()
    {
        this.isFirstPlayer = false;
        this.pig = 0; this.cow = 0; this.sheep = 0;
        this.wheat = 0; this.vegetable = 0;
        this.wood = 0; this.rock = 0; this.reed = 0; this.dirt = 0;
        this.food = 3; this.begging = 0;
        this.family = 2; this.fence = 0; this.shed = 0; this.room = 2;
        this.card_owns = new List<int>();
        this.card_hands = new List<int>();
    }
}

[System.Serializable]
public class BoardData
{
    
}