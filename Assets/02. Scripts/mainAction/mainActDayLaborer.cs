using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mainActDayLaborer : MonoBehaviour
{
    /*
    To do
    - 사용자가 '날품팔이'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
    - 사용자의 턴일 때, 무조건 음식 2개를 얻어야함
    */

    private ResourceManager resourceManager;

    private bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)

    // 사용자가 '날품팔이'행동을 클릭했을 때
    private void onClick()
    {
        if (isPlayerTurn) // 사용자의 턴인지 확인
        {
            getFoodsFromDayLaborer();  // 있다면 음식 얻기 함수 호출
        }
    }

    private void getFoodsFromDayLaborer()  
    {
        resourceManager.addResource(0, "food", 2);   //resourceManager.cs의 addResource() 함수 호출
    }
}
