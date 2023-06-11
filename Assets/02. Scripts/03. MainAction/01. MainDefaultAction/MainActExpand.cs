using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainActExpand : ButtonParents
{
    public int playerIndex;

    public GameObject expand;
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        if(playerIndex == userPlayerId)
        {
            ResourceManager.instance.minusResource( playerIndex, "family",1 );
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[6] = true;
            GameManager.instance.actionQueue.Enqueue("houseBuild");
            //그리고 또는 
            GameManager.instance.actionQueue.Enqueue("shedBuild");
            GameManager.instance.PopQueue();
        }
    }

<<<<<<< HEAD
        expand.GetComponent<Button>().enabled = false;
        GameManager.instance.PopQueue();
        // }


=======
    public void StartHouseInstall() {
        GameManager.instance.playerBoards[playerIndex].StartInstallHouse();
    }

    public void StartBuildShed() {
        GameManager.instance.playerBoards[playerIndex].StartInstallShed();
>>>>>>> develop
    }
}
