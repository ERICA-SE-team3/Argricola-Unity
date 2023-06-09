using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActExpand : ButtonParents
{
    public int playerIndex = 0;
    public int playerReed;
    public int playerWood;
    public int playerClay;
    public int playerRock;
    public override void OnClick()
    {
        //그리고 또는 외양간 짓기
    }

//====================================================================

    public void _OnClick() {
        //방 만들기
        GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ].TestStartInstallHouse();

        //
    }

}
