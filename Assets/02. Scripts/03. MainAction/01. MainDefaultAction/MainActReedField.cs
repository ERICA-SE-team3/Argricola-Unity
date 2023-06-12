using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActReedField : ButtonParents
{
    public int playerIndex;
    int stack;


    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int localPlayerIndex = GameManager.instance.localPlayerIndex;
        if(playerIndex == localPlayerIndex && GameManager.instance.IsDoingAct[14]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.REED_FIELD;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[14] = true;
            GameManager.instance.actionQueue.Enqueue("reedFeild");
            GameManager.instance.PopQueue();
        }
    }
    public void ReedFeildStart()
    {
        int id = GameManager.instance.localPlayerIndex;

        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(id, "reed", stack);

        //확인 message
        Debug.Log("Player " + id + " get " + stack + " reed!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        GameManager.instance.PopQueue();
    }

}
