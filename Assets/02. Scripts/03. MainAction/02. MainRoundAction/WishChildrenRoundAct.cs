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
  */

    public int playerIndex = 0;
    public bool isPlayerTurn = true;
    public int countFamily;
    public int countRoom;

    public override void OnClick()
        {
          countFamily = ResourceManager.instance.getResourceOfPlayer(playerIndex, "family");
          countRoom = ResourceManager.instance.getResourceOfPlayer(playerIndex, "room");
          if (countFamily < countRoom)
          {
            // 보조설비 카드펴짐 -> 카드 하나 고르기 함수 호출
            // ActCardSub(playerIndex, "쇠스랑"); // 임의로 함수명 만듦
            ResourceManager.instance.addResource(playerIndex, "family", 1);
          }
        }
}
