using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player
{
    public bool isFirstPlayer = false;
    public int pig, cow, sheep;
    public int wheat, vegetable;
    public int wood, rock, reed, dirt;
    public int food, begging;
    public int family, fence, shed, room;
    public List<int> card_owns;
    public List<int> card_hands;

    public Player()
    {
        this.Init();
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