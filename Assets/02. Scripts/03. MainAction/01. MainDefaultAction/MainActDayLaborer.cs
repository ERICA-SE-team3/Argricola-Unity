using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainActDayLaborer : ButtonParents
{
    /*
    To do
    - 사용자가 '날품팔이'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
    - 사용자의 턴일 때, 무조건 음식 2개를 얻어야함
    */

    public int playerIndex;

    // 사용자가 행동을 클릭했을 때
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[11]==false )
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.DATALLER;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[11] = true;
            GameManager.instance.actionQueue.Enqueue("dayLaborer");
            GameManager.instance.PopQueue();
        }
    }
    public void DayLaborerStart()
    {
        int id = GameManager.instance.localPlayerIndex;
        ResourceManager.instance.addResource(id, "food", 2);

        //돌집게 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[id].HasSubCard("clayMining"))
        {
            GameManager.instance.players[id].ActCard("clayMining");
        }

            //확인 message
            Debug.Log("Player " + id + " get " + 2 + " food!");

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        GameManager.instance.PopQueue();
    }
}