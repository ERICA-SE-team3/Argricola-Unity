using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActFarming : ButtonParents
{
    public override void OnClick(){

    }
    //===============================================
    public void _OnClick() {
        //농지
        GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ].TestStartInstallFarm();

        //장작 채집자 카드
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("woodPicker"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("woodPicker");
        }
    }
}
