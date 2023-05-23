using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player[] players = new Player[4];
    MessageData message = new MessageData();
    public int currentPlayerId;

    private void Awake()
    {
        //GameManager Singleton
        GameManager.instance = this;

        //Initialize Player
        this.Init();
    }

    //Update to NetworkManager
    public void Update( ActionType actiontype )
    {
        this.message.actionPlayerId = this.currentPlayerId;
        this.message.actionType = ActionType.BUSH;
        this.message.player = this.players[currentPlayerId].PlayerToPlayerMessageData();
        this.message.playerBoard = new PlayerBoardMessageData(); //임시
        
        //NetworkManager를 통해 DB와 소통
        NetworkManager.instance.SendMessage(message);
    }

    //Initialize
    //for game
    void Init()
    {
        for (int i = 0; i < 4; i++)
        {
            this.players[i] = new Player();
            //first player is 
            if (i == 0) { players[i].isFirstPlayer = true; }
        }
    }

        //for dummy data(Debug)
    void DummyInit()
    {
        //dummy players initialize
        for (int i = 0; i < 4; i++)
        {
            this.players[i] = new Player();
            this.players[i].Init();
        }

        for (int i = 0; i < 4; i++)
        {
            this.players[i].pig = 3; this.players[i].cow = 3; this.players[i].sheep = 3;
            this.players[i].wheat = 3; this.players[i].vegetable = 3;
            this.players[i].wood = 3; this.players[i].rock = 3; this.players[i].reed = 3; this.players[i].clay = 3;
            this.players[i].food = 3; this.players[i].begging = 3;
            this.players[i].family = 3; this.players[i].fence = 3; this.players[i].shed = 3; this.players[i].room = 3;
        }
    }



}
