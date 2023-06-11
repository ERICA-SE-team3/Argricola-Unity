using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActFarming : ButtonParents
{
    public int playerIndex;

    public override void OnClick(){
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int localPlayerIndex = GameManager.instance.localPlayerIndex;
        if(playerIndex == localPlayerIndex)
        {
            ResourceManager.instance.minusResource( playerIndex, "family",1 );
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[9] = true;
            GameManager.instance.actionQueue.Enqueue("farming");

            //장작 채집자 카드
            if (GameManager.instance.players[playerIndex].HasJobCard("woodPicker"))
            {
                GameManager.instance.players[playerIndex].ActCard("woodPicker");
            }
            
            GameManager.instance.PopQueue();
        }


    }
    
    public void FarmingStart()
    {   
        GameManager.instance.playerBoards[ playerIndex ].StartInstallFarm();
    }

}
