using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainActForest : MonoBehaviour
{
    /*
    To do
    - 사용자가 '숲'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
        if) 사용자의 턴이지만 쌓인 나무가 없다면 동작 X
    - 사용자의 턴일 때, 쌓여있는 나무만큼 얻어야함 -> addResource() 호출
    */

    public int playerIndex = 0;

    // player 의 wood 개수 가져오기
    public int wood = ResourceManager.instance.getResourceOfPlayer(playerIndex, "wood");
    public bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)


    // 나무가 있는지 확인
    private bool hasWoods(){
        if (wood > 0)
            return true;
        else
            return false;
    }

    // 사용자가 행동을 클릭했을 때
    public void onClick()
    {
        // 사용자의 턴인지, 나무가 있는지 확인
        if (isPlayerTurn && hasWoods()) 
        {
            // 있다면 니무 얻기 함수 호출
            ResourceManager.instance.addResource(playerIndex, "wood", wood);
        }
    }
}