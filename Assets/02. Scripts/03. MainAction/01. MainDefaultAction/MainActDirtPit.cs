using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 흙 채굴장
public class MainActDirtPit : ButtonParents
{
    //stack 정보 가져오기
    int stack;
    public int playerIndex;

    // 사용자가 행동을 클릭했을 때
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.DIRT_PIT;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[13] = true;
            GameManager.instance.actionQueue.Enqueue("dirtPit");
            GameManager.instance.PopQueue();
        }
    }

    public void DirtPitStart()
    {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("dirtPit")];

        ResourceManager.instance.addResource(playerIndex, "clay", stack * 1);

        Debug.Log("Player " + playerIndex + " get " + stack * 1 + " clay!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("dirtPit")] = 0;

        ResourceManager.instance.minusResource(playerIndex, "family", 1);
        GameManager.instance.PopQueue();
    }
}
