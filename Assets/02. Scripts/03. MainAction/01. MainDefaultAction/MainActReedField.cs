using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainActReedField : ButtonParents
{
<<<<<<< HEAD
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public GameObject reedField;
=======
    public int playerIndex;
>>>>>>> develop
    int stack;

    // player 본인의 id 값
    public int localPlayerIndex = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
<<<<<<< HEAD
        // if(playerIndex == userPlayerId)
        // {
            stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")];

            ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", stack);

            Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " reed!");

            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")] = 0;

            ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

            reedField.GetComponent<Button>().enabled = false;
            
            GameManager.instance.endTurnFlag = true;
        // }
=======
        playerIndex = GameManager.instance.getCurrentPlayerId();
        if(playerIndex == localPlayerIndex)
        {
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[14] = true;
            GameManager.instance.actionQueue.Enqueue("reedFeild");
            GameManager.instance.PopQueue();
        }
>>>>>>> develop
    }
    public void ReedFeildStart()
    {
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", stack);

        //확인 message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " reed!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        GameManager.instance.PopQueue();
    }

}
