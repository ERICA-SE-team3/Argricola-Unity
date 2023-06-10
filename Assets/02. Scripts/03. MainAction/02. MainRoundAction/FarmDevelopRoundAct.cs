using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDevelopRoundAct : ButtonParents
{
  /* 농장개조 행동 (농장 개조 이후 울타리치기 )
    1. 해당 행동 Onclick
    2. 사용자의 집 정보 가져오기 ( 종류, 방 개수 )
    3. 종류와 개수에 알맞게 자원소모     ex. 나무집 방 2개 -> 갈대 1개 + 흙 2개 소모
    4. 울타리치기
  */
    public int playerIndex = 0;
    public bool isPlayerTurn = true;
    public int wood;
    public int useWood;

    public override void OnClick()
    {
        GameManager.instance.actionQueue.Enqueue("houseDevelop");
        GameManager.instance.actionQueue.Enqueue("fencing");
        GameManager.instance.PopQueue(); 
    }
}