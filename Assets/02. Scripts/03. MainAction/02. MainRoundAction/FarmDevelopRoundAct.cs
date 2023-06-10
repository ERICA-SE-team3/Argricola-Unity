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

    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        // if(playerIndex == userPlayerId)
        // {
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            GameManager.instance.actionQueue.Enqueue("houseDevelop");

            //그리고
            
            GameManager.instance.actionQueue.Enqueue("fencing");
            GameManager.instance.PopQueue(); 
        // }
    }
}
