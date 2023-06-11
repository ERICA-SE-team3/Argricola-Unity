using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSeedRoundAct : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
            playerIndex = GameManager.instance.getCurrentPlayerId();
        // if(playerIndex == userPlayerId)
        // {
            //행동을 했음 표시
          GameManager.instance.IsDoingAct[24] = true;
            GameManager.instance.actionQueue.Enqueue("vegetableSeed");
            GameManager.instance.PopQueue();

        // }
    }
    public void VegetableSeedStart()
    {   
        ResourceManager.instance.addResource(playerIndex, "vegetable", 1);

        Debug.Log("Player " + playerIndex + " get " + 1 + " vegetable!");

        ResourceManager.instance.minusResource(playerIndex, "family", 1);
        GameManager.instance.PopQueue();
    }
}
