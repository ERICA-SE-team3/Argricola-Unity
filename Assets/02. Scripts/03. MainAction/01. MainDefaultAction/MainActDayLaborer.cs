using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainActDayLaborer : ButtonParents
{
    /*
    To do
    - 사용자가 '날품팔이'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
    - 사용자의 턴일 때, 무조건 음식 2개를 얻어야함
    */

<<<<<<< HEAD
    public int playerIndex = GameManager.instance.getCurrentPlayerId();

    public GameObject dayLaborer;
=======
    public int playerIndex;
>>>>>>> develop
    // player 본인의 id 값
    public int userPlayerId = GameManager.instance.localPlayerIndex;

    // 사용자가 행동을 클릭했을 때
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        if(playerIndex == userPlayerId)
        {
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[11] = true;
            GameManager.instance.actionQueue.Enqueue("dayLaborer");
            GameManager.instance.PopQueue();
        }
    }
    public void DayLaborerStart()
    {
        ResourceManager.instance.addResource(playerIndex, "food", 2);

        //돌집게 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[playerIndex].HasSubCard("clayMining"))
        {
            GameManager.instance.players[playerIndex].ActCard("clayMining");
        }

            //확인 message
            Debug.Log("Player " + playerIndex + " get " + 2 + " food!");

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(playerIndex, "family", 1);

<<<<<<< HEAD
        //날품팔이 비활성화
        dayLaborer.GetComponent<Button>().enabled = false;
        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
        // }
        
=======
        GameManager.instance.PopQueue();
>>>>>>> develop
    }
}