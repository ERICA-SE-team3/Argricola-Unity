using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDevelopRoundAct : MonoBehaviour
{
  /* 농장개조 행동 (농장 개조 이후 울타리치기 )
    1. 해당 행동 Onclick
    2. 사용자의 집 정보 가져오기 ( 종류, 방 개수 )
    3. 종류와 개수에 알맞게 자원소모     ex. 나무집 방 2개 -> 갈대 1개 + 흙 2개 소모
    4. 울타리치기
  */
    public int playerIndex = 0;
    public bool isPlayerTurn = true;

    public override void OnClick()
        {
          PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
          StartInstallHouse();
          SelectUser();
          if (isPlayerTurn && HasWoods())
          {
            // StartInstallFence() 호출할 때 유저가 가지고있는 나무의 개수를 넘겨주거나, 함수 내부적으로 가져와야 할듯
            // 왜냐면 울타리 설치한 만큼만 minusResource() 해야해서
            StartInstallFence()
            ResourceManager.instance.minusResource(playerIndex, "wood", wood - useWood);
            ResourceManager.instance.addResource(playerIndex, "fence", useWood);
          }          
        }

    private bool HasWoods(){
        wood = ResourceManager.instance.getResourceOfPlayer(playerIndex, "wood");
        if (wood > 0)
            return true;
        else
            return false;
    }
}
