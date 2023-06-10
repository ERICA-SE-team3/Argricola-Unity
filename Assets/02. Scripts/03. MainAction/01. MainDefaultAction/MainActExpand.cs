using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActExpand : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
        GameManager.instance.actionQueue.Enqueue("houseBuild");
        GameManager.instance.actionQueue.Enqueue("shedBuild");

        GameManager.instance.PopQueue();
        // }
    }
}
