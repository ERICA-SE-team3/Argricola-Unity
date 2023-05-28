using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMarketRoundAct : ButtonParents
{
    /* 소 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 소의 마리수만큼 가져오기
    3. 소의 자원현황 늘려주기
    4. 개인판에서 소를 배치시키는 함수 실행
    */
    
    public int playerIndex = 0;
    public int cow = 3;   // 3마리가 누적되었다고 가정
    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "cow", cow);
        // PR 리뷰 수정사항 : 정해지지 않은 함수명 주석처리
        // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        // StartCow();  // player보드에 소를 배치하는 함수 호출 (함수명은 아직 정해지지 않음)
    }
}
