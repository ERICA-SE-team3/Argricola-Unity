using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDevelopRoundAct : ButtonParents
{
  /* 집 개조 행동 (집 개조 이후 주요설비 or 보조설비 )
    1. 해당 행동 Onclick
    2. 사용자의 집 정보 가져오기 ( 종류, 방 개수 )
    3. 종류와 개수에 알맞게 자원소모     ex. 나무집 방 2개 -> 갈대 1개 + 흙 2개 소모
    4. 주요설비 또는 보조설비 하나 고르기
  */

    public int playerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId)
        {
            //행동을 했음 표시
          GameManager.instance.IsDoingAct[22] = true;
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            GameManager.instance.actionQueue.Enqueue("hdHouseDevelop");
            //한 후에, 주요설비 및 보조설비 구매 <-- 미구현
            GameManager.instance.actionQueue.Enqueue("hdImprovements");
            GameManager.instance.PopQueue();
            // 집개조 이후, 주요설비 및 보조설비 카드펴짐 -> 카드 하나 고르기 함수 호출
        }
    }

    public void StartHouseDeveloping() {
      GameManager.instance.playerBoards[playerIndex].StartUpgradeHouse();
    }
    public void ImprovementsStart() {
            // 주요설비 및 보조설비 카드를 고를 수 있는 함수 호출 - 아직 구현되지 않음
    }
}
