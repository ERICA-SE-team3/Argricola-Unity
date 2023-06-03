using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrgentWishChildrenRoundAct : ButtonParents
{
  /* 급한가족늘리기 행동 ( 방이 없어도 가족 늘리기 )
    1. 해당 행동 Onclick
    2. 닥치고 기본가족늘리기 행동 실행
  */
    public int playerIndex = 0;
    public bool isPlayerTurn = true;

    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "family", 1);
    }
}
