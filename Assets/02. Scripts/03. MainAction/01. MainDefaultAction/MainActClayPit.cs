using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActClayPit : ButtonParents
{
    int stack;

    public override void OnClick()
    {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];

        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "clay", stack * 2);

        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack * 2 + " clay!");

        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")] = 0;

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        GameManager.instance.endTurnFlag = true;

    }
}
