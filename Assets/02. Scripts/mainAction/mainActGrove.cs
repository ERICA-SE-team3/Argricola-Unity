using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mainActGrove : MonoBehaviour
{
    /*
    To do
    - 사용자가 '수풀'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
        if) 사용자의 턴이지만 쌓인 나무가 없다면 동작 X
    - 사용자의 턴일 때, 쌓여있는 나무만큼 얻어야함 -> addResource() 호출
    */

    public int wood = 3;    // 쌓여있는 나무가 3개라고 가정
    private bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)

    // 사용자가 '수풀'행동을 클릭했을 때
    private void OnClick()
    {
        if (isPlayerTurn && HasWoods()) // 사용자의 턴인지, 나무가 있는지 확인
        {
            ReturnWoodsFromGrove();  // 있다면 니무 얻기 함수 호출
        }
    }

    private bool HasWoods(){    // 나무가 있는지 확인
        if (wood > 0)
            return true;
    }

    private void ReturnWoodsFromGrove()  
    {
        addResource(0, "wood", wood);   //resourceManager.cs의 addResource() 함수 호출
    }
}
