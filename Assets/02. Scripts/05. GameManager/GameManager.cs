using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager
    public static GameManager instance;

    //player들을 담을 ArrayList, players
    public List<Player> players = new List<Player>();

    // 로컬 플레이어 객체 인덱스, 로비에서 번호 부여받을 예정
    public int localPlayerIndex = 0;

    //player의 board
    public List<PlayerBoard> playerBoards = new List<PlayerBoard>();

    //stack이 있는 Roundcard
    public int[] stackOfRoundCard;

    //현재 차례인 player index
    public int currentPlayerId;

    //현재 라운드 - 수확라운드인지 체크하기 위함
    public int currentRound;

    //roundcard list
    public GameObject roundList;

    public List<GameObject> roundcards = new List<GameObject>();

    //소통할 message 형식
    MessageData message = new MessageData();
    //스택이 쌓이는 라운드카드들
    public enum stackBehavior
    {
        copse, // 덤불
        grove, //수풀
        clayPit, //점토채굴장
        travelingTheater, //유랑극단
        forest, //숲
        dirtPit, //흙 채굴장
        reedField, //갈대밭
        fishing, //낚시
        sheepMarket, //양 시장
        westernQuarry, //서부 채굴장
        pigMarket, //돼지 시장
        easternQuarry, //동부 채굴장
        cattleMarket //소 시장
    }

    //게임 진행을 위한 flag들
    //1. 라운드 진행을 나타내는 flag
    public bool RoundFlag = true;
    //2. 각 플레이어의 turn ( 가족 수 하나당 한 턴 )이 끝남을 나타내는 flag
    public bool endTurnFlag = false;

    public GameObject playerBoard, sheepMarket, wishChildren, westernQuarry, pigMarket, vegetableSeed, easternQuarry, cowMarket;
    // public GameObject whisChildren;
    // 행동 관리하는 Queue 생성
    public Queue<string> actionQueue = new Queue<string>();
    // queue에서 하나 꺼낸 행동
    public string popAction;

    public void PopQueue() {
        PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        SheepMarketRoundAct sm = sheepMarket.GetComponent<SheepMarketRoundAct>();
        PigMarketRoundAct pm = pigMarket.GetComponent<PigMarketRoundAct>();
        WishChildrenRoundAct wc = wishChildren.GetComponent<WishChildrenRoundAct>();
        WesternQuarryRoundAct wq = westernQuarry.GetComponent<WesternQuarryRoundAct>();
        VegetableSeedRoundAct vs = vegetableSeed.GetComponent<VegetableSeedRoundAct>();
        EasternQuarryRoundAct eq = easternQuarry.GetComponent<EasternQuarryRoundAct>();
        CowMarketRoundAct cm = cowMarket.GetComponent<CowMarketRoundAct>();

        if(actionQueue.Count == 0){
            this.endTurnFlag = true;
        }

        popAction = actionQueue.Dequeue();
        
        if(popAction == "sowing"){
            board.StartSowing();
        }
        else if(popAction == "baking"){
            // 빵 굽기 행동 시작 (ex. actionBaking() 호출하여 빵굽기 행동이 종료될 시점에 다시 PopQueue()호출 )
        }
        else if(popAction == "sheepMarket"){
            sm.SheepMarketStart();
        }
        else if(popAction == "pigMarket"){
            pm.PigMarketStart();
        }
        else if(popAction == "fencing"){
            board.StartInstallFence();
        }
        else if(popAction == "improvements"){
            // 주요설비 및 보조설비 카드를 고를 수 있는 함수 호출 - 아직 구현되지 않음
        }
        else if(popAction == "subCard"){
            // 보조설비 카드를 고를 수 있는 함수 호출 - 아직 구현되지 않음
        }
        else if(popAction == "wishChildren"){
            wc.WishChildrenStart();
        }
        else if(popAction == "westernQuarry"){
            wq.WesternQuarryStart();
        }
        else if(popAction == "houseDevelop"){
            board.StartUpgradeHouse();
        }
        else if(popAction == "vegetableSeed"){
            vs.VegetableSeedStart();
        }
        else if(popAction == "easternQuarry"){
            eq.EasternQuarryStart();
        }
        else if(popAction == "cowMarket"){
            cm.CowMarketStart();
        }
        else if(popAction == "cultivation"){
            board.StartInstallFarm();
        }
        else if(popAction == "houseBuild"){
            board.StartInstallHouse();
        }
        else if(popAction == "shedBuild"){
            board.StartInstallShed();
        }
    }

    
    public void Start()
    {

        Debug.Log("Let's Ready the Game!!!");  

        //GameManager Singleton
        GameManager.instance = this;

        //player start
        for (int i=0; i<4; i++)
        {
            Player temp = new Player();
            temp.id = i;
            this.players.Add(temp);
        }

        ////playerboard start
        //for (int i = 0; i < 4; i++)
        //{
        //    PlayerBoard tempB = new PlayerBoard();
        //    this.playerBoards.Add(tempB);
        //}

        //give first to player1 and food of firstplayer to 2
        this.Init();
        ResourceManager.instance.minusResource(0, "food",  1);

        ////for test -> player2's family : 3
        //this.players[2].family = 5;

        //라운드 카드 가져오기
        for (int i=0; i<14; i++)
        {
            //라운드 카드 받아오기
            GameObject tmp = this.roundList.transform.GetChild(i).gameObject;
            this.roundcards.Add(tmp);
            this.roundcards[i].SetActive(false);
        }

        //라운드카드들의 스택 초기화
        this.stackOfRoundCard = new int[13];

        //현재 라운드 초기화
        this.currentRound = 0;

        //첫 라운드 준비
        //stack 증가
        //라운드 카드 활성화
        this.preRound();

    }

    private void Update() // 1프레임마다 실행되고 있음을 잊지 말자.
    {
        //1. 라운드 진행
        if ( this.RoundFlag )
        {
            // Debug.Log("Current Round is " + this.currentRound);
            //1-2. 턴을 진행 중이라면
            if ( !this.endTurnFlag )
            {
                //...기다림 == 아무것도 안함
                // Debug.Log("Player " + this.currentPlayerId + "Wait to Action... ");
            }

            else //endTurnFlag is true --> 1-3. 플레이어의 턴이 끝남.
            {
                //1-4. 다음 턴을 부여받을 플레이어 찾기
                //1-4-1. 턴을 부여받을 플레이어가 존재 -> Round 그대로 진행
                if ( this.findNextPlayer() )
                {
                    //... 그대로 진행
                    Debug.Log("Move to Next Turn");
                    this.endTurnFlag = false;
                }

                //1-4-2. 턴을 부여받을 플레이어가 없음 -> Round 종료 시퀀스로 넘어감
                else
                {
                    Debug.Log("Round is Over");
                    this.endTurnFlag = false;
                    this.RoundFlag = false;
                }
            }
        }



        //2. 라운드 전체가 끝남.
        else
        {
            for(int i=0; i<4; i++)
            {
                if(ResourceManager.instance.getResourceOfPlayer(i, "baby") != 0)
                {
                    ResourceManager.instance.minusResource(i, "baby", ResourceManager.instance.getResourceOfPlayer(i, "baby"));
                    ResourceManager.instance.addResource(i, "family", ResourceManager.instance.getResourceOfPlayer(i, "baby"));
                }
            }
            //2-1. 수확라운드인지 체크 후 수확 실행
            if (this.checkHarvest())
            {
                Debug.Log("수확 라운드 진행중...");
                //수확라운드 진행
            }

            //2-2. 다음 라운드 진행이 가능한지 ( 마지막 라운드 인지 체크 )
            if ( !this.checkFinalRound() )
            {
                //2-2-1. 다음 라운드 준비 및 진행
                this.preRound();
            }
            else
            {
                //2-2-2. 게임 종료
                //...
                Debug.Log("Game is Over!");
            } 
        }

        //다음 라운드로 진행.

    }

    //--------------------------------------------------------------------------------------------

    //Update to NetworkManager
    public void sendmsg( ActionType actiontype )
    {
        this.message.actionPlayerId = this.currentPlayerId;
        this.message.actionType = ActionType.BUSH;
        this.message.player = this.players[currentPlayerId].GetPlayerMessageData();
        this.message.playerBoard = this.playerBoards[currentPlayerId].GetBoardMessageData();
        
        //NetworkManager를 통해 DB와 소통
        NetworkManager.instance.SendMessage(message);
    }

    public int getCurrentPlayerId()
    {
        return this.currentPlayerId;
    }


    //Initialize
    //for game
    void Init()
    {
        this.players[0].isFirstPlayer = true;
    }

    void incrementStack()
    {
        for(int i=0; i<13; i++)
        {
            this.stackOfRoundCard[i] = this.stackOfRoundCard[i]+1;
        }
    }

    void foundFirstPlayer()
    {
        for(int i=0; i<4; i++)
        {
            if ( this.players[i].isFirstPlayer )
            {
                this.currentPlayerId = i;
                SidebarManager.instance.HighlightCurrentPlayer(i);
                SidebarManager.instance.FirstPlayerIcon(i);
                break;
            }
        }
    }

    //주어진 playerId의 다음 playerId를 찾는 함수
    int findNextPlayerId( int playerId )
    {
        SidebarManager.instance.HighlightCurrentPlayer(playerId);
        return (playerId + 1) % 4 ;
    }

    //다음 플레이어를 찾는 전체 함수 // 다음턴 : true , 라운드 종료 : false
    bool findNextPlayer()
    {
        //다음 플레이어 인덱스 계산
        int index = findNextPlayerId(this.currentPlayerId);

        //적합한 플레이어를 찾을 떄 까지 반복
        //결국 못찾아서 덱스 한바퀴 돌면 라운드 종료 or 찾으면 다음 플레이어
        for(int i=0; i<3; i++)
        {
            if (this.players[index].remainFamilyOfCurrentPlayer == 0)
            {
                index = findNextPlayerId(index);
            }
            //해당 플레이어가 가족 수가 0이 아니다 -> 너 turn 해.
            else
            { 
                this.currentPlayerId = index;
                return true;
            }
        }

        //for문을 빠져나옴 -> 방금 턴을 했던 플레이어로 돌아옴.
        //1. 이 때 그 플레이어의 가족 수가 0이 아니라면 - 라운드 진행
        if ( this.players[ currentPlayerId ].remainFamilyOfCurrentPlayer != 0 )
        {
            Debug.Log("Next turn is player " + this.currentPlayerId);
            return true;
        }

        //2. 얘도 0 -> 모든 플레이어의 가족 수가 0 -> 라운드 종료
        return false;

    }

    void UpdateCurrentRound()
    {
        this.currentRound = this.currentRound + 1;
    }

    //라운드 준비
    void preRound()
    {
        //행동 stack 증가
        this.incrementStack();

        //라운드카드 활성화
        this.roundcards[this.currentRound].SetActive(true);

        //currentRoundUpdate
        this.UpdateCurrentRound();

        //각 플레이어들 가족 수 원상복구
        for(int i=0; i<4; i++)
        {
            this.players[i].remainFamilyOfCurrentPlayer = this.players[i].family;
        }

        //Round의 첫 턴인 플레이어에게 턴을 넘김
        this.foundFirstPlayer();

        //RoundFlag를 true로
        this.RoundFlag = true;
    }

    bool checkHarvest()
    {
        if ( (this.currentRound == 4) || (this.currentRound == 7) || (this.currentRound == 9) ||
            (this.currentRound == 11) || (this.currentRound == 13) || (this.currentRound == 14) ) {
            return true;
        }
        else { return false;  }
    }

    //마지막 라운드인지 check
    bool checkFinalRound()
    {
        if (this.currentRound == 14)
        {
            return true;
        }
        return false;
    }

    public int getStackBehavior( string action )
    {
        int result = 0;

        switch (action)
        {
            case "copse":
                result =  (int)stackBehavior.copse;
                break;

            case "grove":
                result =  (int)stackBehavior.grove;
                break;

            case "travelingTheater":
                result =  (int)stackBehavior.travelingTheater;
                break;

            case "clayPit":
                result =  (int)stackBehavior.clayPit;
                break;

            case "forest":
                result =  (int)stackBehavior.forest;
                break;

            case "dirtPit":
                result =  (int)stackBehavior.dirtPit;
                break;

            case "reedField":
                result =  (int)stackBehavior.reedField;
                break;

            case "fishing":
                result =  (int)stackBehavior.fishing;
                break;

            case "sheepMarket":
                result =  (int)stackBehavior.sheepMarket;
                break;

            case "westernQuarry":
                result =  (int)stackBehavior.westernQuarry;
                break;

            case "pigMarket":
                result =  (int)stackBehavior.pigMarket;
                break;

            case "easternQuarry":
                result =  (int)stackBehavior.easternQuarry;
                break;

            case "cattleMarket":
                result =  (int)stackBehavior.cattleMarket;
                break;

        }

        return result;
    }
}
