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
    
    //round�� �Ѿ �� �Ǵ� ���
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

        //����ī����� ���� �ʱ�ȭ
        this.stackOfRoundCard = new int[13];

        //���� ���� �ʱ�ȭ
        this.currentRound = 1;
    }

    private void Update()
    {
        //2.���� ����

        //stack ����
        this.incrementStack();

        //���� �� �ִ� �ڿ� ��ġ - ���� ���� ���� 1��, �ٸ� ���� ���ÿ� ����Ͽ� ��ġ - ���� ������ �̱���
        //...

        //2-1. ���� ī�� Ȱ��ȭ - SetActive
        //...

        //2-2. �� �÷��̾�� �ൿ �ο� - currentPlayerId ����
        this.foundFirstPlayer();

        //���� ���� - ���� ������ ���� ������ �ݺ�
        while ( true )
        {
            //2-3. �ൿ�� �ο����� �÷��̾�� �ൿ��.
            //2-4. Onclick()���� ��ȿ�� �˻��ϰ�, �ൿ�� �Ѵ�
            //2-4-1.stack �ڿ�ĭ�� �ൿ�ߴٸ�, stack ��ġ�� �ʱ�ȭ���ش�.
            //2-5. Onclick() �������� NetworkManager�� �����Ѵ�. -> DoAct()

            //2-6. (�����÷��̾� index + 1 ) % 4 �� �÷��̾�� �ѱ��
            //2-6-0. ���� �÷��̾� �ε����� ����Ѵ�.
            int index = this.findNextPlayerId(this.currentPlayerId);

            //2-6-1. ���� ���밡���� ���� ���� 0�̸� �ٷ� ��������, �ٸ� �÷��̾���� ���� ���� 0�̶��, ���� ����� �����Ѵ�,
            //�ٸ� �÷��̾���� ���� ���� 0�̶��, ���� ����� �����Ѵ�,
            int check = this.findNextPlayer();
            if (check == 0) // ���� �÷��̾�
            {
                continue;
            }
            else //���� ����
            {
                break;
            }
        }
        
        //3. ���� ����

        //3-1. �� ���尡 ��Ȯ���� ���� üũ
        if( this.checkHarvest() )
        {
            //��Ȯ���� ����
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

    int findNextPlayerId( int playerId )
    {
        return (playerId + 1) % this.players.Count ;
    }

    int findNextPlayer()
    {
        //���� �÷��̾� �ε��� ���
        int index = findNextPlayerId(this.currentPlayerId);

        //������ �÷��̾ ã�� �� ���� �ݺ�
        //�ᱹ ��ã�Ƽ� ���� �ѹ��� ���� ���� ���� or ã���� ���� �÷��̾�
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
