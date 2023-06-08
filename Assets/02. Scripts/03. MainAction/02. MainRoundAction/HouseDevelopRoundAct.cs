using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDevelopRoundAct : ButtonParents
{
  /* 집 개조 행동 (집 개조 이후 주요설비 or 보조설비 )
    1. 해당 행동 Onclick
    2. 사용자의 집 정보 가져오기 ( 종류, 방 개수 )
    3. 종류와 개수에 알맞게 자원소모     ex. 나무집 방 2개 -> 갈대 1개 + 흙 2개 소모
    4. 주요설비 또는 보조설비 하나 고르기
  */

    public int playerIndex = 0;
    public bool isPlayerTurn = true;
    public string userSelect = "주요설비";  //사용자가 주요설비를 클릭했다고 가정

    public override void OnClick()
        {
          // PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
          // StartInstallHouse();
          SelectUser();
        }

    public string SelectUser()
    {
      if (userSelect == "주요설비")
      {
        // ActCardMain(playerIndex, "화로"); // 임의로 만든 주요설비 얻기 함수 호출하기
        return "주요설비";
      }
      else
      {
        // ActCardSub(playerIndex, "쇠스랑");
        return "보조설비";
      }
    }

    //======================================================================

    public void _OnClick() {
      GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ]._StartInstallHouse();
    }

}
