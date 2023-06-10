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
    public bool shouldSowing = true; // 씨뿌리기 할거임? (일단 true)

    public override void OnClick()
    {
        // PR 리뷰 수정사항 : 정해지지 않은 함수명 주석처리
        // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        // StartInstallFarm();
        if(shouldSowing == true)
        {
            // StartSowing();
        }
    }

    public void _OnClick() {
        //농지
        GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ].TestStartInstallFarm();

        //그리고 또는

        //Sow - 하지만 현재 각 행동별로 endTurn이 구성되어있어서 각주 처리
        // GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ].TestStartSowing();

        //장작 채집자 카드
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("woodPicker"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("woodPicker");
        }
    }
}
