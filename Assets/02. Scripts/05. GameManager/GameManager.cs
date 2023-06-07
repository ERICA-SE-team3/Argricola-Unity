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

    //roundcard list
    public GameObject roundList;

    public List<GameObject> roundcards = new List<GameObject>();

    //������ message ����
    MessageData message = new MessageData();

    //������ ���̴� ����ī���
    public enum stackBehavior
    {
        copse, // ����
        grove, //��Ǯ
        clayPit, //����ä����
        travelingTheater, //�����ش�
        forest, //��
        dirtPit, //�� ä����
        reedField, //�����
        fishing, //����
        sheepMarket, //�� ����
        westernQuarry, //���� ä����
        pigMarket, //���� ����
        easternQuarry, //���� ä����
        cattleMarket //�� ����
    }

    //���� ������ ���� flag��
    //1. ���� ������ ��Ÿ���� flag
    public bool RoundFlag = true;
    //2. �� �÷��̾��� turn ( ���� �� �ϳ��� �� �� )�� ������ ��Ÿ���� flag
    public bool endTurnFlag = false;
    
    public void Start()
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

        ////for test -> player2's family : 3
        //this.players[2].family = 5;

        //���� ī�� ��������
        for (int i=0; i<14; i++)
        {
            //���� ī�� �޾ƿ���
            GameObject tmp = this.roundList.transform.GetChild(i).gameObject;
            this.roundcards.Add(tmp);
            this.roundcards[i].SetActive(false);
        }

        //����ī����� ���� �ʱ�ȭ
        this.stackOfRoundCard = new int[13];

        //���� ���� �ʱ�ȭ
        this.currentRound = 0;

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
            Debug.Log("Current Round is " + this.currentRound);
            //1-2. ���� ���� ���̶��
            if ( !this.endTurnFlag )
            {
                //...��ٸ� == �ƹ��͵� ����
                Debug.Log("Player " + this.currentPlayerId + "Wait to Action... ");
            }

            else //endTurnFlag is true --> 1-3. �÷��̾��� ���� ����.
            {
                //1-4. ���� ���� �ο����� �÷��̾� ã��
                //1-4-1. ���� �ο����� �÷��̾ ���� -> Round �״�� ����
                if ( this.findNextPlayer() )
                {
                    //... �״�� ����
                    Debug.Log("Move to Next Turn");
                    this.endTurnFlag = false;
                }

                //1-4-2. ���� �ο����� �÷��̾ ���� -> Round ���� �������� �Ѿ
                else
                {
                    Debug.Log("Round is Over");
                    this.endTurnFlag = false;
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
                Debug.Log("��Ȯ ���� ������...");
                //��Ȯ���� ����
            }

            //2-2. ���� ���� ������ �������� ( ������ ���� ���� üũ )
            if ( !this.checkFinalRound() )
            {
                //2-2-1. ���� ���� �غ� �� ����
                this.preRound();
            }
            else
            {
                //2-2-2. ���� ����
                //...
                Debug.Log("Game is Over!");
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
                break;
            }
        }
    }

    //�־��� playerId�� ���� playerId�� ã�� �Լ�
    int findNextPlayerId( int playerId )
    {
        return (playerId + 1) % 4 ;
    }

    //���� �÷��̾ ã�� ��ü �Լ� // ������ : true , ���� ���� : false
    bool findNextPlayer()
    {
        //���� �÷��̾� �ε��� ���
        int index = findNextPlayerId(this.currentPlayerId);

        //������ �÷��̾ ã�� �� ���� �ݺ�
        //�ᱹ ��ã�Ƽ� ���� �ѹ��� ���� ���� ���� or ã���� ���� �÷��̾�
        for(int i=0; i<3; i++)
        {
            if (this.players[index].remainFamilyOfCurrentPlayer == 0)
            {
                index = findNextPlayerId(index);
            }
            //�ش� �÷��̾ ���� ���� 0�� �ƴϴ� -> �� turn ��.
            else
            { 
                this.currentPlayerId = index;
                return true;
            }
        }

        //for���� �������� -> ��� ���� �ߴ� �÷��̾�� ���ƿ�.
        //1. �� �� �� �÷��̾��� ���� ���� 0�� �ƴ϶�� - ���� ����
        if ( this.players[ currentPlayerId ].remainFamilyOfCurrentPlayer != 0 )
        {
            Debug.Log("Next turn is player " + this.currentPlayerId);
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
        this.roundcards[this.currentRound].SetActive(true);

        //currentRoundUpdate
        this.UpdateCurrentRound();

        //�� �÷��̾�� ���� �� ���󺹱�
        for(int i=0; i<4; i++)
        {
            this.players[i].remainFamilyOfCurrentPlayer = this.players[i].family;
        }

        //Round�� ù ���� �÷��̾�� ���� �ѱ�
        this.foundFirstPlayer();

        //RoundFlag�� true��
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

    //������ �������� check
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

