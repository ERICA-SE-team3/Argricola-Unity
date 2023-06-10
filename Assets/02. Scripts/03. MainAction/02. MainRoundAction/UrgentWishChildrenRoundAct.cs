using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrgentWishChildrenRoundAct : ButtonParents
{
  /* 급한가족늘리기 행동 ( 방이 없어도 가족 늘리기 )
    1. 해당 행동 Onclick
    2. 닥치고 기본가족늘리기 행동 실행
  */
    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            ResourceManager.instance.addResource(playerIndex, "baby", 1);
            GameManager.instance.endTurnFlag = true;
        // }
    }
}
