using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayers
{
    public Player[] players = new Player[4];

    public DummyPlayers()
    {
        this.Init();
    }

    void Init()
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
            this.players[i].wood = 3; this.players[i].rock = 3; this.players[i].reed = 3; this.players[i].dirt = 3;
            this.players[i].food = 3; this.players[i].begging = 3;
            this.players[i].family = 3; this.players[i].fence = 3; this.players[i].shed = 3; this.players[i].room = 3;
        }
    }
}
