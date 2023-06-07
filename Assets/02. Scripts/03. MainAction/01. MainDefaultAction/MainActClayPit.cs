using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActClayPit : ButtonParents
{
    public int playerIndex = 0;

    //stack 정보 가져오기
    int stack;

    public override void OnClick()
    {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "clay", stack * 2);

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack * 2 + " clay!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;

    }
}
