using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActReedField : ButtonParents
{
    int stack;

    public override void OnClick()
    {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")];

        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", stack);

        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " reed!");

        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")] = 0;

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        GameManager.instance.endTurnFlag = true;

    }
}
