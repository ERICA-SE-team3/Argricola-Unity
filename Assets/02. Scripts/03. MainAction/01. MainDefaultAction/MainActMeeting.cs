using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActMeeting : ButtonParents
{
    public int playerIndex;

    public override void OnClick() {
        //플레이어의 현재 보조설비카드가 0개
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int localPlayerIndex = GameManager.instance.localPlayerIndex;
        if(playerIndex == localPlayerIndex)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            //행동을 했음 표시    
            GameManager.instance.IsDoingAct[7] = true;
            GameManager.instance.actionQueue.Enqueue("meeting");
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
        GameManager.instance.players[playerIndex].isFirstPlayer = true;


        //그리고/또는

        //아무것도 없다면
        if (GameManager.instance.players[playerIndex].subcard_owns.Count == 0)
        {
            GameManager.instance.players[playerIndex].GetSubCard( GameManager.instance.players[playerIndex].GetCarNameString( GameManager.instance.players[playerIndex].subcard_hands[0] ) );     
        }

        //플레이어의 현재 카드가 1개
        if (GameManager.instance.players[playerIndex].subcard_owns.Count == 1)
        {
            GameManager.instance.players[playerIndex].GetSubCard( GameManager.instance.players[playerIndex].GetCarNameString( GameManager.instance.players[playerIndex].subcard_hands[1] ) );             
        }

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        GameManager.instance.PopQueue();
    }

}
