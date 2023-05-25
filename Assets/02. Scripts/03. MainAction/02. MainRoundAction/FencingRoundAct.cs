using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencingRoundAct : ButtonParents
{
  /* 울타리 행동
    1. 해당 행동 Onclick
    2. 사용자의 나무 개수 정보를 가져옴
      2-1. 나무가 있는지 확인
    3. 사용자의 나무 개수만큼 울타리로 변경
  */

    public int wood;

    public int playerIndex = 0;
    public bool isPlayerTurn = true;

    public int useWood = 6; //울타리 치기 행동에 사용한 나무가 6개라고 가정

    // 나무가 있는지 확인
    private bool HasWoods(){
        wood = ResourceManager.instance.getResourceOfPlayer(playerIndex, "wood");
        if (wood > 0)
            return true;
        else
            return false;
    }

    public override void OnClick()
        {
          PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
          if (isPlayerTurn && HasWoods())
          {
            // StartInstallFence() 호출할 때 유저가 가지고있는 나무의 개수를 넘겨주거나, 함수 내부적으로 가져와야 할듯
            // 왜냐면 울타리 설치한 만큼만 minusResource() 해야해서
            StartInstallFence()
            ResourceManager.instance.minusResource(playerIndex, "wood", wood - useWood);
            ResourceManager.instance.addResource(playerIndex, "fence", useWood);
          }
        }
}
