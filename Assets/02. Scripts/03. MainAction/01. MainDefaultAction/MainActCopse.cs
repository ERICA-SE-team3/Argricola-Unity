using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

// 덤불
public class MainActCopse : ButtonParents
{
    public int playerIndex;

    //stack 정보 가져오기
    int stack;
    // player 본인의 id 값
    public int userPlayerId;


    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("copse")];
        text.text = stack.ToString();
    }

    // 사용자가 '덤불'행동을 클릭했을 때
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        userPlayerId= GameManager.instance.localPlayerIndex;

        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[0]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.BUSH;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[0] = true;
            GameManager.instance.actionQueue.Enqueue("copse");
            GameManager.instance.PopQueue();
        }
    }

    public void CopseStart()
    {
        int id = GameManager.instance.localPlayerIndex;
        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("copse")];

        // 있다면 니무 얻기 함수 호출
        ResourceManager.instance.addResource( id, "wood", stack * 1);

        //나무꾼 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[id].HasJobCard("woodCutter"))
        {
            GameManager.instance.players[id].ActCard("woodCutter");
        }

            //확인 message
        Debug.Log("Player " + id + " get " + stack +" wood!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("copse")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        GameManager.instance.PopQueue();
    }        
}


