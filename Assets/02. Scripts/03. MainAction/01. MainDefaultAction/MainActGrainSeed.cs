using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActGrainSeed : ButtonParents
{
    public int playerIndex = 0;

    public override void OnClick()
    {
        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "wheat", 1);

        //채소 장수 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("vegetableSeller"))
        {
            ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "vegetable", 1);
            Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get 1 vegetable additionaly because of VEGETABLESELLER");
        }

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " wheat!");

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}
