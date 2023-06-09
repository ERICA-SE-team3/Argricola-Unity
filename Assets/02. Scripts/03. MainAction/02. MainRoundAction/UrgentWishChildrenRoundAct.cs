using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrgentWishChildrenRoundAct : ButtonParents
{
  /* 급한가족늘리기 행동 ( 방이 없어도 가족 늘리기 )
    1. 해당 행동 Onclick
    2. 닥치고 기본가족늘리기 행동 실행
  */
    public int playerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[27]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.URGENT_FAMILY_INCREASE;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[27] = true;
            GameManager.instance.actionQueue.Enqueue("urgentWishChildren");
            GameManager.instance.PopQueue();
        }
    }
    public void UrgentWishChildrenStart()
    {
        int id = GameManager.instance.localPlayerIndex;

        // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
        ResourceManager.instance.minusResource(id, "family", 1);  
        ResourceManager.instance.addResource(id, "baby", 1);
        GameManager.instance.PopQueue();
    }
}
