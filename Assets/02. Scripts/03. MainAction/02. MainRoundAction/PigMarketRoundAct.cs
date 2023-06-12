using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMarketRoundAct : ButtonParents
{
    /* 돼지 시장 행동
    1. 해당 행동 Onclick
    2. 누적된 돼지의 마리수만큼 가져오기
    3. 돼지의 자원현황 늘려주기
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
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("pigMarket")];
        text.text = stack.ToString();
    }
    private void OnEnable() {
        if(GameManager.instance.stackOfRoundCard.Length != 0)
            GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("pigMarket")] = 1; 
        else
            stack = 0;
    }

    
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[23]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.PIG_MARKET;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[23] = true;
            GameManager.instance.actionQueue.Enqueue("pigMarket");
            GameManager.instance.PopQueue();
        }
    }


    public void PigMarketStart()
    {
        int id = GameManager.instance.localPlayerIndex;

        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("pigMarket")];

        // 있다면 pig 얻기 
        ResourceManager.instance.addResource(id, "pig", stack );

        //확인 message
        Debug.Log("Player " + id + " get " + stack + " pig!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("pigMarket")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        GameManager.instance.PopQueue();
    }
}