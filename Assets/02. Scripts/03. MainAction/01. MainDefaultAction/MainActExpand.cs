using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActExpand : ButtonParents
{
    public int playerIndex;
    public int localPlayerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        localPlayerIndex = GameManager.instance.localPlayerIndex;
        if(playerIndex == localPlayerIndex && GameManager.instance.IsDoingAct[6]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.FARM_EXPANSION_END;
            GameManager.instance.SendMessage(ActionType.FARM_EXPANSION);
            
            ResourceManager.instance.minusResource( playerIndex, "family",1 );
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[6] = true;
            GameManager.instance.actionQueue.Enqueue("houseBuild");
            //그리고 또는 
            GameManager.instance.actionQueue.Enqueue("shedBuild");
            GameManager.instance.PopQueue();
        }
    }

    public void StartHouseInstall() {
        Camera mainCamera = Camera.main;
        mainCamera.GetComponent<CameraManager>().ShowPlayer(localPlayerIndex);
        GameManager.instance.playerBoards[localPlayerIndex].StartInstallHouse();
    }

    public void StartBuildShed() {
        Camera mainCamera = Camera.main;
        mainCamera.GetComponent<CameraManager>().ShowPlayer(localPlayerIndex);
        GameManager.instance.playerBoards[localPlayerIndex].StartInstallShed();
    }
}
