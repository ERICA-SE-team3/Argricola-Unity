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
    
    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    //public int sheep = 3;   //누적된 양의 마리수가 3마리라고 가정

    //stack 정보 가져오기
    int stack;

    public override void OnClick()
    {
        GameManager.instance.actionQueue.Enqueue("sheepMarket");
        GameManager.instance.PopQueue();
    }
    public void SheepMarketStart()
    {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("sheepMarket")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(playerIndex, "sheep", stack );

        //확인 message
        Debug.Log("Player " + playerIndex + " get " + stack + " sheep!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("sheepMarket")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        // StartSheep();   // player보드에 양을 배치하는 함수 호출 (함수명은 아직 정해지지 않음)
        GameManager.instance.PopQueue();
    }

}

