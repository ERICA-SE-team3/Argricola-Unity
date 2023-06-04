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

    //게임 진행을 위한 flag들
    //1. 라운드 진행을 나타내는 flag
    public bool RoundFlag = true;
    //2. 각 플레이어의 turn ( 가족 수 하나당 한 턴 )이 끝남을 나타내는 flag
    public bool endTurnFlag = false;
    
    private void Start()
    {

        Debug.Log("Let's Ready the Game!!!");  

        //GameManager Singleton
        GameManager.instance = this;

        //player start
        for (int i=0; i<4; i++)
        {
            Player temp = new Player();
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

         //라운드카드들의 스택 초기화
        this.stackOfRoundCard = new int[13];

        //현재 라운드 초기화
        this.currentRound = 1;
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
            Debug.Log("Current Round is " + this.currentRound);
            //1-2. 턴을 진행 중이라면
            if ( !this.endTurnFlag )
            {
                //...기다림 == 아무것도 안함
                Debug.Log("Player " + this.currentPlayerId + "Wait to Action... ");
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
            this.stackOfRoundCard[i]++;
        }
    }

    void foundFirstPlayer()
    {
        for(int i=0; i<4; i++)
        {
            if ( this.players[i].isFirstPlayer )
            {
                this.currentPlayerId = i;
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

        Debug.Log("33333333333333333333333333333");

        //적합한 플레이어를 찾을  까지 반복
        //결국 못찾아서 덱스 한바퀴 돌면 라운드 종료 or 찾으면 다음 플레이어
        Debug.Log("00000000000000000000");
        for(int i=1; i<4; i++)
        {
            if (this.players[index].remainFamilyOfCurrentPlayer == 0)
            {
                index = findNextPlayerId(this.currentPlayerId);
            }
            //해당 플레이어가 가족 수가 0이 아니다 -> 너 turn 해.
            else
            {
                this.currentPlayerId = index;
                return true;
            }
        }
        
        Debug.Log("111111111111111111111111111");

        //for문을 빠져나옴 -> 방금 턴을 했던 플레이어로 돌아옴.
        //1. 이 때 그 플레이어의 가족 수가 0이 아니라면 - 라운드 진행
        if ( this.players[ currentPlayerId ].remainFamilyOfCurrentPlayer != 0 )
        {
            return true;
        }

        Debug.Log("222222222222222222222222222");

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
        //...
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

}
