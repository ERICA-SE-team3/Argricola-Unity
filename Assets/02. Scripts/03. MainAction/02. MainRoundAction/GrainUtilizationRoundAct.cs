using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainUtilizationRoundAct : ButtonParents
{
    /* 곡식활용 행동 : 씨뿌리기 그리고 또는 빵굽기

    1. OnClick 시 씨뿌릴건지 / 빵구울건지 물어봐야함
    2-1. 씨 뿌린다면
        - startsowing()
        - endsowingcallback() -> 빵구울건지 물어봄
    3. 사용자에게 빵굽기행동 할건지 말건지 물어봄
        if (빵굽기 x) then (act 종료)
        else (빵굽기 o) then (빵굽기 시작)
    */
    public GameObject playerBoard;

    ActionType type = ActionType.GrainUtilizationRoundAct;
    
    public override void OnClick(){
        bool shouldSowing = true; // 씨뿌리기 할건지? (일단 true)

        PlayerBoard board = playerBoard.GetComponent<PlayerBoard>();
        if (shouldSowing == true) {
            StartSowing(this);
        }
        else {
            StartBaking();
        }

    }

    public void EndSowingCallback()
    {   // 씨뿌리기 끝나고 빵구울건지 그냥 끝낼건지
        bool shouldBaking = true; 
        if(shouldBaking == true) {
            StartBaking();
        }
    }
}