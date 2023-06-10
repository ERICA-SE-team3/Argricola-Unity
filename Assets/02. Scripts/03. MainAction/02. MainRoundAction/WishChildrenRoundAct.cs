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

    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public int countFamily;
    public int countRoom;
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        if(playerIndex == userPlayerId)
        {
        GameManager.instance.actionQueue.Enqueue("wishChildren");
        GameManager.instance.actionQueue.Enqueue("subCard"); // 보조설비 카드 뽑아야 함
        GameManager.instance.PopQueue();
        }
      }
    public void WishChildrenStart()
    {
        countFamily = ResourceManager.instance.getResourceOfPlayer(playerIndex, "family");
        countRoom = ResourceManager.instance.getResourceOfPlayer(playerIndex, "room");
        if (countFamily < countRoom)
        {
          //행동을 한 후 가족 수 하나 줄이기
          ResourceManager.instance.minusResource(playerIndex, "family", 1);
          ResourceManager.instance.addResource(playerIndex, "family", 1);
        }
        // 보조설비 카드펴짐 -> 카드 하나 고르기 함수 호출
        GameManager.instance.PopQueue();
    }
}
