using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager
    public static GameManager instance;

    //player���� ���� ArrayList, players
    public List<Player> players = new List<Player>();

    //player�� board
    public List<PlayerBoard> playerBoards = new List<PlayerBoard>();

    //stack�� �ִ� Roundcard
    public int[] stackOfRoundCard;

    //���� ������ player index
    public int currentPlayerId;

    //���� ���� - ��Ȯ�������� üũ�ϱ� ����
    public int currentRound;

    //������ message ����
    MessageData message = new MessageData();

    //������ ���̴� ����ī���
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

    //���� ������ ���� flag��
    //1. ���� ������ ��Ÿ���� flag
    public bool RoundFlag = true;
    //2. �� �÷��̾��� turn ( ���� �� �ϳ��� �� �� )�� ������ ��Ÿ���� flag
    public bool endTurnFlag = false;
    


    private void Start()
    {
        //GameManager Singleton
        GameManager.instance = this;

        //player start
        for (int i=0; i<4; i++)
        {
            Player temp = new Player();
            this.players.Add(temp);
        }

        //playerboard start
        for (int i = 0; i < 4; i++)
        {
            PlayerBoard tempB = new PlayerBoard();
            this.playerBoards.Add(tempB);
        }

        //Initialize Player's resources
        this.DummyInit();

        //give first to player1
        this.Init();

        //����ī����� ���� �ʱ�ȭ
        this.stackOfRoundCard = new int[13];

        //���� ���� �ʱ�ȭ
        this.currentRound = 1;

        //ù ���� �غ�
        //stack ����
        //���� ī�� Ȱ��ȭ
        this.preRound();
    }

    private void Update() // 1�����Ӹ��� ����ǰ� ������ ���� ����.
    {
        
        //1. ���� ����
        if ( this.RoundFlag )
        {
            //1-1. �� �÷��̾�� �� �ο� - currentPlayerId ���� - Update�� ��� ����Ǵ��� ���� ������ �ʴ� �� �������״� �̷��� �ᵵ ��� ���� �������...?
            this.foundFirstPlayer();
            
            //1-2. ���� ���� ���̶��
            if ( !this.endTurnFlag )
            {   
                //...��ٸ� == �ƹ��͵� ����
            }

            else //endTurnFlag is true --> 1-3. �÷��̾��� ���� ����.
            {
                //1-4. ���� ���� �ο����� �÷��̾� ã��
                //1-4-1. ���� �ο����� �÷��̾ ���� -> Round �״�� ����
                if ( this.findNextPlayer() )
                {
                    //... �״�� ����
                }

                //1-4-2. ���� �ο����� �÷��̾ ���� -> Round ���� �������� �Ѿ
                else
                {
                    this.RoundFlag = false;
                }
            }

        }

        //2. ���� ��ü�� ����.
        else
        {
            //2-1. ��Ȯ�������� üũ �� ��Ȯ ����
            if (this.checkHarvest())
            {
                //��Ȯ���� ����
            }

            //2-2. ���� ���� ������ �������� ( ������ ���� ���� üũ )
            if ( this.checkFinalRound() )
            {
                //2-2-1. ���� ���� �غ� �� ����
                this.preRound();
            }
            else
            {
                //2-2-2. ���� ����
                //...
            } 
        }

        //���� ����� ����.

    }

    //--------------------------------------------------------------------------------------------

    //Update to NetworkManager
    public void sendmsg( ActionType actiontype )
    {
        this.message.actionPlayerId = this.currentPlayerId;
        this.message.actionType = ActionType.BUSH;
        this.message.player = this.players[currentPlayerId].GetPlayerMessageData();
        this.message.playerBoard = this.playerBoards[currentPlayerId].GetBoardMessageData();
        
        //NetworkManager�� ���� DB�� ����
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

    //�־��� playerId�� ���� playerId�� ã�� �Լ�
    int findNextPlayerId( int playerId )
    {
        return (playerId + 1) % this.players.Count ;
    }

    //���� �÷��̾ ã�� ��ü �Լ� // ������ : true , ���� ���� : false
    bool findNextPlayer()
    {
        //���� �÷��̾� �ε��� ���
        int index = findNextPlayerId(this.currentPlayerId);

        //������ �÷��̾ ã�� �� ���� �ݺ�
        //�ᱹ ��ã�Ƽ� ���� �ѹ��� ���� ���� ���� or ã���� ���� �÷��̾�
        while ( !( index == this.currentPlayerId ) )
        {
            //�ش� �÷��̾ ���� ���� 0�̴�. -> ���� �÷��̾� ã�ƺ���
            if (this.players[index].remainFamilyOfCurrentPlayer == 0)
            {
                index = findNextPlayerId(this.currentPlayerId);
            }
            //�ش� �÷��̾ ���� ���� 0�� �ƴϴ� -> �� turn ��.
            else
            {
                this.currentPlayerId = index;
                return true;
            }
        }

        //while�� �������� -> ��� ���� �ߴ� �÷��̾�� ���ƿ�.
        //1. �� �� �� �÷��̾��� ���� ���� 0�� �ƴ϶�� - ���� ����
        if ( this.players[ currentPlayerId ].remainFamilyOfCurrentPlayer != 0 )
        {
            this.currentPlayerId = index;
            return true;
        }
        
        //2. �굵 0 -> ��� �÷��̾��� ���� ���� 0 -> ���� ����
        return false;

    }

    void UpdateCurrentRound()
    {
        this.currentRound = this.currentRound + 1;
    }

    //���� �غ�
    void preRound()
    {
        //�ൿ stack ����
        this.incrementStack();
        //����ī�� Ȱ��ȭ
        //...
        //currentRoundUpdate
        UpdateCurrentRound();

        //RoundFlag�� true��
        this.RoundFlag = true;
    }

    bool checkHarvest()
    {
        if ( (this.currentRound == 4) || this.currentRound == 7 || this.currentRound == 9 ||
            this.currentRound == 11 || this.currentRound == 13 || this.currentRound == 14 ) {
            return true;
        }
        else { return false;  }
    }

    //������ �������� check
    bool checkFinalRound()
    {
        if (this.currentRound == 14)
        {
            return true;
        }
        return false;
    }

}
