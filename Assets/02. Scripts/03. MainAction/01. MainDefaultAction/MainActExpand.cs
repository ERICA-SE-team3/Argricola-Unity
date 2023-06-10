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

    public void _OnClick() {
        //방 만들기
        GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ].TestStartInstallHouse();

        //만약 흙방을 1개이상 만들거나 흙집을 돌집으로 고친다면
        //초벽질공 - 음식 3개
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("woodCutter"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("woodCutter");
        }
    }

}
