using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActFarming : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public override void OnClick(){
        GameManager.instance.actionQueue.Enqueue("shedBuild");

        GameManager.instance.PopQueue();
    }
    
    public void FarmingStart()
    {   
        GameManager.instance.playerBoards[ playerIndex ].StartInstallFarm();
    }

}
