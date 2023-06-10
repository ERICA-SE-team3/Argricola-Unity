using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActFarming : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public override void OnClick(){
        playerIndex = GameManager.instance.getCurrentPlayerId();
        GameManager.instance.actionQueue.Enqueue("farming");

        GameManager.instance.PopQueue();

        //장작 채집자 카드
        if (GameManager.instance.players[playerIndex].HasJobCard("woodPicker"))
        {
            GameManager.instance.players[playerIndex].ActCard("woodPicker");
        }
        
    }
    
    public void FarmingStart()
    {   
        GameManager.instance.playerBoards[ playerIndex ].StartInstallFarm();
    }

}
