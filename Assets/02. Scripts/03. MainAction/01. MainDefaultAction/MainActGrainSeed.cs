using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActGrainSeed : ButtonParents
{
    public int playerIndex = 0;

    public int stacked = 1;
    public override void OnClick()
    {
        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "wheat", stacked);

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stacked + " wheat!");

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}
