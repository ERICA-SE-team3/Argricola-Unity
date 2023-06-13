using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMarketRoundAct : ButtonParents
{
    /* 소 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 소의 마리수만큼 가져오기
    3. 소의 자원현황 늘려주기
    4. 개인판에서 소를 배치시키는 함수 실행
    */
    
    public int playerIndex;

    //stack 정보 가져오기
    int stack;

    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("cowMarket")];
        text.text = stack.ToString();
    }
    private void OnEnable() {
        if(GameManager.instance.stackOfRoundCard.Length != 0)
            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("cowMarket")] = 1; 
        else
            stack = 0;
    }



    public override void OnClick()
    {
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[26]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.COW_MARKET;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[26] = true;
            GameManager.instance.actionQueue.Enqueue("cowMarket");
            GameManager.instance.PopQueue();
        }
    }
    public void CowMarketStart()
    {
        int id = GameManager.instance.localPlayerIndex;

        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("cowMarket")];

        ResourceManager.instance.addResource(id, "cow", stack );

        //확인 message
        Debug.Log("Player " + id + " get " + stack + " cow!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("cowMarket")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        GameManager.instance.PopQueue();
    }
}
