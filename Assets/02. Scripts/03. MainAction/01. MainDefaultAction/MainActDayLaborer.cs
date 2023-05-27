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

    public int playerIndex = 0;
    public bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)

    // 사용자가 행동을 클릭했을 때
    public override void OnClick()
    {
        if (isPlayerTurn) // 사용자의 턴인지 확인
        {
            ResourceManager.instance.addResource(playerIndex, "food", 2);
        }
    }
}