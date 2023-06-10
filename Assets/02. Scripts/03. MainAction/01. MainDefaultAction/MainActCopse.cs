using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// 덤불
public class MainActCopse : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    //stack 정보 가져오기
    int stack;
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    // 사용자가 '덤불'행동을 클릭했을 때
    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("copse")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource( playerIndex, "wood", stack * 1);

        //확인 message
        Debug.Log("Player " + playerIndex + " get " + stack +" wood!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("copse")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
        // }
    }
}
