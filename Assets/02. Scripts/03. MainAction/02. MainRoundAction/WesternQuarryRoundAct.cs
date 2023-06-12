using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternQuarryRoundAct : ButtonParents
{
  /* 서부채석장 행동
    1. 해당 행동 Onclick
    2. 누적된 돌의 개수만큼 플레이어 자원개수 증가
  */

    //stack 정보 가져오기
    int stack;
    public int playerIndex;

    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")];
        text.text = stack.ToString();
    }

    private void OnEnable() {
        if(GameManager.instance.stackOfRoundCard.Length != 0)
            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")] = 1; 
        else
            stack = 0;
    }

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[21]==false)
        {
          MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
          GameManager.instance.queueActionType = ActionType.WESTREN_QUARRY;
          //행동을 했음 표시
          GameManager.instance.IsDoingAct[21] = true;
          GameManager.instance.actionQueue.Enqueue("westernQuarry");
          GameManager.instance.PopQueue();
        }
    }
    public void WesternQuarryStart()
    {
        int id = GameManager.instance.localPlayerIndex;
        
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")];

        // 있다면 돌 얻기 함수 호출
        ResourceManager.instance.addResource(id, "stone", stack);

        //돌집게 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[id].HasJobCard("stoneClamp"))
        {
            GameManager.instance.players[id].ActCard("stoneClamp");
        }
            
            //확인 message
        Debug.Log("Player " + id + " get " + stack + " stone(rock)!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("westernQuarry")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        // 큐가 빈 상태로 popQueue()를 다시 호출하여 turn이 끝났다는 flag 를 얻음
        GameManager.instance.PopQueue();
    }


}
