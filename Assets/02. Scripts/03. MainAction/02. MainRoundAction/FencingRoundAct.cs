using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencingRoundAct : ButtonParents
{
  /* 울타리 행동
    1. 해당 행동 Onclick
    2. 사용자의 나무 개수 정보를 가져옴
      2-1. 나무가 있는지 확인
    3. 사용자의 나무 개수만큼 울타리로 변경
  */
    public override void OnClick()
        {
          GameManager.instance.actionQueue.Enqueue("Fencing");
          GameManager.instance.PopQueue();
        }
}
