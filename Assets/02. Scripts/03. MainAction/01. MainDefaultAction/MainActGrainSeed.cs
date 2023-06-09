using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActGrainSeed : ButtonParents
{
    public override void OnClick()
    {
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "wheat", 1);

        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " wheat!");

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        GameManager.instance.endTurnFlag = true;

    }
}
