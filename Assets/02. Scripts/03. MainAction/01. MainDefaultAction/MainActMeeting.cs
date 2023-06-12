using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActMeeting : ButtonParents
{
    public int playerIndex;
    public int localPlayerIndex;

    public override void OnClick() {
        //플레이어의 현재 보조설비카드가 0개
        playerIndex = GameManager.instance.getCurrentPlayerId();
        localPlayerIndex = GameManager.instance.localPlayerIndex;
        if(playerIndex == localPlayerIndex && GameManager.instance.IsDoingAct[7]==false)
        {
            GameManager.instance.queueActionType = ActionType.MEETING_PLACE_END;
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.SendMessage(ActionType.MEETING_PLACE);
            //행동을 했음 표시    
            GameManager.instance.IsDoingAct[7] = true;
            GameManager.instance.actionQueue.Enqueue("meeting");
            GameManager.instance.actionQueue.Enqueue("subCard");
            GameManager.instance.PopQueue();
        }
    }
    
    public void MeetingStart()
    {
        //선 플레이어 변경
        //1. 기존 선 플레이어 해제
        for(int i=0; i<4; i++)
        {
            if ( GameManager.instance.players[i].isFirstPlayer )
            {
                GameManager.instance.players[i].isFirstPlayer = false;
            }
        }

        //2. 선 플레이어 부여
        GameManager.instance.players[localPlayerIndex].isFirstPlayer = true;

        //3. 선 플레이어 표시
        SidebarManager.instance.FirstPlayerIcon(localPlayerIndex);

        GameManager.instance.PopQueue();
    }

    public void StartSubCard() {
        if (GameManager.instance.players[localPlayerIndex].subcard_owns.Count == 0)
        {
            GameManager.instance.players[localPlayerIndex].GetSubCard( GameManager.instance.players[localPlayerIndex].GetCarNameString( GameManager.instance.players[localPlayerIndex].subcard_hands[0] ) );     
        }

        //플레이어의 현재 카드가 1개
        if (GameManager.instance.players[localPlayerIndex].subcard_owns.Count == 1)
        {
            GameManager.instance.players[localPlayerIndex].GetSubCard( GameManager.instance.players[localPlayerIndex].GetCarNameString( GameManager.instance.players[localPlayerIndex].subcard_hands[1] ) );             
        }

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(playerIndex, "family", 1);
        
        GameManager.instance.PopQueue();
    }

    public void SubCard()
    {
        localPlayerIndex = GameManager.instance.localPlayerIndex;
        ResourceManager.instance.minusResource(localPlayerIndex, "family", 1);
        Warner.instance.LogAction("보조 카드를 습득합니다");
        // GameManager.instance.PopQueue();
    }

    

}
