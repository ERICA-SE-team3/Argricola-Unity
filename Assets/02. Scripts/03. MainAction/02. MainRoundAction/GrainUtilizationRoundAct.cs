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

    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    public override void OnClick()
    {
        // if(playerIndex == userPlayerId)
        // {
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  

            GameManager.instance.actionQueue.Enqueue("sowing");
            GameManager.instance.actionQueue.Enqueue("baking");
            // foreach (string item in GameManager.instance.actionQueue) {
            //     Debug.Log("actionQueue 에 들어있는 것들 : " + item);
            // }
            GameManager.instance.PopQueue(); 
        // }
    }



}