using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasternQuarryRoundAct : ButtonParents
{
  /* 동부채석장 행동
    1. 해당 행동 Onclick
    2. 누적된 돌의 개수만큼 플레이어 자원개수 증가
  */

    public int playerIndex = 0;
    public bool isPlayerTurn = true;
    public int stone = 4; //누적된 돌이 4개라 가정

    public override void OnClick()
        {
        ResourceManager.instance.addResource(playerIndex, "stone", stone);
        }
}
