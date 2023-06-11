using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 점토채굴장
public class MainActClayPit : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    //stack 정보 가져오기
    int stack;

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        // if(playerIndex == userPlayerId)
        // {
        //행동을 했음 표시
        GameManager.instance.IsDoingAct[3] = true;

        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];

        ResourceManager.instance.addResource(playerIndex, "clay", stack * 2);

        Debug.Log("Player " + playerIndex + " get " + stack * 2 + " clay!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")] = 0;

        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
        // }
    }
}

