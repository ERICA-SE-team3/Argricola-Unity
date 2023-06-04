using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainActCopse : ButtonParents
{
    /*
    To do
    - 사용자가 '덤불'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
        if) 사용자의 턴이지만 쌓인 나무가 없다면 동작 X
    - 사용자의 턴일 때, 쌓여있는 나무만큼 얻어야함 -> addResource() 호출
    */

    public int playerIndex = 0; // 사용자 정보 어떻게 받아올지??

    // 누적되어있는 나무의 개수를 정의
    public int woods;
    public bool isPlayerTurn = true;  // 사용자의 턴이라고 가정 -> (사용자의 턴이 맞는지 검증하는 과정은 어디서??)



    // 나무가 있는지 확인
    private bool HasWoods(){
        woods = 3;
        if (woods > 0)
            return true;
        else
            return false;
    }

    // 사용자가 '덤불'행동을 클릭했을 때
    public override void OnClick()
    {
        // 사용자의 턴인지, 나무가 있는지 확인
        if (isPlayerTurn && HasWoods()) 
        {
            // 있다면 니무 얻기 함수 호출
            ResourceManager.instance.addResource( GameManager.instance.currentPlayerId, "wood", woods);
            ResourceManager.instance.minusResource(GameManager.instance.currentPlayerId, "family", 1);

            //turn이 끝났다는 flag 
            GameManager.instance.endTurnFlag = true;

            Debug.Log( "Player " + GameManager.instance.currentPlayerId + " get " + woods + " wood!" );
        }

        
    }
}
