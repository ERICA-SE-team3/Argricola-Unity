using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainActFishing : MonoBehaviour
{
    /*
    To do
    - 사용자가 '낚시'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
        if) 사용자의 턴이지만 쌓인 음식이 없다면 동작 X
    - 사용자의 턴일 때, 쌓여있는 음식의 개수만큼 얻어야함 -> addResource() 호출
    */

    public int playerIndex = 0;

    // player 의 food 개수 가져오기
    public int food = ResourceManager.instance.getResourceOfPlayer(playerIndex, "food");
    public bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)


    // 음식이 있는지 확인
    private bool hasFoods(){
        if (wood > 0)
            return true;
        else
            return false;
    }

    // 사용자가 행동을 클릭했을 때
    public void onClick()
    {
        // 사용자의 턴인지, 음식이 있는지 확인
        if (isPlayerTurn && hasFoods()) 
        {
            // 있다면 음식 얻기 함수 호출
            ResourceManager.instance.addResource(playerIndex, "food", food);
        }
    }
}