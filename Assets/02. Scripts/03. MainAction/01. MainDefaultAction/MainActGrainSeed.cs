using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 갈대밭
public class MainActGrainSeed : ButtonParents
{

    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public GameObject grainSeed;

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {   
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "wheat", 1);

        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " wheat!");

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        grainSeed.GetComponent<Button>().enabled = false;
        
        GameManager.instance.endTurnFlag = true;
        // }
    }
}
