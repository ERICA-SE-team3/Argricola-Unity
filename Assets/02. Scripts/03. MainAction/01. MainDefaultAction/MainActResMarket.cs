using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActResMarket : ButtonParents
{
    public override void OnClick()
    {

        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "stone", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "food", 1);


        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " reed/stone/food!");

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        GameManager.instance.endTurnFlag = true;

    }
}
