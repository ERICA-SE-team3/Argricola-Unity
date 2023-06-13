using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasternQuarryRoundAct : ButtonParents
{
    /* 동부채석장 행동
      1. 해당 행동 Onclick
      2. 누적된 돌의 개수만큼 플레이어 자원개수 증가
    */

    public int playerIndex;
    //stack 정보 가져오기
    int stack;

    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("easternQuarry")];
        text.text = stack.ToString();
    }

    private void OnEnable() {
        if(GameManager.instance.stackOfRoundCard.Length != 0)
            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("easternQuarry")] = 1; 
        else
            stack = 0;
    }


    public override void OnClick()
    {
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[25]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.EASTERN_QUARRY;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[25] = true;
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            GameManager.instance.actionQueue.Enqueue("easternQuarry");
            GameManager.instance.PopQueue();
        }
    }

    public void EasternQuarryStart()
    {
        int id = GameManager.instance.localPlayerIndex;
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("easternQuarry")];

        // 있다면 돌 얻기 함수 호출
        ResourceManager.instance.addResource(id, "stone", stack);

        //확인 message
        Debug.Log("Player " + id + " get " + stack + " stone(rock)!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("easternQuarry")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        // 큐가 빈 상태로 popQueue()를 다시 호출하여 turn이 끝났다는 flag 를 얻음
        GameManager.instance.PopQueue();
    }
}