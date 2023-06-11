using System;
using UnityEngine;
using WebSocketSharp;
using StompHelper;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    public bool isDebuging = false;
    public string url = "ws://172.17.75.214:8080/ws";
    public string debugUrl = "ws://172.17.75.214:8080/ws";
    public string readyMsgDest = "/pub/hello";
    public string playMsgDest = "/pub/play";

    WebSocket ws;
    StompMessageSerializer serializer = new StompMessageSerializer();
    String clientId = "1";

    public int playerId = -1;
    GameObject lobbyObj;
    LobbySceneManager lobby;
    
    public void Awake() {
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
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        lobbyObj = GameObject.Find("LobbySceneManager");
        lobby = lobbyObj.GetComponent<LobbySceneManager>();
        // SetWebSocket(url);
        // Parse("{\"type\": \"userCountCheck\", \"sender\": \"server\", \"channelId\": \"1\", \"data\": \"{\"userCount\":1}\"}");
    }

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            Application.Quit();
        }
    }
    
    public void SetWebSocket()
    {
        SetWebSocket(url);
    }

    public void SetWebSocket(string url)
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
            // Debug.Log(e.Data);
            Parse(msg.Body);
        }
    }
    
    void ws_OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log(DateTime.Now.ToString() + " ws_OnError says: " + e.Message.ToString());
        Debug.Log(DateTime.Now.ToString() + " ws_OnError says: " + e.Exception.Message.ToString());
        Debug.Log(DateTime.Now.ToString() + " ws_OnError says: " + e.Exception.StackTrace.ToString());
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
        SendReadyMessage();
    }

    void Parse(string json)
    {
        StompMessageBody message = JsonUtility.FromJson<StompMessageBody>(json);
        switch(message.type)
        {
            case "userCountCheck":
                int userCount = JsonUtility.FromJson<UserCountCheck>(message.data).userCount;
                if(playerId == -1) 
                { 
                    playerId = userCount;
                    GameManager.instance.localPlayerIndex = playerId - 1;
                }
                lobby.playerCount = userCount;
                lobby.GetReady();
                break;
            case "cardDeck":
                CardDeck cardDeck = JsonUtility.FromJson<CardDeck>(message.data);
                GameManager.instance.deck = cardDeck;
                break;
            default:
                MessageData msgData = JsonUtility.FromJson<MessageData>(message.data);
                GameManager.instance.GetMessage(msgData);
                // 게임매니저에 보내야함.
                break;
        }
    }

    public void SendReadyMessage()
    {
        StompMessageBody body = new StompMessageBody();
        body.channelId = "1";
        body.data = "";
        body.sender = "4";
        body.type = "userCountCheck";
        string body_json = JsonUtility.ToJson(body);

        var pub = new StompMessage(StompFrame.SEND,body_json);
        pub["destination"] = readyMsgDest;
        ws.Send(serializer.Serialize(pub));
    }

    public void SendMessage()
    {
        MessageData message = new MessageData();
        
        message.actionPlayerId = 1;
        message.actionType = ActionType.BUSH;
        message.player = new PlayerMessageData();
        message.playerBoard = new PlayerBoardMessageData();

       _SendMessage(message);
    }

    public void SendMessage(MessageData data)
    {
        _SendMessage(data);
    }

    void _SendMessage(MessageData msgData)
    {
        StompMessageBody body = new StompMessageBody();
        body.channelId = clientId;
        body.data = JsonUtility.ToJson(msgData);
        body.sender = clientId;
        body.type = StompFrame.SEND;
        string body_json = JsonUtility.ToJson(body);

        // body_json = Regex.Unescape(body_json);

        var pub = new StompMessage(StompFrame.SEND,body_json);
        pub["destination"] = playMsgDest;
        ws.Send(serializer.Serialize(pub));
    }

}

[System.Serializable]
public class MessageData
{
    public int actionPlayerId; 
    public ActionType actionType; 
    
    public PlayerMessageData player; 
    public PlayerBoardMessageData playerBoard; 
}


[System.Serializable]
public class UserCountCheck
{
    public int userCount;
}

[System.Serializable]
public class CardDeck
{
    public List<Deck> cards;
}

[System.Serializable]
public class Deck
{
    public int user;
    public List<int> jobCards;
    public List<int> facilityCards;
}