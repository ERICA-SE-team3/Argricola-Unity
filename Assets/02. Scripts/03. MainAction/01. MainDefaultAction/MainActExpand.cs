using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainActExpand : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public GameObject expand;
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
        GameManager.instance.actionQueue.Enqueue("houseBuild");
        GameManager.instance.actionQueue.Enqueue("shedBuild");

        expand.GetComponent<Button>().enabled = false;
        GameManager.instance.PopQueue();
        // }


    }
}
