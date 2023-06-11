using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Player
{
    public const int MAXROOM = 5;

    //0. 플레이어 id
    public int id;

    //1. 자원 정보
    public int pig, cow, sheep;
    public int wheat, vegetable;
    public int wood, rock, reed, clay;
    public int food, begging;
    public int family, fence, shed, room, baby;

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
        msgdata.baby = this.baby;
        msgdata.fence = this.fence;
        msgdata.shed = this.shed;
        msgdata.room = this.room;

        msgdata.jobcard_owns = this.jobcard_owns.ToList();
        msgdata.jobcard_hands = this.jobcard_hands.ToList();
        msgdata.remainFamilyOfCurrentPlayer = this.remainFamilyOfCurrentPlayer;
        //card

        msgdata.subcard_owns = this.subcard_owns.ToList();
        msgdata.subcard_hands = this.subcard_hands.ToList();

        msgdata.maincard_owns = this.maincard_owns.ToList();

        return msgdata;
    }

    public void SetPlayerMessageData(PlayerMessageData data)
    {
        this.isFirstPlayer = data.isFirstPlayer;
        this.pig = data.pig;
        this.cow = data.cow;
        this.sheep = data.sheep;
        this.wheat = data.wheat;
        this.vegetable = data.vegetable;
        this.wood = data.wood;
        this.rock = data.rock;
        this.reed = data.reed;
        this.clay = data.clay;
        this.food = data.food;
        this.begging = data.begging;
        this.family = data.family;
        this.fence = data.fence;
        this.shed = data.shed;
        this.room = data.room;

        this.remainFamilyOfCurrentPlayer = data.remainFamilyOfCurrentPlayer;

        //card
        this.jobcard_owns = data.jobcard_owns.ToList();
        this.jobcard_hands = data.jobcard_hands.ToList();

        this.subcard_owns = data.subcard_owns.ToList();
        this.subcard_hands = data.subcard_hands.ToList();

        this.maincard_owns = data.maincard_owns.ToList();
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
        this.family = 2; this.fence = 0; this.shed = 0; this.room = 2; this.baby = 0;
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
            Debug.Log("Player " + this.id + " has no jobcards!");
            return false;
        }

        //card가 있다면
        switch (cardName) 
        {
            case "magician":
                //magician카드가 있다면
                if (this.jobcard_owns.Contains( (int)Cards.magician) )
                {
                    return true;
                }
                break;

            case "woodCutter":
                if (this.jobcard_owns.Contains((int)Cards.woodCutter))
                {
                    return true;
                }
                break;

            case "vegetableSeller":
                if (this.jobcard_owns.Contains((int)Cards.vegetableSeller))
                {
                    return true;
                }
                break;
            case "woodPicker":
                //magician카드가 있다면
                if (this.jobcard_owns.Contains((int)Cards.woodPicker))
                {
                    return true;
                }
                break;

            case "wallMaster":
                if (this.jobcard_owns.Contains((int)Cards.wallMaster))
                {
                    return true;
                }
                break;

            case "stoneCutter":
                if (this.jobcard_owns.Contains((int)Cards.stoneCutter))
                {
                    return true;
                }
                break;

            case "organicFarmer":
                if (this.jobcard_owns.Contains((int)Cards.organicFarmer))
                {
                    return true;
                }
                break;

            case "pigBreeder":
                if (this.jobcard_owns.Contains((int)Cards.pigBreeder))
                {
                    return true;
                }
                break;
        }

        //해당 카드가 없다면
        return false;
    }

    public bool HasSubCard( string cardName )
    {
        //card가 없으면 return false
        if ( this.jobcard_owns.Count == 0 )
        {
            Debug.Log("Player " + this.id + " has no Subcards!");
            return false;
        }

        //card가 있다면
        switch (cardName) 
        {
            case "stoneClamp":
                //magician카드가 있다면
                if (this.subcard_owns.Contains( (int)Cards.stoneClamp) )
                {
                    return true;
                }
                break;

            case "clayMining":
                if (this.subcard_owns.Contains((int)Cards.clayMining))
                {
                    return true;
                }
                break;

            case "woodBoat":
                if (this.subcard_owns.Contains((int)Cards.woodBoat))
                {
                    return true;
                }
                break;
            case "rake":
                
                if (this.subcard_owns.Contains((int)Cards.rake))
                {
                    return true;
                }
                break;

            case "watterBottle":
                if (this.subcard_owns.Contains((int)Cards.watterBottle))
                {
                    return true;
                }
                break;

            case "woodYard":
                if (this.subcard_owns.Contains((int)Cards.woodYard))
                {
                    return true;
                }
                break;

            case "butter":
                if (this.subcard_owns.Contains((int)Cards.butter))
                {
                    return true;
                }
                break;

            case "bottle":
                if (this.subcard_owns.Contains((int)Cards.bottle))
                {
                    return true;
                }
                break;
        }

        //해당 카드가 없다면
        return false;
    }
    
    public bool HasMainCard( string cardName )
    {
        //card가 없으면 return false
        if ( this.maincard_owns.Count == 0 )
        {
            Debug.Log("Player " + this.id + " has no maincards!");
            return false;
        }

        //card가 있다면
        switch (cardName) 
        {
            case "fireplace1":
                //magician카드가 있다면
                if (this.subcard_owns.Contains( (int)Cards.fireplace1) )
                {
                    return true;
                }
                break;

            case "fireplace2":
                if (this.subcard_owns.Contains((int)Cards.fireplace2))
                {
                    return true;
                }
                break;

            case "cookingHearth1":
                if (this.subcard_owns.Contains((int)Cards.cookingHearth1))
                {
                    return true;
                }
                break;
            case "cookingHearth2":
                
                if (this.subcard_owns.Contains((int)Cards.cookingHearth2))
                {
                    return true;
                }
                break;

            case "clayOven":
                if (this.subcard_owns.Contains((int)Cards.clayOven))
                {
                    return true;
                }
                break;

            case "stoneOven":
                if (this.subcard_owns.Contains((int)Cards.stoneOven))
                {
                    return true;
                }
                break;

            case "joinery":
                if (this.subcard_owns.Contains((int)Cards.joinery))
                {
                    return true;
                }
                break;

            case "pottery":
                if (this.subcard_owns.Contains((int)Cards.pottery))
                {
                    return true;
                }
                break;

            case "basket":
                if (this.subcard_owns.Contains((int)Cards.basket))
                {
                    return true;
                }
                break;

            case "well":
                if (this.subcard_owns.Contains((int)Cards.well))
                {
                    return true;
                }
                break;
        }

        //해당 카드가 없다면
        return false;
    }

    public void GetJobCard( string cardName ) {
        //card가 있다면
        switch (cardName) 
        {
            case "magician":
                //magician카드가 있다면
                if (this.jobcard_hands.Contains( (int)Cards.magician) )
                {
                    this.jobcard_owns.Add((int)Cards.magician);
                    Debug.Log("player 0" + " get MAGICIAN job card!");
                }
                break;

            case "woodCutter":
                //woodCutter카드가 있다면
                if (this.jobcard_hands.Contains( (int)Cards.woodCutter) )
                {
                    this.jobcard_owns.Add((int)Cards.woodCutter);
                    Debug.Log("player 0" + " get woodCutter job card!");
                }
                break;

            case "vegetableSeller":
                if (this.jobcard_hands.Contains( (int)Cards.vegetableSeller) )
                {
                    this.jobcard_owns.Add((int)Cards.vegetableSeller);
                    Debug.Log("player 0" + " get vegetableSeller job card!");
                }
                break;
            case "woodPicker":
                if (this.jobcard_hands.Contains( (int)Cards.woodPicker) )
                {
                    this.jobcard_owns.Add((int)Cards.woodPicker);
                    Debug.Log("player 0" + " get woodPicker job card!");
                }
                break;

            case "wallMaster":
                if (this.jobcard_hands.Contains( (int)Cards.wallMaster) )
                {
                    this.jobcard_owns.Add((int)Cards.wallMaster);
                    Debug.Log("player 0" + " get wallMaster job card!");
                }
                break;

            case "stoneCutter":
                if (this.jobcard_hands.Contains( (int)Cards.stoneCutter) )
                {
                    this.jobcard_owns.Add((int)Cards.stoneCutter);
                    Debug.Log("player 0" + " get stoneCutter job card!");
                }
                break;

            case "organicFarmer":
                if (this.jobcard_hands.Contains( (int)Cards.organicFarmer) )
                {
                    this.jobcard_owns.Add((int)Cards.organicFarmer);
                    Debug.Log("player 0" + " get organicFarmer job card!");
                }
                break;

            case "pigBreeder":
                if (this.jobcard_hands.Contains( (int)Cards.pigBreeder) )
                {
                    this.jobcard_owns.Add((int)Cards.pigBreeder);
                    Debug.Log("player 0" + " get pigBreeder job card!");
                }
                break;
        }
    } 
    
    public void GetSubCard( string cardName ) {
        
        //card가 있다면
        switch (cardName) 
        {
            case "stoneClamp":
                //stoneClamp 카드가 있다면
                if (this.subcard_hands.Contains( (int)Cards.stoneClamp) && this.wood>1)
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "wood",1 );

                    //목재소
                    if( this.HasJobCard( "woodYard" ) ) {
                        ResourceManager.instance.addResource( this.id, "wood", 1 );
                        Debug.Log( "Player " + this.id + " get 1 wood because of WOODYARD" );
                    }

                    this.subcard_owns.Add((int)Cards.stoneClamp);
                    Debug.Log("player 0" + " get stoneClamp job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "clayMining":
                if (this.subcard_hands.Contains( (int)Cards.clayMining)&& this.food>1)
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "food",1 );
                    this.subcard_owns.Add((int)Cards.clayMining);
                    Debug.Log("player 0" + " get clayMining job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "woodBoat":
                if (this.subcard_hands.Contains( (int)Cards.woodBoat) && this.wood>2)
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "wood",2 );

                    //목재소
                    if( this.HasJobCard( "woodYard" ) ) {
                        ResourceManager.instance.addResource( this.id, "wood", 1 );
                        Debug.Log( "Player " + this.id + " get 1 wood because of WOODYARD" );
                    }

                    this.subcard_owns.Add((int)Cards.woodBoat);
                    Debug.Log("player 0" + " get woodBoat job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;
            case "rake":
                
                if (this.subcard_hands.Contains( (int)Cards.rake) && this.wood>1)
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "wood",1 );

                    //목재소
                    if( this.HasJobCard( "woodYard" ) ) {
                        ResourceManager.instance.addResource( this.id, "wood", 1 );
                        Debug.Log( "Player " + this.id + " get 1 wood because of WOODYARD" );
                    }

                    this.subcard_owns.Add((int)Cards.rake);
                    Debug.Log("player 0" + " get rake job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "watterBottle":
                if (this.subcard_hands.Contains( (int)Cards.watterBottle) && this.clay>1)
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "clay",1 );
                    this.subcard_owns.Add((int)Cards.watterBottle);
                    Debug.Log("player 0" + " get watterBottle job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "woodYard":
                if (this.subcard_hands.Contains( (int)Cards.woodYard)&& this.rock>2 )
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "rock",2 );
                    this.subcard_owns.Add((int)Cards.woodYard);
                    Debug.Log("player 0" + " get woodYard job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "butter":
                if (this.subcard_hands.Contains( (int)Cards.butter)&& this.wood>1 )
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "wood",1 );

                    //목재소
                    if( this.HasJobCard( "woodYard" ) ) {
                        ResourceManager.instance.addResource( this.id, "wood", 1 );
                        Debug.Log( "Player " + this.id + " get 1 wood because of WOODYARD" );
                    }

                    this.subcard_owns.Add((int)Cards.butter);
                    Debug.Log("player 0" + " get butter job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "bottle":
                if (this.subcard_hands.Contains( (int)Cards.bottle)&& this.wood>this.family && this.food>this.family )
                {
                    //비용
                    ResourceManager.instance.minusResource( id, "wood",this.family );
                    ResourceManager.instance.minusResource( id, "food",this.family );

                    //목재소
                    if( this.HasJobCard( "woodYard" ) ) {
                        ResourceManager.instance.addResource( this.id, "wood", 1 );
                        Debug.Log( "Player " + this.id + " get 1 wood because of WOODYARD" );
                    }

                    this.subcard_owns.Add((int)Cards.bottle);
                    Debug.Log("player 0" + " get bottle job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;
        }

    }

    public void GetMainCard( string cardName )
    {   
        //card가 있다면
        switch (cardName) 
        {
            case "fireplace1":
                if ( !this.maincard_owns.Contains( (int)Cards.fireplace1) && this.clay>2 )
                {
                    ResourceManager.instance.minusResource(id, "clay", 2);
                    this.maincard_owns.Add((int)Cards.fireplace1);
                    Debug.Log("player 0" + " get fireplace1 job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "fireplace2":
                if ( !this.maincard_owns.Contains( (int)Cards.fireplace2) && this.clay> 3 )
                {
                    ResourceManager.instance.minusResource(id, "clay", 3);
                    this.maincard_owns.Add((int)Cards.fireplace2);
                    Debug.Log("player 0" + " get fireplace2 job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "cookingHearth1":
                if ( !this.maincard_owns.Contains( (int)Cards.cookingHearth1) )
                {
                    this.maincard_owns.Add((int)Cards.cookingHearth1);
                    Debug.Log("player 0" + " get cookingHearth1 job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;
            case "cookingHearth2":
                
                if ( !this.maincard_owns.Contains( (int)Cards.cookingHearth2) )
                {
                    this.maincard_owns.Add((int)Cards.cookingHearth2);
                    Debug.Log("player 0" + " get cookingHearth2 job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "clayOven":
                if ( !this.maincard_owns.Contains( (int)Cards.clayOven) && this.clay> 3 && this.rock >1 )
                {
                    ResourceManager.instance.minusResource(id, "clay", 3);
                    ResourceManager.instance.minusResource(id, "stone", 1);
                    if( this.HasJobCard( "stoneCutter" ) ) {
                        ResourceManager.instance.addResource( this.id, "stone", 1 );
                        Debug.Log( "Player " + this.id + " get 1 stone because of STONECUTTER" );
                    }
                    this.maincard_owns.Add((int)Cards.clayOven);
                    Debug.Log("player 0" + " get clayOven job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "stoneOven":
                if ( !this.maincard_owns.Contains( (int)Cards.stoneOven) && this.clay> 1 && this.rock >3 )
                {
                    ResourceManager.instance.minusResource(id, "clay", 1);
                    ResourceManager.instance.minusResource(id, "stone", 3);
                    if( this.HasJobCard( "stoneCutter" ) ) {
                        ResourceManager.instance.addResource( this.id, "stone", 1 );
                        Debug.Log( "Player " + this.id + " get 1 stone because of STONECUTTER" );
                    }
                    this.maincard_owns.Add((int)Cards.stoneOven);
                    Debug.Log("player 0" + " get stoneOven job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "joinery":
                if ( !this.maincard_owns.Contains( (int)Cards.joinery) && this.wood> 2 && this.rock >2)
                {
                    ResourceManager.instance.minusResource(id, "wood", 2);
                    ResourceManager.instance.minusResource(id, "stone", 2);
                    if( this.HasJobCard( "stoneCutter" ) ) {
                        ResourceManager.instance.addResource( this.id, "stone", 1 );
                        Debug.Log( "Player " + this.id + " get 1 stone because of STONECUTTER" );
                    }

                    //목재소
                    if( this.HasJobCard( "woodYard" ) ) {
                        ResourceManager.instance.addResource( this.id, "wood", 1 );
                        Debug.Log( "Player " + this.id + " get 1 wood because of WOODYARD" );
                    }

                    this.maincard_owns.Add((int)Cards.joinery);
                    Debug.Log("player 0" + " get joinery job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "pottery":
                if ( !this.maincard_owns.Contains( (int)Cards.pottery)&& this.wood> 2 && this.rock >2 )
                {
                    ResourceManager.instance.minusResource(id, "clay", 2);
                    ResourceManager.instance.minusResource(id, "stone", 2);
                    if( this.HasJobCard( "stoneCutter" ) ) {
                        ResourceManager.instance.addResource( this.id, "stone", 1 );
                        Debug.Log( "Player " + this.id + " get 1 stone because of STONECUTTER" );
                    }
                    this.maincard_owns.Add((int)Cards.pottery);
                    Debug.Log("player 0" + " get pottery job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "basket":
                if ( !this.maincard_owns.Contains( (int)Cards.basket) && this.reed> 2 && this.rock >2 )
                {
                    ResourceManager.instance.minusResource(id, "reed", 2);
                    ResourceManager.instance.minusResource(id, "stone", 2);
                    if( this.HasJobCard( "stoneCutter" ) ) {
                        ResourceManager.instance.addResource( this.id, "stone", 1 );
                        Debug.Log( "Player " + this.id + " get 1 stone because of STONECUTTER" );
                    }
                    this.maincard_owns.Add((int)Cards.basket);
                    Debug.Log("player 0" + " get basket job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;

            case "well":
                if ( !this.maincard_owns.Contains( (int)Cards.well)&& this.wood> 1 && this.rock >3 )
                {
                    ResourceManager.instance.minusResource(id, "wood", 1);
                    ResourceManager.instance.minusResource(id, "stone", 3);

                    //목재소
                    if( this.HasJobCard( "woodYard" ) ) {
                        ResourceManager.instance.addResource( this.id, "wood", 1 );
                        Debug.Log( "Player " + this.id + " get 1 wood because of WOODYARD" );
                    }

                    if( this.HasJobCard( "stoneCutter" ) ) {
                        ResourceManager.instance.addResource( this.id, "stone", 1 );
                        Debug.Log( "Player " + this.id + " get 1 stone because of STONECUTTER" );
                    }
                    this.maincard_owns.Add((int)Cards.well);
                    Debug.Log("player 0" + " get well job card!");
                }
                else {
                    Debug.Log( "You can't get this card!" );
                }
                break;
        }

    }

    public void ActCard( string cardName ) {
        switch (cardName) 
        {
            //직업카드
            case "magician":
                ResourceManager.instance.addResource(this.id, "wood", 1);
                ResourceManager.instance.addResource(this.id, "wheat", 1);
                Debug.Log("Player " + this.id + " get 1 wood and 1 wheat additionaly because of MAGICIAN");
                break;

            case "woodCutter":
                ResourceManager.instance.addResource(this.id, "wood", 1);
                Debug.Log("Player " + this.id + " get 1 wood additionaly because of WOODCUTTER");
                break;

            case "vegetableSeller":
                ResourceManager.instance.addResource(this.id, "vegetable", 1);
                Debug.Log("Player " + this.id + " get 1 vegetable additionaly because of VEGETABLESELLER");
                break;

            case "woodPicker":
                ResourceManager.instance.addResource(this.id, "wood", 1);
                Debug.Log("Player " + this.id + " get 1 wood additionaly because of WOODPICKER");
                break;

            case "wallMaster":
                ResourceManager.instance.addResource(this.id, "food",3);
                Debug.Log("Player " + this.id + " get 1 food additionaly because of WALLMASTER");
                break;

            case "stoneCutter":
                ResourceManager.instance.addResource(this.id, "stone",1);
                Debug.Log("Player " + this.id + " get 1 stone additionaly because of WALLMASTER");
                break;

            case "organicFarmer":
                //점수계산에 구현할 예정
                break;

            case "pigBreeder":
                //GameManager 라운드 안에 조건으로 넣어야할지도.
                break;


            //보조설비 카드
            case "stoneClamp":
                ResourceManager.instance.addResource(this.id, "stone", 1);
                Debug.Log("Player " + this.id + " get 1 stone additionaly because of stoneCLAMP");
                break;

            ///////////////여기부터 Action에 미적용

            case "clayMining":
                ResourceManager.instance.addResource(this.id, "clay", 3);
                Debug.Log("Player " + this.id + " get 1 clay additionaly because of clayMining");
                break;

            case "woodBoat":
                ResourceManager.instance.addResource(this.id, "food", 1);
                ResourceManager.instance.addResource(this.id, "reed", 1);
                Debug.Log("Player " + this.id + " get 1 food and reed additionaly because of woodBoat");
                break;
                
            case "rake":
                ResourceManager.instance.addResource(this.id, "food", 3);
                Debug.Log("Player " + this.id + " get 1 food additionaly because of rake");
                break;

            case "watterBottle":
                //우리 하나당 가축을 2마리 더 키울 수 있습니다.
                break;

            case "woodYard":
                ResourceManager.instance.addResource(this.id, "wood", 1);
                Debug.Log("Player " + this.id + " get 1 wood additionaly because of woodYard");
                break;

            case "butter":
                ResourceManager.instance.addResource(this.id, "food", (int)(this.sheep / 3));
                ResourceManager.instance.addResource(this.id, "food", (int)(this.cow / 2));
                Debug.Log("Player " + this.id + " get 1 food  additionaly because of butter");
                break;

            case "bottle":
                //점수계산에 이미 적용
                break;


            //주요설비 카드
            case "fireplace1":
                //변환
                break;

            case "fireplace2":
                //변환
                break;

            case "cookingHearth1":
                //변환
                break;
            case "cookingHearth2":
                //변환
                break;

            case "clayOven":
                //빵굽기
                ResourceManager.instance.minusResource( this.id, "wheat",1 );
                ResourceManager.instance.addResource(this.id, "food",5);
                Debug.Log("Player " + this.id + " change 1 wheat to 5 food because of clayOven");
                break;

            case "stoneOven":
                //빵굽기
                ResourceManager.instance.minusResource( this.id, "wheat",1 );
                ResourceManager.instance.addResource(this.id, "food",4);
                Debug.Log("Player " + this.id + " change 1 wheat to 4 food because of clayOven");
                break;

            case "joinery":
                //수확 기능만 여기다 부여. 점수계산 기능은 점수계산에 적용
                ResourceManager.instance.minusResource(this.id, "wood", 1);
                ResourceManager.instance.addResource(this.id, "food", 2);
                Debug.Log("Player " + this.id + " change 1 wood to 2 food because of joinery");
                break;

            case "pottery":
                //수확 기능만 여기다 부여. 점수계산 기능은 점수계산에 적용
                ResourceManager.instance.minusResource(this.id, "clay", 1);
                ResourceManager.instance.addResource(this.id, "food", 2);
                Debug.Log("Player " + this.id + " change 1 clay to 2 food because of pottery");
                break;

            case "basket":
                //수확 기능만 여기다 부여. 점수계산 기능은 점수계산에 적용
                ResourceManager.instance.minusResource(this.id, "reed", 1);
                ResourceManager.instance.addResource(this.id, "food", 3);
                Debug.Log("Player " + this.id + " change 1 reed to 3 food because of basket");
                break;

            case "well":
                //다음 다섯 라운드에 라운드마다 음식 1개를 얻음
                //GameManager 라운드 진행 중간에 넣어야 듯
                break;
        }
    }

    public string GetCarNameString( int cardNum ) {
        string result = "";
        switch (cardNum) 
        {
            case 0:
                result =  "magician";
                break;
                
            case 1:
                result =  "woodCutter";
                break;

            case 2:
                result =  "vegetableSeller";
                break;

            case 5:
                result =  "woodPicker";
                break;

            case 4:
                result =  "wallMaster";
                break;

            case 3:
                result =  "stoneCutter";
                break;

            case 6:
                result =  "organicFarmer";
                break;

            case 7:
                result =  "pigBreeder";
                break;

            case 8:
            result =  "stoneClamp";
            break;
                
            case 9:
                result =  "clayMining";
                break;

            case 10:
                result =  "woodBoat";
                break;

            case 11:
                result =  "rake";
                break;

            case 12:
                result =  "watterBottle";
                break;

            case 13:
                result =  "woodYard";
                break;

            case 14:
                result =  "butter";
                break;

            case 15:
                result =  "bottle";
                break;

            case 16:
                result =  "fireplace1";
                break;
                
            case 17:
                result =  "fireplace2";
                break;

            case 18:
                result =  "cookingHearth1";
                break;

            case 19:
                result =  "cookingHearth2";
                break;

            case 20:
                result =  "clayOven";
                break;

            case 21:
                result =  "stoneOven";
                break;

            case 22:
                result =  "joinery";
                break;

            case 23:
                result =  "pottery";
                break;
            
            case 24:
                result =  "basket";
                break;

            case 25:
                result =  "well";
                break;
        }

        return result;
    }

}



