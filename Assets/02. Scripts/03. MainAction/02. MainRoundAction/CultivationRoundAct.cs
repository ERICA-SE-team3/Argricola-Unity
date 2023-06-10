using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultivationRoundAct : ButtonParents
{
    /* 밭 농사 행동 (밭 하나 일구기 그리고/또는 씨뿌리기)
    1. 해당 행동 OnClick
    2. 밭 하나 일구기 (StartInstallFarm)
    3. 씨뿌리기 할건지 말건지 정보 받아오기
        3-1. 할거면 씨뿌리기 행동 진행
        3-2. 안할거면 끝
    */
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        if(playerIndex == userPlayerId)
        {
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            GameManager.instance.actionQueue.Enqueue("cultivation");
            GameManager.instance.actionQueue.Enqueue("sowing");
            GameManager.instance.PopQueue(); 
        }
    }
}
