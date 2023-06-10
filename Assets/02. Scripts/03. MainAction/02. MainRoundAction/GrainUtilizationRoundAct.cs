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
    public GameObject playerBoard;

    // ActionType type = ActionType.GrainUtilizationRoundAct;
    
    public override void OnClick(){
        PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        GameManager.instance.actionQueue.Enqueue("sowing");
        GameManager.instance.actionQueue.Enqueue("baking");
        // foreach (string item in GameManager.instance.actionQueue) {
        //     Debug.Log("actionQueue 에 들어있는 것들 : " + item);
        // }
        GameManager.instance.PopQueue(); 
    }


    public void _OnClick() {
        //씨 뿌리기
        GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ].TestStartSowing();

        //그리고 또는

        //빵굽기
    }

}