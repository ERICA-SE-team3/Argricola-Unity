using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player
{
    //0. 플레이어 id
    public int PlayerId;

    //1. 자원 정보
    public int pig, cow, sheep;
    public int wheat, vegetable;
    public int wood, rock, reed, clay;
    public int food, begging;
    public int family, fence, shed, room;

    //직업 카드
    public List<int> jobcard_owns;
    public List<int> jobcard_hands;

    //보조설비 카드
    public List<int> subcard_owns;
    public List<int> subcard_hands;

    //주요 카드
    public List<int> maincard_owns;

    //2.선 플레이어 정보
    public bool isFirstPlayer;

    //현재 플레이어의 남은 가족 수 
    public int remainFamilyOfCurrentPlayer;

    public PlayerMessageData GetPlayerMessageData()
    {
        PlayerMessageData msgdata = new PlayerMessageData();
        msgdata.isFirstPlayer = this.isFirstPlayer;
        msgdata.pig = this.pig;
        msgdata.cow = this.cow;
        msgdata.sheep = this.sheep;
        msgdata.wheat = this.wheat;
        msgdata.vegetable = this.vegetable;
        msgdata.wood = this.wood;
        msgdata.rock = this.rock;
        msgdata.reed = this.reed;
        msgdata.clay = this.clay;
        msgdata.food = this.food;
        msgdata.begging = this.begging;
        msgdata.family = this.family;
        msgdata.fence = this.fence;
        msgdata.shed = this.shed;
        msgdata.room = this.room;

        //card


        return msgdata;
    }

    //---------------------------------------------------------------------------

    //private void Start()
    //{
    //    this.Init();
    //}

    public Player()
    {
        this.Init();
    }

    public void Init()
    {
        //1. 자원 초기화
        this.pig = 0; this.cow = 0; this.sheep = 0;
        this.wheat = 0; this.vegetable = 0;
        this.wood = 0; this.rock = 0; this.reed = 0; this.clay = 0;
        this.food = 3; this.begging = 0;
        this.family = 2; this.fence = 0; this.shed = 0; this.room = 2;
        this.jobcard_owns = new List<int>();
        this.jobcard_hands = new List<int>();
        this.subcard_owns = new List<int>();
        this.subcard_hands = new List<int>();
        this.maincard_owns = new List<int>();

        //2. 선 플레이어 정보 초기화
        this.isFirstPlayer = false;


        this.remainFamilyOfCurrentPlayer = this.family;
    }

    public bool HasJobCard( string cardName )
    {
        //card가 없으면 return false
        if ( this.jobcard_owns.Count == 0 )
        {
            Debug.Log("Player " + this.PlayerId + " has no jobcards!");
            return false;
        }

        //card가 있다면
        switch (cardName) 
        {
            case "magician":
                //magician카드가 있다면
                if (this.jobcard_owns.Contains( (int)GameManager.Cards.magician) )
                {
                    return true;
                }
                break;

            case "woodCutter":
                if (this.jobcard_owns.Contains((int)GameManager.Cards.woodCutter))
                {
                    return true;
                }
                break;

            case "vegetableSeller":
                if (this.jobcard_owns.Contains((int)GameManager.Cards.vegetableSeller))
                {
                    return true;
                }
                break;
            case "woodPicker":
                //magician카드가 있다면
                if (this.jobcard_owns.Contains((int)GameManager.Cards.woodPicker))
                {
                    return true;
                }
                break;

            case "wallMaster":
                if (this.jobcard_owns.Contains((int)GameManager.Cards.wallMaster))
                {
                    return true;
                }
                break;

            case "stoneCutter":
                if (this.jobcard_owns.Contains((int)GameManager.Cards.stoneCutter))
                {
                    return true;
                }
                break;

            case "organicFarmer":
                if (this.jobcard_owns.Contains((int)GameManager.Cards.organicFarmer))
                {
                    return true;
                }
                break;

            case "pigBreeder":
                if (this.jobcard_owns.Contains((int)GameManager.Cards.pigBreeder))
                {
                    return true;
                }
                break;
        }

        //해당 카드가 없다면
        return false;
    }

}