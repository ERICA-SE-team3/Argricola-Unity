using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager
    public static GameManager instance;

    //player들을 담을 ArrayList, players
    public List<Player> players = new List<Player>();

    //player의 board
    public List<PlayerBoard> playerBoards = new List<PlayerBoard>();

    //stack이 있는 Roundcard
    public int[] stackOfRoundCard;

    //현재 차례인 player index
    public int currentPlayerId;

    //현재 라운드 - 수확라운드인지 체크하기 위함
    public int currentRound;

    //소통할 message 형식
    MessageData message = new MessageData();

    //스택이 쌓이는 라운드카드들
    public enum stackBehavior
    {
        deombul,
        soopool,
        jeomto,
        yoorang,
        soop,
        heuk,
        galdae,
        fishing,
        sheepMarket,
        westernQuarry,
        pigMarket,
        easternQuarry,
        cattleMarket
    }
    
    //round를 넘어갈 때 판단 요소
    public enum RoundManage
    {
        NextPlayer,
        RoundFinish
    }

    private void Start()
    {
        //GameManager Singleton
        GameManager.instance = this;

        //player start
        Player player1 = new Player(); Player player2 = new Player(); Player player3 = new Player(); Player player4 = new Player();
        this.players.Add(player1); this.players.Add(player2); this.players.Add(player3); this.players.Add(player4);

        //playerboard start
        PlayerBoard playerboard1 = new PlayerBoard(); PlayerBoard playerboard2 = new PlayerBoard(); PlayerBoard playerboard3 = new PlayerBoard(); PlayerBoard playerboard4 = new PlayerBoard();
        this.playerBoards.Add(playerboard1); this.playerBoards.Add(playerboard2); this.playerBoards.Add(playerboard3); this.playerBoards.Add(playerboard4);

        //Initialize Player's resources
        this.DummyInit();

        //give first to player1
        this.Init();

        //라운드카드들의 스택 초기화
        this.stackOfRoundCard = new int[13];

        //현재 라운드 초기화
        this.currentRound = 1;
    }

    private void Update()
    {
        //2.라운드 진행

        //stack 증가
        this.incrementStack();

        //얻을 수 있는 자원 배치 - 스택 없는 곳은 1개, 다른 곳은 스택에 비례하여 배치 - 메인 보드판 미구현
        //...

        //2-1. 라운드 카드 활성화 - SetActive
        //...

        //2-2. 선 플레이어에게 행동 부여 - currentPlayerId 갱신
        this.foundFirstPlayer();

        //라운드 진행 - 종료 조건이 나올 때까지 반복
        while ( true )
        {
            //2-3. 행동을 부여받은 플레이어는 행동함.
            //2-4. Onclick()에서 유효성 검사하고, 행동을 한다
            //2-4-1.stack 자원칸을 행동했다면, stack 수치를 초기화해준다.
            //2-5. Onclick() 마지막에 NetworkManager와 소통한다. -> DoAct()

            //2-6. (현재플레이어 index + 1 ) % 4 인 플레이어로 넘긴다
            //2-6-0. 다음 플레이어 인덱스를 계산한다.
            int index = this.findNextPlayerId(this.currentPlayerId);

            //2-6-1. 현재 가용가능한 가족 수가 0이면 바로 다음으로, 다른 플레이어들의 가족 수도 0이라면, 라운드 종료로 진행한다,
            //다른 플레이어들의 가족 수도 0이라면, 라운드 종료로 진행한다,
            int check = this.findNextPlayer();
            if (check == 0) // 다음 플레이어
            {
                continue;
            }
            else //라운드 종료
            {
                break;
            }
        }
        
        //3. 라운드 종료

        //3-1. 이 라운드가 수확라운드 인지 체크
        if( this.checkHarvest() )
        {
            //수확라운드 진행
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

    //Initialize
    //for game
    void Init()
    {
        this.players[0].isFirstPlayer = true;
    }

    //for dummy data(Debug)
    void DummyInit()
    {
        //dummy players initialize
        for (int i = 0; i < 4; i++)
        {
            this.players[i].pig = 3; this.players[i].cow = 3; this.players[i].sheep = 3;
            this.players[i].wheat = 3; this.players[i].vegetable = 3;
            this.players[i].wood = 3; this.players[i].rock = 3; this.players[i].reed = 3; this.players[i].clay = 3;
            this.players[i].food = 3; this.players[i].begging = 3;
            this.players[i].family = 3; this.players[i].fence = 3; this.players[i].shed = 3; this.players[i].room = 3;
        }
    }

    void incrementStack()
    {
        for(int i=0; i<13; i++)
        {
            this.stackOfRoundCard[i]++;
        }
    }

    void foundFirstPlayer()
    {
        for(int i=0; i<this.players.Count; i++)
        {
            if ( players[i].isFirstPlayer )
            {
                currentPlayerId = i;
                break;
            }
        }
    }

    int findNextPlayerId( int playerId )
    {
        return (playerId + 1) % this.players.Count ;
    }

    int findNextPlayer()
    {
        //다음 플레이어 인덱스 계산
        int index = findNextPlayerId(this.currentPlayerId);

        //적합한 플레이어를 찾을 떄 까지 반복
        //결국 못찾아서 덱스 한바퀴 돌면 라운드 종료 or 찾으면 다음 플레이어
        while ( !( index == this.currentPlayerId ) )
        {
            if (this.players[index].remainFamilyOfCurrentPlayer == 0)
            {
                index = findNextPlayerId(this.currentPlayerId);
            }
            else
            {
                this.currentPlayerId = index;
                return (int) RoundManage.NextPlayer;
            }

        }

        return (int)RoundManage.RoundFinish;

    }

    bool checkHarvest()
    {
        if ( (this.currentRound == 4) || this.currentRound == 7 || this.currentRound == 9 ||
            this.currentRound == 11 || this.currentRound == 13 || this.currentRound == 14 ) {
            return true;
        }
        else { return false;  }
    }

}
