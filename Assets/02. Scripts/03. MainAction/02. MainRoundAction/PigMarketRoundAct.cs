using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMarketRoundAct : ButtonParents
{
    /* 돼지 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 돼지의 마리수만큼 가져오기
    3. 돼지의 자원현황 늘려주기
    4. 개인판에서 소를 배치시키는 함수 실행
    */
    
    public int playerIndex = 0;
    public int pig = 3;   // 3마리가 누적되었다고 가정
    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "pig", pig);
        PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        StartPig();  // player보드에 돼지를 배치하는 함수 호출 (함수명은 아직 정해지지 않음)
    }
}