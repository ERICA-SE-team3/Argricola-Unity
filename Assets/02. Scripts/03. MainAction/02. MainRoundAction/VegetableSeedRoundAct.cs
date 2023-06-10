using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSeedRoundAct : ButtonParents
{
    public int playerIndex = 0;

    public override void OnClick()
    {
        GameManager.instance.actionQueue.Enqueue("vegetableSeed");
        GameManager.instance.PopQueue();
    }
    public void VegetableSeedStart()
    {   
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "vegetable", 1);

        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " vegetable!");

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);
        GameManager.instance.PopQueue();
    }
}
