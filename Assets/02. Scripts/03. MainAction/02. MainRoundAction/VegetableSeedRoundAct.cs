using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSeedRoundAct : ButtonParents
{
    public int playerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[24]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.VEGETABLE_SEEDS;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[24] = true;
            GameManager.instance.actionQueue.Enqueue("vegetableSeed");
            GameManager.instance.PopQueue();

        }
    }
    public void VegetableSeedStart()
    {   
        int id = GameManager.instance.localPlayerIndex;

        ResourceManager.instance.addResource(id, "vegetable", 1);

        Debug.Log("Player " + id + " get " + 1 + " vegetable!");

        ResourceManager.instance.minusResource(id, "family", 1);
        GameManager.instance.PopQueue();
    }
}
