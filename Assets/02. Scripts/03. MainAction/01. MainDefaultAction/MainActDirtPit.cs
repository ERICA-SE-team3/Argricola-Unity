using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 흙 채굴장
public class MainActDirtPit : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public GameObject dirtPit;
    int stack;
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("dirtPit")];

        ResourceManager.instance.addResource(playerIndex, "clay", stack * 1);

        Debug.Log("Player " + playerIndex + " get " + stack * 1 + " clay!");

        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("dirtPit")] = 0;

        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        dirtPit.GetComponent<Button>().enabled = false;

        GameManager.instance.endTurnFlag = true;


        // }
    }
}
