using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternQuarryRoundAct : ButtonParents
{
  /* 서부채석장 행동
    1. 해당 행동 Onclick
    2. 누적된 돌의 개수만큼 플레이어 자원개수 증가
  */

    public int playerIndex = 0;
    public bool isPlayerTurn = true;

    //stack 정보 가져오기
    int stack;



    public override void OnClick()
    {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "stone", stack);

        //돌집게 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasSubCard("stoneClamp"))
        {
            ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "stone", 1);
            Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get 1 stone additionaly because of STONECLAMP");
        }
        
        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " stone(rock)!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}
