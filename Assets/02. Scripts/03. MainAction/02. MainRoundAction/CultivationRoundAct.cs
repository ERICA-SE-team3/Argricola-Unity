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
    public int playerIndex;
    public int userPlayerId;


    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[28]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.FIELD_FARMING_END;
            GameManager.instance.SendMessage(ActionType.FIELD_FARMING);
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[28] = true;
            GameManager.instance.actionQueue.Enqueue("farming");
            // //그리고/또는
            GameManager.instance.actionQueue.Enqueue("guSowing");

            GameManager.instance.PopQueue();
        }
    }
    public void FarmingStart()
    {   
        int id = GameManager.instance.localPlayerIndex;

        //장작 채집자 카드
        if (GameManager.instance.players[id].HasJobCard("woodPicker"))
        {
            GameManager.instance.players[id].ActCard("woodPicker");
        }
        GameManager.instance.playerBoards[ id ].StartInstallFarm();
    }

    public void SowingStart()
    {
        int id = GameManager.instance.localPlayerIndex;
        GameManager.instance.playerBoards[id].StartSowing();
    }
}
