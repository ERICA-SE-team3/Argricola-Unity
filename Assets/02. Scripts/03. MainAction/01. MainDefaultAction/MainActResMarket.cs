using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActResMarket : ButtonParents
{
    public int playerIndex;
    int stack;


    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[2]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.RESOURCE_MARKET;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[2] = true;
            GameManager.instance.actionQueue.Enqueue("resMarket");
            GameManager.instance.PopQueue();
        }
    }
    public void ResMarketStart()
    {
        int id = GameManager.instance.localPlayerIndex;


        ResourceManager.instance.addResource(id, "reed", 1);
        ResourceManager.instance.addResource(id, "stone", 1);
        ResourceManager.instance.addResource(id, "food", 1);

        //확인 message
        Debug.Log("Player " + id + " get " + "reed and stone and food");

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        GameManager.instance.PopQueue();
    }
}
