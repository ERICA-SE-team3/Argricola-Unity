using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 갈대밭
public class MainActGrainSeed : ButtonParents
{

    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        // if(playerIndex == userPlayerId)
        // {   
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "wheat", 1);

        //채소 장수 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("vegetableSeller"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("vegetableSeller");
        }

        //장작 채집자 카드
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("woodPicker"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("woodPicker");
        }

        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " wheat!");

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        GameManager.instance.endTurnFlag = true;
        // }
    }

    
}
