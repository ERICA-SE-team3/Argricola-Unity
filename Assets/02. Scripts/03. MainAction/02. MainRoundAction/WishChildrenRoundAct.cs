using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishChildrenRoundAct : ButtonParents
{
  /* 기본가족늘리기 행동
    1. 해당 행동 Onclick
    2. 사용자의 가족 수와 방의 개수 정보를 불러옴
      2-1. 가족 수 보다 방의 개수가 더 많을 때 행동 실행 가능
    3. 조건에 적합하다면 기본가족늘리기 행동 실행
    4. 한 후에 보조설비 카드 하나 획득
  */

    public int playerIndex;

    public int countFamily;
    public int countRoom;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;

        int id = GameManager.instance.localPlayerIndex;

        countFamily = ResourceManager.instance.getResourceOfPlayer(id, "family");
        countRoom = 0;
        foreach (Block b in GameManager.instance.playerBoards[userPlayerId].blocks)
        {
            if (b.type == BlockType.HOUSE)
            {
                countRoom++;
            }
        }
        GameManager.instance.players[userPlayerId].room = countRoom;

        if(countFamily >= countRoom)
        {
            Warner.instance.LogWarning(
              "가족 수가 방의 개수보다 많거나 같습니다.\n"+
              "행동을 실행할 수 없습니다.\n" +
              "가족 수 : " + countFamily + "\n" +
              "방의 개수 : " + countRoom);
            return;
        }

        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[20]==false)
        {

            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.BASIC_FAMILY_INCREASE_END;
            GameManager.instance.SendMessage(ActionType.BASIC_FAMILY_INCREASE);
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[20] = true;
            
            GameManager.instance.actionQueue.Enqueue("wishChildren");
            GameManager.instance.actionQueue.Enqueue("card");
            // GameManager.instance.actionQueue.Enqueue("subCard"); // 보조설비 카드 뽑아야 함
            GameManager.instance.PopQueue();
        }
    }

    public void WishChildrenStart()
    {
        int id = GameManager.instance.localPlayerIndex;

        countFamily = ResourceManager.instance.getResourceOfPlayer(id, "family");
        countRoom = ResourceManager.instance.getResourceOfPlayer(id, "room");


        if (countFamily < countRoom)
        {
          //행동을 한 후 가족 수 하나 줄이기
          Debug.Log("가족 수 하나 늘리기");
          ResourceManager.instance.minusResource(id, "family", 1);
          ResourceManager.instance.addResource(id, "baby", 1);
        }
        // 보조설비 카드펴짐 -> 카드 하나 고르기 함수 호출
        GameManager.instance.PopQueue();
    }
    
    public void StartSubCard()
    {
        // 보조설비 카드를 고를 수 있는 함수 호출 - 아직 구현되지 않음
        GameManager.instance.PopQueue();
    }
}
