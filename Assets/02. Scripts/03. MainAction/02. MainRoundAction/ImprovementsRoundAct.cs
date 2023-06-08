using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovementsRoundAct : ButtonParents
{
  /* 주요설비 행동
    1. 해당 행동 Onclick
    2. 주요설비 / 보조설비 중 택 1
      주요설비  선택 시
      - 주요설비 모달 열림
      보조설비 선택 시
      - 보조설비 모달 열림
    3. 선택한 카드를 얻기위해 해당 카드에 해당하는 비용을 지불하고 카드를 내려놓음
  */

    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public bool isPlayerTurn = true;
    

    public override void OnClick()
      {
        GameManager.instance.actionQueue.Enqueue("Improvements");
        GameManager.instance.PopQueue();
        //핸드열기 동작을 통해 주요설비 / 보조설비 카드가 펴져야 함 (이 둘은 전환 버튼을 통해 고를 수 있게끔)
      }
}
