using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 점토채굴장
public class MainActClayPit : ButtonParents
{
    int stack;
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;
    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];

        ResourceManager.instance.addResource(playerIndex, "clay", stack * 2);

        Debug.Log("Player " + playerIndex + " get " + stack * 2 + " clay!");

        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")] = 0;

        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        GameManager.instance.endTurnFlag = true;
        // }
    }
}
