using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMarketRoundAct : ButtonParents
{
    /* 소 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 소의 마리수만큼 가져오기
    3. 소의 자원현황 늘려주기
    4. 개인판에서 소를 배치시키는 함수 실행
    */
    
    public int playerIndex = 0;

    //stack 정보 가져오기
    int stack;

    public override void OnClick()
    {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("cattleMarket")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "cow", stack);

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " cow!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("cattleMarket")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        // PR 리뷰 수정사항 : 정해지지 않은 함수명 주석처리
        // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        // StartCow();  // player보드에 소를 배치하는 함수 호출 (함수명은 아직 정해지지 않음)

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}
