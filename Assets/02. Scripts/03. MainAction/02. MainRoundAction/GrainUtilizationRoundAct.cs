using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainUtilizationRoundAct : ButtonParents
{
    /* 곡식활용 행동 : 씨뿌리기 그리고 또는 빵굽기

    1. OnClick 시 씨뿌릴건지 / 빵구울건지 물어봐야함
    2. 씨 뿌린다면
        - startsowing()
        - endsowingcallback() -> 빵구울건지 물어봄
    3. 사용자에게 빵굽기행동 할건지 말건지 물어봄
        if (빵굽기 x) then (act 종료)
        else (빵굽기 o) then (빵굽기 시작)
    */

    public int playerIndex;
 

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[16]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.GRAIN_UTILIZATION;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[16] = true;
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  

            // //씨뿌리기
            // GameManager.instance.actionQueue.Enqueue("guSowing");

            // //그리고/또는

            // //빵굽기
            // GameManager.instance.actionQueue.Enqueue("guBaking");
            // foreach (string item in GameManager.instance.actionQueue) {
            //     Debug.Log("actionQueue 에 들어있는 것들 : " + item);
            // }
            GameManager.instance.actionQueue.Enqueue("grainUtilization");
            GameManager.instance.PopQueue(); 

            //장작 채집자 카드
            if (GameManager.instance.players[playerIndex].HasJobCard("woodPicker"))
            {
                GameManager.instance.players[playerIndex].ActCard("woodPicker");
            }

        }

            
    }

    public void StartSowing() {
        GameManager.instance.playerBoards[playerIndex].StartSowing();
    }

    public void StartBaking() {
        Debug.Log( "빵굽기 - 아직 미구현" );
    }
}