using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainActTrevelingTheater : ButtonParents
{
    /*
    To do
    - 사용자가 '유랑극단'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
        if) 사용자의 턴이지만 쌓인 음식이 없다면 동작 X
    - 사용자의 턴일 때, 쌓여있는 음식의 개수만큼 얻어야함 -> addResource() 호출
    */

    public int playerIndex = 0;

    // 누적되어있는 음식의 개수를 3개라 가정
    public int foods;
    public bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)

    //stack 정보 가져오기
    int stack;


    //// 음식이 있는지 확인
    //private bool HasFoods(){
    //    food = ResourceManager.instance.getResourceOfPlayer(playerIndex,"food");
    //    if (food > 0)
    //        return true;
    //    else
    //        return false;
    //}

    // 사용자가 행동을 클릭했을 때
    public override void OnClick()
    {
        // 사용자의 턴인지, 음식이 있는지 확인
        if (isPlayerTurn) 
        {
            //stack 정보 가져오기
            stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("travelingTheater")];

            // 있다면 니무 얻기 함수 호출
            ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "food", stack);

            //확인 message
            Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " food!");

            //stack 초기화
            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("travelingTheater")] = 0;

            //행동을 한 후 가족 수 하나 줄이기
            ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

            //turn이 끝났다는 flag 
            GameManager.instance.endTurnFlag = true;
        }
    }
}