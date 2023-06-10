using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternQuarryRoundAct : ButtonParents
{
  /* 서부채석장 행동
    1. 해당 행동 Onclick
    2. 누적된 돌의 개수만큼 플레이어 자원개수 증가
  */

    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    //stack 정보 가져오기
    int stack;

    public override void OnClick()
    {
      GameManager.instance.actionQueue.Enqueue("westernQuarry");
      GameManager.instance.PopQueue();
    }
    public void WesternQuarryStart()
    {
      //stack 정보 가져오기
      stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")];

      // 있다면 돌 얻기 함수 호출
      ResourceManager.instance.addResource(playerIndex, "stone", stack);

      //돌집게 카드를 보유중이라면 나무 1개 추가
      if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("stoneClamp"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("stoneClamp");
        }
        
        //확인 message
      Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " stone(rock)!");

      //stack 초기화
      GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")] = 0;

      //행동을 한 후 가족 수 하나 줄이기
      ResourceManager.instance.minusResource(playerIndex, "family", 1);

      // 큐가 빈 상태로 popQueue()를 다시 호출하여 turn이 끝났다는 flag 를 얻음
      GameManager.instance.PopQueue();
    }

    public void _Onclick() {
        
        GameManager.instance.QueueList[playerIndex].Enqueue("westernQuarry");
        GameManager.instance.PopQueue();

    }
}
