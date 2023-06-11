using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDevelopRoundAct : ButtonParents
{
  /* 농장개조 행동 (농장 개조 이후 울타리치기 )
    1. 해당 행동 Onclick
    2. 사용자의 집 정보 가져오기 ( 종류, 방 개수 )
    3. 종류와 개수에 알맞게 자원소모     ex. 나무집 방 2개 -> 갈대 1개 + 흙 2개 소모
    4. 울타리치기
  */

    public int playerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId)
        {
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[29] = true;
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            // GameManager.instance.actionQueue.Enqueue("fdHouseDevelop");
            // //그리고   
            // GameManager.instance.actionQueue.Enqueue("fdFencing");
            GameManager.instance.actionQueue.Enqueue("fdHouseDevelop");
            GameManager.instance.PopQueue(); 
        }
    }

    public void StartHouseDeveloping() {
      GameManager.instance.playerBoards[playerIndex].StartUpgradeHouse();
    }
    
    public void StartFencing() {
      GameManager.instance.playerBoards[playerIndex].StartInstallFence();
    }
}
