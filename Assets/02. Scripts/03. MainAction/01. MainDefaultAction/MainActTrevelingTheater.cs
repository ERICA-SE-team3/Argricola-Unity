using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainActTrevelingTheater : ButtonParents
{
    /*
    To do
    - 사용자가 '유랑극단'행동을 클릭하면 돌아가는 로직을 구현해야함
        if) 사용자의 턴이 아니라면 동작 X
        if) 사용자의 턴이지만 쌓인 음식이 없다면 동작 X
    - 사용자의 턴일 때, 쌓여있는 음식의 개수만큼 얻어야함 -> addResource() 호출
    */

    public int playerIndex;
    int stack;

    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("travelingTheater")];
        text.text = stack.ToString();
    }

    // 사용자가 행동을 클릭했을 때
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if (playerIndex == userPlayerId  && GameManager.instance.IsDoingAct[5]==false) 
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.TROUPE;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[5] = true;
            GameManager.instance.actionQueue.Enqueue("trevelingTheater");
            GameManager.instance.PopQueue();
        }
    }
    public void TrevelingTheaterStart()
    {
        int id = GameManager.instance.localPlayerIndex;

        //stack 정보 가져오기
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("travelingTheater")];

        //자원 획득
        ResourceManager.instance.addResource(id, "food", stack);

        //마술사 카드를 보유중이라면 나무 1개, 곡식 1개 추가
        if ( GameManager.instance.players[id].HasJobCard( "magician" ) )
        {
            GameManager.instance.players[id].ActCard("magician");
        }

        //확인 message
        Debug.Log("Player " + id + " get " + stack + " food!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("travelingTheater")] = 0;

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(id, "family", 1);

        GameManager.instance.PopQueue();
    }
}