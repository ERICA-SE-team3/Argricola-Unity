using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMarketRoundAct : ButtonParents
{
    /* 돼지 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 돼지의 마리수만큼 가져오기
    3. 돼지의 자원현황 늘려주기
    4. 개인판에서 소를 배치시키는 함수 실행
    */
    
    public int playerIndex = 0;

    //stack 정보 가져오기
    int stack;

    public override void OnClick()
    {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("pigMarket")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "pig", stack );

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " pig!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("pigMarket")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        // StartPig();  // player보드에 돼지를 배치하는 함수 호출 (함수명은 아직 정해지지 않음)

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}