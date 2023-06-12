using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMarketRoundAct : ButtonParents
{
    /* 양 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 양의 마리수만큼 가져오기
    3. 양의 자원현황 늘려주기
    4. 개인판에서 양을 배치시키는 함수 실행
    */
    
    public int playerIndex;

    //stack 정보 가져오기
    int stack;

    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("sheepMarket")];
        text.text = stack.ToString();
    }

    private void OnEnable() {
        Debug.Log(GameManager.instance.stackOfRoundCard.Length);
        Debug.Log("sheepMarket" + GameManager.instance.getStackBehavior("sheepMarket"));
        if(GameManager.instance.stackOfRoundCard.Length != 0)
        {
            Debug.Log(GameManager.instance.stackOfRoundCard.Length);
            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("sheepMarket")] = 1; 
        }
        else
            stack = 0;
    }

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[17]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.SHEEP_MARKET;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[17] = true;
            GameManager.instance.actionQueue.Enqueue("sheepMarket");
            GameManager.instance.PopQueue();

        }
    }

    public void SheepMarketStart()
    {
        int id = GameManager.instance.localPlayerIndex;

        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("sheepMarket")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(id, "sheep", stack );

        //확인 message
        Debug.Log("Player " + id + " get " + stack + " sheep!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("sheepMarket")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        // StartSheep();   // player보드에 양을 배치하는 함수 호출 (함수명은 아직 정해지지 않음)
        GameManager.instance.PopQueue();
    }

}

