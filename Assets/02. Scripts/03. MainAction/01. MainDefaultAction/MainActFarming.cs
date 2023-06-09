using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActFarming : ButtonParents
{
    public int playerIndex;
    public int localPlayerIndex;

    public override void OnClick(){
        playerIndex = GameManager.instance.getCurrentPlayerId();
        localPlayerIndex = GameManager.instance.localPlayerIndex;
        if(playerIndex == localPlayerIndex && GameManager.instance.IsDoingAct[9]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.FARMLAND_END;
            GameManager.instance.SendMessage(ActionType.FARMLAND);

            ResourceManager.instance.minusResource( playerIndex, "family",1 );
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[9] = true;
            GameManager.instance.actionQueue.Enqueue("farming");
            
            GameManager.instance.PopQueue();

            //장작 채집자 카드
            if (GameManager.instance.players[playerIndex].HasJobCard("woodPicker"))
            {
                GameManager.instance.players[playerIndex].ActCard("woodPicker");
            }
        }


    }
    
    public void FarmingStart()
    {   
        Camera mainCamera = Camera.main;
        mainCamera.GetComponent<CameraManager>().ShowPlayer(localPlayerIndex);
        GameManager.instance.playerBoards[ localPlayerIndex ].StartInstallFarm();
    }

}
