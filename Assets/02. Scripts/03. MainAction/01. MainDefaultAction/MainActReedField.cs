using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainActReedField : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public GameObject reedField;
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

            reedField.GetComponent<Button>().enabled = false;
            
            GameManager.instance.endTurnFlag = true;
        // }
    }
}
