using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mainActFishing : MonoBehaviour
{
    /*
    To do
    - 사용자가 '낚시'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
        if) 사용자의 턴이지만 쌓인 음식이 없다면 동작 X
    - 사용자의 턴일 때, 쌓여있는 음식의 개수만큼 얻어야함 -> addResource() 호출
    */

    private ResourceManager resourceManager;

    public int food = 3;    // 쌓여있는 음식이 3개라고 가정
    private bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)

    // 사용자가 '낚시'행동을 클릭했을 때
    private void onClick()
    {
        if (isPlayerTurn && hasFoods()) // 사용자의 턴인지, 음식이 있는지 확인
        {
            getFoodsFromFishing();  // 있다면 음식 얻기 함수 호출
        }
    }

    private bool hasFoods(){    // 음식이 있는지 확인
        if (food > 0)
            return true;
        else
            return false;
    }

    private void getFoodsFromFishing()  
    {
        resourceManager.addResource(0, "food", food);   //resourceManager.cs의 addResource() 함수 호출
    }
}
