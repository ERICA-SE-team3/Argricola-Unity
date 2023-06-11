using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActResMarket : ButtonParents
{
<<<<<<< HEAD
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public GameObject resMarket;
=======
    public int playerIndex;
>>>>>>> develop
    int stack;

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        if(playerIndex == userPlayerId)
        {
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[2] = true;
            GameManager.instance.actionQueue.Enqueue("resMarket");
            GameManager.instance.PopQueue();
        }
    }
    public void ResMarketStart()
    {
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "stone", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "food", 1);

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + "reed and stone and food");

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

<<<<<<< HEAD
        resMarket.SetActive(false);
        GameManager.instance.endTurnFlag = true;
        // }
=======
        GameManager.instance.PopQueue();
>>>>>>> develop
    }
}
