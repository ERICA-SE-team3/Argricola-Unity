using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActExpand : ButtonParents
{
    public int playerIndex;
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        GameManager.instance.actionQueue.Enqueue("houseBuild");
        GameManager.instance.actionQueue.Enqueue("shedBuild");
        GameManager.instance.PopQueue();
    }

//====================================================================


}
