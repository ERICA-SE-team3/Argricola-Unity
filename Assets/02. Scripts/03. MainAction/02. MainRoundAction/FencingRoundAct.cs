using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencingRoundAct : ButtonParents
{
  /* 울타리 행동
    1. 해당 행동 Onclick
    2. 사용자의 나무 개수 정보를 가져옴
      2-1. 나무가 있는지 확인
    3. 사용자의 나무 개수만큼 울타리로 변경
  */

    public int playerIndex;
    public int userPlayerId;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[18]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.FENCE_END;
            GameManager.instance.SendMessage(ActionType.FENCE);
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[18] = true;
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            GameManager.instance.actionQueue.Enqueue("fencing");
            GameManager.instance.PopQueue();

        }
    }

    public void StartFencing() {
        int id = GameManager.instance.localPlayerIndex;
        Camera.main.GetComponent<CameraManager>().ShowPlayer(id);
        GameManager.instance.playerBoards[id].StartInstallFence();
    }
}
