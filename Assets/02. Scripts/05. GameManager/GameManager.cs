using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager
    public static GameManager instance;

    //player들을 담을 ArrayList, players
    public List<Player> players = new List<Player>();

    //player의 parent
    public GameObject objPlayerboards;

    //로컬 플레이어 객체 인덱스, 로비에서 번호 부여받을 예정

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

    //그 턴에 한 행동 관리 array
    public bool[] IsDoingAct;

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

    public GameObject sheepMarket, wishChildren, westernQuarry, pigMarket, vegetableSeed, easternQuarry, cowMarket;
    public GameObject farming, grainUtilization, fencing, houseDevelop, expand;
    // public GameObject whisChildren;

    
    // 행동 관리하는 Queue 생성
    public Queue<string> actionQueue = new Queue<string>();
    // queue에서 하나 꺼낸 행동
    public string popAction;

    public void PopQueue() {
        SheepMarketRoundAct sm = sheepMarket.GetComponent<SheepMarketRoundAct>();
        PigMarketRoundAct pm = pigMarket.GetComponent<PigMarketRoundAct>();
        WishChildrenRoundAct wc = wishChildren.GetComponent<WishChildrenRoundAct>();
        WesternQuarryRoundAct wq = westernQuarry.GetComponent<WesternQuarryRoundAct>();
        VegetableSeedRoundAct vs = vegetableSeed.GetComponent<VegetableSeedRoundAct>();
        EasternQuarryRoundAct eq = easternQuarry.GetComponent<EasternQuarryRoundAct>();
        CowMarketRoundAct cm = cowMarket.GetComponent<CowMarketRoundAct>();

        //집 업그레이드
        HouseDevelopRoundAct hd = houseDevelop.GetComponent<HouseDevelopRoundAct>();

        //집짓기
        MainActExpand ex = expand.GetComponent<MainActExpand>();

        //농지
        MainActFarming fr = farming.GetComponent<MainActFarming>();

        //빵굽기, 씨뿌리기
        GrainUtilizationRoundAct gu = grainUtilization.GetComponent<GrainUtilizationRoundAct>();

        //울타리치기
        FencingRoundAct fc = fencing.GetComponent<FencingRoundAct>();

        if(actionQueue.Count == 0){
            this.endTurnFlag = true;
            Debug.Log( "Queue is Empty!!" );
            return;
        }

        popAction = actionQueue.Dequeue();
        
        if(popAction == "sowing"){
            gu.StartSowing();
        }
        else if(popAction == "baking"){
            // 빵 굽기 행동 시작 (ex. actionBaking() 호출하여 빵굽기 행동이 종료될 시점에 다시 PopQueue()호출 )
            gu.StartBaking();
        }
        else if(popAction == "sheepMarket"){
            sm.SheepMarketStart();
        }
        else if(popAction == "pigMarket"){
            pm.PigMarketStart();
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
            hd.StartHouseDeveloping();
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
            fr.FarmingStart();
        }
        else if(popAction == "houseBuild"){
            ex.StartHouseInstall();
        }
        else if(popAction == "shedBuild"){
            ex.StartBuildShed();
        }
        else if(popAction == "farming"){
            fr.FarmingStart();
        }
        else if(popAction == "fencing") {
            fc.StartFencing();
        }
    }


    public void Start()
    {
        //GameManager Singleton
        GameManager.instance = this;

        Debug.Log("Let's Ready the Game!!!");  

        //라운드카드들의 스택 초기화
        this.stackOfRoundCard = new int[13];

        Debug.Log( "This is stackOfRoundCard\n" + stackOfRoundCard[0] + "\n"
        + stackOfRoundCard[1] + "\n" + stackOfRoundCard[2] + "\n" + stackOfRoundCard[3] + "\n" );


        //player start
        for (int i=0; i<4; i++)
        {
            Player temp = new Player();
            temp.id = i;
            this.players.Add(temp);
        }

        IsDoingAct = new bool[30];
        this.InitializeIsDoingAct();

        //=========================================

        //playerboard start
        for (int i = 0; i < 4; i++)
        {
           GameObject temp1 = objPlayerboards.transform.GetChild(i).gameObject; // canvas_player
           GameObject temp2 = temp1.transform.GetChild(0).gameObject; // Backgroundof
           GameObject tempB = temp2.transform.GetChild(0).gameObject; // playerboard
           PlayerBoard tempPB = tempB.GetComponent<PlayerBoard>(); 
           this.playerBoards.Add(tempPB);
        }

        //Setplayer to playerboard
        for(int i=0; i<4; i++) {
            this.playerBoards[i].SetPlayer( this.players[i] );
        }

        //=======================================
        

        //give first to player1 
        this.Init();

        //==============================================

        //플레이어들에게 직업 카드 분배
        this.players[0].jobcard_hands.Add( (int)Cards.magician ); //마술사
        this.players[0].jobcard_hands.Add((int)Cards.woodCutter); //나무꾼

        this.players[1].jobcard_hands.Add((int)Cards.vegetableSeller); //채소 장수
        this.players[1].jobcard_hands.Add((int)Cards.woodPicker); //장작 채집자

        this.players[2].jobcard_hands.Add((int)Cards.wallMaster); //초벽질공
        this.players[2].jobcard_hands.Add((int)Cards.stoneCutter); //돌 자르는 사람

        this.players[3].jobcard_hands.Add((int)Cards.organicFarmer); // 유기 농부
        this.players[3].jobcard_hands.Add((int)Cards.pigBreeder); // 돼지 사육사

        //플레이어들에게 보조설비 카드 분배
        this.players[0].subcard_hands.Add( (int)Cards.stoneClamp ); //돌집게
        this.players[0].subcard_hands.Add( (int)Cards.clayMining ); //양토채굴장

        this.players[1].subcard_hands.Add( (int)Cards.woodBoat ); //통나무배
        this.players[1].subcard_hands.Add( (int)Cards.rake ); //쇠스랑

        this.players[2].subcard_hands.Add( (int)Cards.watterBottle ); //물통
        this.players[2].subcard_hands.Add( (int)Cards.woodYard ); //목재소

        this.players[3].subcard_hands.Add( (int)Cards.butter ); //버터제조기
        this.players[3].subcard_hands.Add( (int)Cards.bottle ); //병

        //================================================

        // food of firstplayer to 2
        ResourceManager.instance.minusResource(0, "food", 1);



        //라운드 카드 가져오기
        for (int i=0; i<14; i++)
        {
            //라운드 카드 받아오기
            GameObject tmp = this.roundList.transform.GetChild(i).gameObject;
            this.roundcards.Add(tmp);
            this.roundcards[i].SetActive(false);
        }



        //현재 라운드 초기화
        this.currentRound = 0;

        //첫 라운드 준비
        //stack 증가
        //라운드 카드 활성화
        this.preRound();

        //오류 수정
        this.endTurnFlag = false;
    }


    private void Update() // 1프레임마다 실행되고 있음을 잊지 말자.
    {
        if ( this.RoundFlag )
            {
                //1-2. 턴을 진행 중이라면
                if ( !this.endTurnFlag )
                {
                    Debug.Log( "현재 라운드는 " + this.currentRound );
                    Debug.Log( "현재 플레이어는 Player " + this.currentPlayerId );
                    Debug.Log( "현재 플레이어들의 남은 가족수는 " + 
                    "\n" + this.players[0].remainFamilyOfCurrentPlayer +
                    "\n" + this.players[1].remainFamilyOfCurrentPlayer +
                    "\n" + this.players[2].remainFamilyOfCurrentPlayer +
                    "\n" + this.players[3].remainFamilyOfCurrentPlayer );
                    
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
                        SidebarManager.instance.HighlightCurrentPlayer(this.currentPlayerId);
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
                    Debug.Log("Game is Over!");
                    FinishAgriCola();


                } 
            }

        

    }

    //--------------------------------------------------------------------------------------------

    // //Update to NetworkManager
    // public void sendmsg( ActionType actiontype )
    // {
    //     this.message.actionPlayerId = this.currentPlayerId;
    //     this.message.actionType = ActionType.BUSH;
    //     this.message.player = this.players[currentPlayerId].GetPlayerMessageData();
    //     this.message.playerBoard = this.playerBoards[currentPlayerId].GetBoardMessageData();
        
    //     //NetworkManager를 통해 DB와 소통
    //     NetworkManager.instance.SendMessage(message);
    // }

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
        RoundDescriptor.instance.RoundNumberUpdate(this.currentRound);
    }

    //라운드 준비
    void preRound()
    {
        RoundDescriptor.instance.RoundDescriptiorUpdate("준비단계");
        //행동 stack 증가
        this.incrementStack();

        //라운드카드 활성화
        this.roundcards[this.currentRound].SetActive(true);

        //currentRoundUpdate
        this.UpdateCurrentRound();

        //act관리array 초기화
        this.InitializeIsDoingAct();

        //각 플레이어들 가족 수 원상복구
        for(int i=0; i<4; i++)
        {
            this.players[i].remainFamilyOfCurrentPlayer = this.players[i].family;
        }

        //Round의 첫 턴인 플레이어에게 턴을 넘김
        this.foundFirstPlayer();

        //RoundFlag를 true로
        this.RoundFlag = true;
        RoundDescriptor.instance.RoundDescriptiorUpdate("일하기단계");
    }

    bool checkHarvest()
    {
        if ( (this.currentRound == 4) || (this.currentRound == 7) || (this.currentRound == 9) ||
            (this.currentRound == 11) || (this.currentRound == 13) || (this.currentRound == 14) ) {
            RoundDescriptor.instance.RoundDescriptiorUpdate("수확단계");
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

    void InitializeIsDoingAct() {
        for(int i=0; i<30; i++) { this.IsDoingAct[i] = false; }
    }

    void FinishAgriCola() 
    {
        //1. 점수 계산
        int[] pointOfplayers = new int[4];
        //플레이어 별로 계산
        for(int i=0; i<4; i++) {
            //자원 - 가족 점수 포함
            //1-1. 곡식
            if ( this.players[i].wheat ==0 ) { pointOfplayers[i] = pointOfplayers[i] -1; }
            if ( 1 <= this.players[i].wheat&& this.players[i].wheat <= 3  ) { pointOfplayers[i] = pointOfplayers[i]+1; }
            if ( 4 <= this.players[i].wheat && this.players[i].wheat <= 5 ) { pointOfplayers[i] = pointOfplayers[i]+2; }
            if ( 6 <= this.players[i].wheat && this.players[i].wheat <= 7 ) { pointOfplayers[i] = pointOfplayers[i]+3; }
            if ( this.players[i].wheat >= 8 ) { pointOfplayers[i] = pointOfplayers[i]+4; }

            //1-2. 채소
            if ( this.players[i].vegetable ==0 ) { pointOfplayers[i] = pointOfplayers[i] -1; }
            if ( this.players[i].vegetable ==1 ) { pointOfplayers[i] = pointOfplayers[i]+1; }
            if ( this.players[i].vegetable ==2 ) { pointOfplayers[i] = pointOfplayers[i]+2; }
            if ( this.players[i].vegetable == 3 ) { pointOfplayers[i] = pointOfplayers[i]+3; }
            if ( this.players[i].vegetable >= 4 ) { pointOfplayers[i] = pointOfplayers[i]+4; }

            //1-3. 양
            if ( this.players[i].sheep ==0 ) { pointOfplayers[i] = pointOfplayers[i] -1; }
            if ( 1 <= this.players[i].sheep&& this.players[i].sheep <= 3  ) { pointOfplayers[i] = pointOfplayers[i]+1; }
            if ( 4 <= this.players[i].sheep && this.players[i].sheep <= 5 ) { pointOfplayers[i] = pointOfplayers[i]+2; }
            if ( 6 <= this.players[i].sheep && this.players[i].sheep <= 7 ) { pointOfplayers[i] = pointOfplayers[i]+3; }
            if ( this.players[i].sheep >= 8 ) { pointOfplayers[i] = pointOfplayers[i]+4; }

            //1-4. 돼지
            if ( this.players[i].pig ==0 ) { pointOfplayers[i] = pointOfplayers[i] -1; }
            if ( 1 <= this.players[i].pig&& this.players[i].pig <= 2  ) { pointOfplayers[i] = pointOfplayers[i]+1; }
            if ( 3 <= this.players[i].pig && this.players[i].pig <= 4 ) { pointOfplayers[i] = pointOfplayers[i]+2; }
            if ( 5 <= this.players[i].pig && this.players[i].pig <= 6 ) { pointOfplayers[i] = pointOfplayers[i]+3; }
            if ( this.players[i].pig >= 7 ) { pointOfplayers[i] = pointOfplayers[i]+4; }

            //1-5. 소
            if ( this.players[i].cow ==0 ) { pointOfplayers[i] = pointOfplayers[i] -1; }
            if ( this.players[i].cow ==1  ) { pointOfplayers[i] = pointOfplayers[i]+1; }
            if ( 2 <= this.players[i].cow && this.players[i].cow <= 3 ) { pointOfplayers[i] = pointOfplayers[i]+2; }
            if ( 4 <= this.players[i].cow && this.players[i].cow <= 5 ) { pointOfplayers[i] = pointOfplayers[i]+3; }
            if ( this.players[i].cow >= 6 ) { pointOfplayers[i] = pointOfplayers[i]+4; }

            //1-6. 밭
            int farmCount = 0;
            int emptyCount = 0;
            foreach(Block block in this.playerBoards[i].blocks)
            {
                if( block.type == BlockType.FARM ) {
                    farmCount = farmCount + 1;
                }

                if( block.type == BlockType.EMPTY ) {
                    emptyCount = emptyCount + 1;
                }
            }

            if ( farmCount ==0 && farmCount == 1 ) { pointOfplayers[i] = pointOfplayers[i] -1; }
            if ( farmCount ==2  ) { pointOfplayers[i] = pointOfplayers[i]+1; }
            if ( farmCount ==3 ) { pointOfplayers[i] = pointOfplayers[i]+2; }
            if ( farmCount ==4 ) { pointOfplayers[i] = pointOfplayers[i]+3; }
            if ( farmCount >= 5 ) { pointOfplayers[i] = pointOfplayers[i]+4; }


            //1-7. 우리
            // if ( this.players[i].shed ==0 ) { pointOfplayers[i] = pointOfplayers[i] -1; }
            // if ( this.players[i].shed ==1 ) { pointOfplayers[i] = pointOfplayers[i]+1; }
            // if ( this.players[i].shed ==2 ) { pointOfplayers[i] = pointOfplayers[i]+2; }
            // if ( this.players[i].shed == 3 ) { pointOfplayers[i] = pointOfplayers[i]+3; }
            // if ( this.players[i].shed >= 4 ) { pointOfplayers[i] = pointOfplayers[i]+4; }

            //개인보드판 빈 칸
            pointOfplayers[i] = pointOfplayers[i] - emptyCount;

            //외양간 있는 우리 - 개당 1점 - 일단 외양간 갯수로 퉁치자
            pointOfplayers[i] = pointOfplayers[i] + this.players[i].shed;

            //방 점수 - 나무, 흙 ,돌이 0,1,2점
            switch(this.playerBoards[i].houseType)
        {
            case HouseType.WOOD:
                pointOfplayers[i] = pointOfplayers[i] + 0 * this.players[i].room;
                break;
            case HouseType.CLAY:
                pointOfplayers[i] = pointOfplayers[i] + 1 * this.players[i].room;
                break;
            case HouseType.STONE:
                pointOfplayers[i] = pointOfplayers[i] + 2 * this.players[i].room;
                break;
        }

            //카드 점수
            //1. 주요설비
            //1-1. 가구제작소
            if( this.players[i].HasMainCard( "joinery" )  ) {
                //카드 자체 점수 2점
                pointOfplayers[i] = pointOfplayers[i] + 2;

                if(3==this.players[i].wood || this.players[i].wood==4) {
                    pointOfplayers[i] = pointOfplayers[i] + 1;
                }
                if(this.players[i].wood==5 || this.players[i].wood==6) {
                    pointOfplayers[i] = pointOfplayers[i] + 2;
                }
                if(this.players[i].wood>=7) {
                    pointOfplayers[i] = pointOfplayers[i] + 3;
                }
            }
            //1-2. 그릇제작소
            if( this.players[i].HasMainCard( "pottery" )  ) {

                pointOfplayers[i] = pointOfplayers[i] + 2;

                if(3==this.players[i].clay || this.players[i].clay==4) {
                    pointOfplayers[i] = pointOfplayers[i] + 1;
                }
                if(this.players[i].clay==5 || this.players[i].clay==6) {
                    pointOfplayers[i] = pointOfplayers[i] + 2;
                }
                if(this.players[i].clay>=7) {
                    pointOfplayers[i] = pointOfplayers[i] + 3;
                }
            }

            //1-3. 바구니제작소
            if( this.players[i].HasMainCard( "basket" )  ) {

                pointOfplayers[i] = pointOfplayers[i] + 2;

                if(3==this.players[i].reed || this.players[i].reed==4) {
                    pointOfplayers[i] = pointOfplayers[i] + 1;
                }
                if(this.players[i].reed==5 || this.players[i].reed==6) {
                    pointOfplayers[i] = pointOfplayers[i] + 2;
                }
                if(this.players[i].reed>=7) {
                    pointOfplayers[i] = pointOfplayers[i] + 3;
                }
            }

            //1-4. 우물
            if ( this.players[i].HasMainCard( "well" ) ) {
                pointOfplayers[i] = pointOfplayers[i] + 4;
            }

            //1-5. 돌가마
            if (this.players[i].HasMainCard( "stoneOven" )) {
                pointOfplayers[i] = pointOfplayers[i] + 3;
            }

            //1-6. 흙가마
            if (this.players[i].HasMainCard( "clayOven" )) {
                pointOfplayers[i] = pointOfplayers[i] + 2;
            }

            //1-7. 화로 화로 화덕 화덕
            if (this.players[i].HasMainCard( "fireplace1" )) {
                pointOfplayers[i] = pointOfplayers[i] + 1;
            }
            if (this.players[i].HasMainCard( "fireplace2" )) {
                pointOfplayers[i] = pointOfplayers[i] + 1;
            }
            if (this.players[i].HasMainCard( "cookingHearth1" )) {
                pointOfplayers[i] = pointOfplayers[i] + 1;
            }
            if (this.players[i].HasMainCard( "cookingHearth2" )) {
                pointOfplayers[i] = pointOfplayers[i] + 1;
            }


            //2.보조설비

            //2-1. 병
            if( this.players[i].HasSubCard( "bottle" )) {
                pointOfplayers[i] = pointOfplayers[i] + 4;
            }

            //2-2. 버터제조기
            if( this.players[i].HasSubCard( "butter" )) {
                pointOfplayers[i] = pointOfplayers[i] + 1;
            }

            //2-3. 목재소
            if( this.players[i].HasSubCard( "woodYard" )) {
                pointOfplayers[i] = pointOfplayers[i] + 2;
            }

            //2-4. 통나무배
            if( this.players[i].HasSubCard( "woodBoat" )) {
                pointOfplayers[i] = pointOfplayers[i] + 1;
            }

            //2-5.양토채굴장 
            if( this.players[i].HasSubCard( "clayMining" )) {
                pointOfplayers[i] = pointOfplayers[i] + 1;
            }

            //3. 직업 카드
            //3-1. organic farmer
            //...

            //보너스 점수

            //구걸 - 개당 -3
            pointOfplayers[i] = pointOfplayers[i] - 3 * this.players[i].begging;

        }
        //2. 승자 발표
        //2-1. 각 플레이어 점수 발표
        int max = 0;
        int max_players = 0;

        for(int i=0; i<4; i++) {
            if( pointOfplayers[i] > max ) { max = pointOfplayers[i]; max_players = i; }
            Debug.Log( "Player "+ i + " totally GET " + pointOfplayers[i] + " POINTS!!!!" );
        }

        //2-2. 승자 발표!
        Debug.Log( "WInner is Player " + max_players + "!!!!!!!!!!!!!!!!!!!!!!");
    }

}
