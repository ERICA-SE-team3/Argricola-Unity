using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMarketRoundAct : ButtonParents
{
    /* 양 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 양의 마리수만큼 가져오기
    3. 양의 자원현황 늘려주기
    4. 개인판에서 양을 배치시키는 함수 실행
    */
    
    public int playerIndex = 0;
    public int sheep = 3;   //누적된 양의 마리수가 3마리라고 가정
    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "sheep", sheep);
        // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        // StartSheep();   // player보드에 양을 배치하는 함수 호출 (함수명은 아직 정해지지 않음)
    }
}
