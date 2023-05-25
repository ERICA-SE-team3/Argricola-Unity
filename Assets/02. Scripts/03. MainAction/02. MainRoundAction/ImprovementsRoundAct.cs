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

    public int playerIndex = 0;
    public bool isPlayerTurn = true;
    
    public string userSelect = "주요설비";  //사용자가 주요설비를 클릭했다고 가정

    public override void OnClick()
        {
          SelectUser();
        }

    public string SelectUser()
    {
      if (userSelect == "주요설비")
      {
        ActCardMain(playerIndex, "화로"); // 임의로 만든 주요설비 얻기 함수 호출하기
      }
      else
      {
        ActCardSub(playerIndex, "쇠스랑");
      }
    }
}
