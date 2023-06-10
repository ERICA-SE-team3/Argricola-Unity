using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActReedField : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    int stack;

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
            stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")];

            ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", stack);

            Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " reed!");

            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")] = 0;

            ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

            GameManager.instance.endTurnFlag = true;
        // }
    }

    public void _Onclick() {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", stack);

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " reed!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}
