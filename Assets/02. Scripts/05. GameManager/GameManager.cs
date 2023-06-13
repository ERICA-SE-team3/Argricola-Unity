using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int localPlayerIndex = -1;

    /// <summary>
    /// Player들을 담을 ArrayList
    /// </summary>
    public List<Player> players = new List<Player>();


    public GameObject playerBoardsObj;
    /// <summary>
    /// PlayerBoard 들을 담을 ArrayList
    /// </summary>
    public List<PlayerBoard> playerBoards = new List<PlayerBoard>();



    //현재 차례인 player index
    public int currentPlayerId;

    //현재 라운드 - 수확라운드인지 체크하기 위함
    public int currentRound;


    //stack이 있는 Roundcard
    public int[] stackOfRoundCard;
    
    //roundcard list
    public GameObject roundList;

    public List<GameObject> roundcards = new List<GameObject>();

    //그 턴에 한 행동 관리 array
    public bool[] IsDoingAct;


    //게임 진행을 위한 flag들
    //1. 라운드 진행을 나타내는 flag
    public bool RoundFlag = true;
    //2. 각 플레이어의 turn ( 가족 수 하나당 한 턴 )이 끝남을 나타내는 flag
    public bool endTurnFlag = false;

    public GameObject sheepMarket, wishChildren, westernQuarry, pigMarket, vegetableSeed, easternQuarry, cowMarket;
    public GameObject grainUtilization, fencing, houseDevelop, cultivation, farmDevelop, improvements, urgentWishChildren;
    public GameObject clayPit, copse, dayLaborer, dirtPit, expand, farming, fishing, forest, grainSeed, grove, lessonFood1, lessonFood2, meeting, reedFeild, resMarket, trevelingTheater;
    public GameObject scoreBoard;
    
    // 행동 관리하는 Queue 생성
    public Queue<string> actionQueue = new Queue<string>();

    // queue에서 하나 꺼낸 행동
    public string popAction;
    public ActionType queueActionType = ActionType.NONE;

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
        //빵굽기, 씨뿌리기
        GrainUtilizationRoundAct gu = grainUtilization.GetComponent<GrainUtilizationRoundAct>();
        //울타리치기
        FencingRoundAct fc = fencing.GetComponent<FencingRoundAct>();
        // 밭 농사
        CultivationRoundAct cv = cultivation.GetComponent<CultivationRoundAct>();
        // 농장 개조
        FarmDevelopRoundAct fd = farmDevelop.GetComponent<FarmDevelopRoundAct>();
        // 주요 설비
        ImprovementsRoundAct im = improvements.GetComponent<ImprovementsRoundAct>();
        // 주요 설비
        UrgentWishChildrenRoundAct uwc = urgentWishChildren.GetComponent<UrgentWishChildrenRoundAct>();
        //집짓기
        MainActExpand ex = expand.GetComponent<MainActExpand>();
        //농지
        MainActFarming fr = farming.GetComponent<MainActFarming>();
        // 점토채굴장
        MainActClayPit cp = clayPit.GetComponent<MainActClayPit>();
        // 덤불
        MainActCopse cs = copse.GetComponent<MainActCopse>();
        // 날품팔이
        MainActDayLaborer dl = dayLaborer.GetComponent<MainActDayLaborer>();
        // 흙 채굴장
        MainActDirtPit dp = dirtPit.GetComponent<MainActDirtPit>();
        // 낚시
        MainActFishing fs = fishing.GetComponent<MainActFishing>();
        // 숲
        MainActForest frst = forest.GetComponent<MainActForest>();
        // 갈대밭
        MainActGrainSeed gs = grainSeed.GetComponent<MainActGrainSeed>();
        // 수풀
        MainActGrove gv = grove.GetComponent<MainActGrove>();
        // 교습1
        MainActLessonFood1 lf1 = lessonFood1.GetComponent<MainActLessonFood1>();
        // 교습2
        MainActLessonFood2 lf2 = lessonFood1.GetComponent<MainActLessonFood2>();
        // 회합장소
        MainActMeeting meet = meeting.GetComponent<MainActMeeting>();
        // 갈대밭
        MainActReedField rf = reedFeild.GetComponent<MainActReedField>();
        // 자원시장
        MainActResMarket rm = resMarket.GetComponent<MainActResMarket>();
        // 유량극단
        MainActTrevelingTheater tt = trevelingTheater.GetComponent<MainActTrevelingTheater>();

        if(actionQueue.Count == 0){
            this.endTurnFlag = true;
            Debug.Log( "Queue is Empty!!" );
            return;
        }

        popAction = actionQueue.Dequeue();
        
        if(popAction == "guSowing"){
            gu.StartSowing();
        }
        if(popAction == "cvSowing"){
            cv.SowingStart();
        }
        else if(popAction == "guBaking"){
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
            im.ImprovementsStart();
        }
        else if(popAction == "hdImprovements"){
            // 주요설비 및 보조설비 카드를 고를 수 있는 함수 호출 - 아직 구현되지 않음
            hd.ImprovementsStart();
        }
        else if(popAction == "subCard"){
            // 보조설비 카드를 고를 수 있는 함수 호출 - 아직 구현되지 않음
            meet.SubCard();
            // wc.StartSubCard();
        }
        else if(popAction == "wishChildren"){
            wc.WishChildrenStart();
        }
        else if(popAction == "urgentWishChildren"){
            // uwc.UrgentWishChildrenStart();
            wc.WishChildrenStart();
        }
        else if(popAction == "westernQuarry"){
            wq.WesternQuarryStart();
        }
        else if(popAction == "hdHouseDevelop"){
            hd.StartHouseDeveloping();
        }
        else if(popAction == "fdHouseDevelop"){
            fd.StartHouseDeveloping();
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
        else if(popAction == "cvFarming"){
            cv.FarmingStart();
        }
        else if(popAction == "fencing") {
            fc.StartFencing();
        }
        else if(popAction == "fdFencing") {
            fd.StartFencing();
        }
        else if(popAction == "clayPit") {
            cp.ClayPitStart();
        }
        else if(popAction == "copse") {
            cs.CopseStart();
        }
        else if(popAction == "dayLaborer") {
            dl.DayLaborerStart();
        }
        else if(popAction == "dirtPit") {
            dp.DirtPitStart();
        }
        else if(popAction == "fishing") {
            fs.FishingStart();
        }
        else if(popAction == "forest") {
            frst.ForestStart();
        }
        else if(popAction == "grainSeed") {
            gs.GrainSeedStart();
        }
        else if(popAction == "grove") {
            gv.GroveStart();
        }
        else if(popAction == "lessonFood1") {
            lf1.LessonFoodStartOne();
        }
        else if(popAction == "lessonFood2") {
            lf2.LessonFoodStartTwo();
        }
        else if(popAction == "meeting") {
            meet.MeetingStart();
        }
        else if(popAction == "reedFeild") {
            rf.ReedFeildStart();
        }
        else if(popAction == "resMarket") {
            rm.ResMarketStart();
        }
        else if(popAction == "trevelingTheater") {
            tt.TrevelingTheaterStart();
        }
        // 임시
        else if(popAction == "lesson")
        {
            lf1.Lesson();
        }
        else if(popAction == "card")
        {
            im.GetCard(true,true,true);
        }
    }

    public CardDeck deck;
    public bool isGameScene = false, isDataUpdated = false;

    MessageData msgData;

    public List<ActionType> NotEndTurnTypeList = new List<ActionType>();
    public List<ActionType> StartTurnTypeList = new List<ActionType>();
    // -----------------------------------------------------------------------------------------------------------------

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start() {
        SetTurnList();
    }

    
    private void Update() // 1프레임마다 실행되고 있음을 잊지 말자.
    {
        if(isDataUpdated) 
        {
            UpdateData();
        }

        if(isGameScene) { Round(); }

    }


    public void Init()
    {
        //라운드카드들의 스택 초기화
        this.stackOfRoundCard = new int[13];

        //player start
        for (int i=0; i<4; i++) 
        {
            Player temp = new Player();
            temp.id = i;
            temp.Init();
            this.players.Add(temp);
        }
        //=========================================

        //give first to player1 
        this.players[0].isFirstPlayer = true;

        //==============================================
        
        SetPlayerHand();

        //================================================

        IsDoingAct = new bool[30];
        this.InitializeIsDoingAct();

        // food of firstplayer to 2
        ResourceManager.instance.minusResource(0, "food", 1);

        //현재 라운드 초기화
        this.currentRound = 0;

        //오류 수정
        this.endTurnFlag = false;
    }

    public void SetPlayerHand()
    {
        for(int i = 0; i < 4; i++)
        {
            this.players[i].jobcard_hands.Add(deck.cards[i].jobCards[0]);
            this.players[i].jobcard_hands.Add(deck.cards[i].jobCards[1]);
            this.players[i].subcard_hands.Add(deck.cards[i].facilityCards[0]);
            this.players[i].subcard_hands.Add(deck.cards[i].facilityCards[1]);
        }
    }


    
    public void GetMessage(MessageData data)
    {
        stackOfRoundCard = data.stacks;
        if (data.actionPlayerId == localPlayerIndex) return;

        msgData = data;
        players[data.actionPlayerId].SetPlayerMessageData(data.player);
        if(data.actionType == ActionType.MEETING_PLACE || data.actionType == ActionType.MEETING_PLACE)
        {
            for(int i = 0; i < 4; i++)
            {
                players[i].isFirstPlayer = false;
            }
        }


        playerBoards[data.actionPlayerId].SetBoardMessageData(data.playerBoard);
        isDataUpdated = true;
        if(data.actionType != ActionType.CHANGE_RESOURCE && data.actionType != ActionType.MOVE_ANIMAL)
        {
            if(isActionTypeEndTurn(data.actionType))
                endTurnFlag = true;
        }
    }
    
    /// <summary>
    /// 행동을 보내는 함수
    /// </summary>
    public void SendMessage()
    {
        //소통할 message 형식
        MessageData message = new MessageData();

        message.stacks = stackOfRoundCard;
        
        // 액션 디큐하는 공간
        // ActionType didActiontype = Dequeue();
        message.actionPlayerId = localPlayerIndex;

        // 임시로 채워넣은 행동
        message.actionType = ActionType.BUSH;
        message.player = players[localPlayerIndex].GetPlayerMessageData();
        message.playerBoard = playerBoards[localPlayerIndex].GetBoardMessageData();

        NetworkManager.instance.SendMessage(message);

        Logger.Log(message);
    }

    /// <summary>
    /// 행동을 보내는 함수
    /// </summary>
    /// <param name="actionType"></param>
    public void SendMessage(ActionType actionType)
    {
        //소통할 message 형식
        MessageData message = new MessageData();
        
        message.actionPlayerId = localPlayerIndex;

        message.actionType = actionType;
        message.player = players[localPlayerIndex].GetPlayerMessageData();
        message.playerBoard = playerBoards[localPlayerIndex].GetBoardMessageData();
        message.stacks = GameManager.instance.stackOfRoundCard;

        NetworkManager.instance.SendMessage(message);

        Logger.Log(message);
    }


    public bool isActionTypeEndTurn(ActionType actionType)
    {
        if(NotEndTurnTypeList.Contains(actionType))
            return false;
        return true;
    }

    public bool isActionTypeStartTurn(ActionType actionType)
    {
        if(StartTurnTypeList.Contains(actionType))
            return true;
        return false;
    }

    public void Round()
    {
        if ( this.RoundFlag )
        {
            //1-2. 턴을 진행 중이라면
            if ( !this.endTurnFlag )
            {
                // 대기
            }

            else //endTurnFlag is true --> 1-3. 플레이어의 턴이 끝남.
            {
                if(currentPlayerId == localPlayerIndex) { 
                    SendMessage(queueActionType);
                    queueActionType = ActionType.NONE;
                    // SendMessage(); 
                }

                //1-4. 다음 턴을 부여받을 플레이어 찾기
                //1-4-1. 턴을 부여받을 플레이어가 존재 -> Round 그대로 진행
                if ( this.findNextPlayer() )
                {
                    //... 그대로 진행
                    // Debug.Log("Move to Next Turn");
                    Debug.Log( "현재 플레이어들의 남은 가족수는 " + 
                    "\n" + this.players[0].remainFamilyOfCurrentPlayer +
                    "\n" + this.players[1].remainFamilyOfCurrentPlayer +
                    "\n" + this.players[2].remainFamilyOfCurrentPlayer +
                    "\n" + this.players[3].remainFamilyOfCurrentPlayer );

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
            MainboardUIController.instance.ResetBoard();
            //2-1. 수확라운드인지 체크 후 수확 실행
            if (this.checkHarvest())
            {
                Debug.Log("수확 라운드 진행중...");
                for(int i = 0; i < 4; i++)
                {
                    playerBoards[i].Cultivate();
                    playerBoards[i].Feeding();
                    playerBoards[i].Breeding();
                }
            }

            for(int i=0; i<4; i++)
            {
                if(ResourceManager.instance.getResourceOfPlayer(i, "baby") != 0)
                {
                    ResourceManager.instance.minusResource(i, "baby", 1);
                    ResourceManager.instance.addResource(i, "family", 1);
                    playerBoards[i].AddFamily();
                }
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
                RoundFlag = false;
                //FinishAgriCola();
                this.currentRound = 0;
                EndPhase.instance.EndGame();
            } 
        }
    }

    void UpdateData()
    {
        isDataUpdated = false;
        if(msgData.actionType == ActionType.MEETING_PLACE_END || msgData.actionType == ActionType.MEETING_PLACE)
        {
            SidebarManager.instance.FirstPlayerIcon(msgData.actionPlayerId);
        }

        for(int i = 0; i < 4; i++)
        {
            SidebarManager.instance.SidebarUpdate(i);
        }

        Logger.Log(msgData);

        if(msgData.actionType != ActionType.CHANGE_RESOURCE && msgData.actionType != ActionType.MOVE_ANIMAL)
        {
            Debug.Log("actionType : " + msgData.actionType);
            if(isActionTypeStartTurn(msgData.actionType))
                MainboardUIController.instance.ActivatePlayerOnButton(msgData.actionType, msgData.actionPlayerId);
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
        if ( this.players[ index ].remainFamilyOfCurrentPlayer != 0 )
        {
            Debug.Log("Next turn is player " + index);
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
    public void preRound()
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
                result =  (int)StackBehavior.copse;
                break;

            case "grove":
                result =  (int)StackBehavior.grove;
                break;

            case "travelingTheater":
                result =  (int)StackBehavior.travelingTheater;
                break;

            case "clayPit":
                result =  (int)StackBehavior.clayPit;
                break;

            case "forest":
                result =  (int)StackBehavior.forest;
                break;

            case "dirtPit":
                result =  (int)StackBehavior.dirtPit;
                break;

            case "reedField":
                result =  (int)StackBehavior.reedField;
                break;

            case "fishing":
                result =  (int)StackBehavior.fishing;
                break;

            case "sheepMarket":
                result =  (int)StackBehavior.sheepMarket;
                break;

            case "westernQuarry":
                result =  (int)StackBehavior.westernQuarry;
                break;

            case "pigMarket":
                result =  (int)StackBehavior.pigMarket;
                break;

            case "easternQuarry":
                result =  (int)StackBehavior.easternQuarry;
                break;

            case "cattleMarket":
                result =  (int)StackBehavior.cattleMarket;
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

    public void SetTurnList()
    {
        ActionType[] notEndTurnList = {
            ActionType.LESSON_ONE,
            ActionType.LESSON_TWO,
            ActionType.FENCE,
            ActionType.FARM_EXPANSION,
            ActionType.MEETING_PLACE,
            ActionType.FARMLAND,
            ActionType.MAJOR_FACILITIES,
            ActionType.GRAIN_UTILIZATION,
            ActionType.BASIC_FAMILY_INCREASE,
            ActionType.HOUSE_RENOVATION,
            ActionType.FIELD_FARMING,
            ActionType.URGENT_FAMILY_INCREASE,
            ActionType.FARM_REMODELING,
        };

        ActionType[] startTurnTypeList = {
            ActionType.BUSH,
            ActionType.DOBULE_BUSH,
            ActionType.RESOURCE_MARKET,
            ActionType.CLAY_PIT,
            ActionType.LESSON_ONE,
            ActionType.LESSON_TWO,
            ActionType.TROUPE,
            ActionType.FARM_EXPANSION,
            ActionType.MEETING_PLACE,
            ActionType.SEED,
            ActionType.FARMLAND,
            ActionType.DATALLER,
            ActionType.FOREST,
            ActionType.DIRT_PIT,
            ActionType.REED_FIELD,
            ActionType.FISHING,
            ActionType.MAJOR_FACILITIES,
            ActionType.FENCE,
            ActionType.FENCE_END,
            ActionType.GRAIN_UTILIZATION,
            ActionType.SHEEP_MARKET,
            ActionType.BASIC_FAMILY_INCREASE,
            ActionType.WESTREN_QUARRY,
            ActionType.HOUSE_RENOVATION,
            ActionType.PIG_MARKET,
            ActionType.VEGETABLE_SEEDS,
            ActionType.COW_MARKET,
            ActionType.EASTERN_QUARRY,
            ActionType.FIELD_FARMING,
            ActionType.URGENT_FAMILY_INCREASE,
            ActionType.FARM_REMODELING,
        };

        for(int i = 0; i < notEndTurnList.Length; i++)
        {
            NotEndTurnTypeList.Add(notEndTurnList[i]);
        }

        for(int i = 0; i < startTurnTypeList.Length; i++)
        {
            StartTurnTypeList.Add(startTurnTypeList[i]);
        }
    }
}

//스택이 쌓이는 라운드카드들
public enum StackBehavior
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