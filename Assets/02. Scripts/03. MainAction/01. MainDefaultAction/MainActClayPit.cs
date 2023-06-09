using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 점토채굴장
public class MainActClayPit : ButtonParents
{
    public int playerIndex;

    //stack 정보 가져오기
    int stack;

    
    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];
        text.text = stack.ToString();
    }

    public override void OnClick()
    {
        int userPlayerId = GameManager.instance.localPlayerIndex;
        playerIndex = GameManager.instance.getCurrentPlayerId();
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[3]==false)
        {   
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.CLAY_PIT;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[3] = true;
            GameManager.instance.actionQueue.Enqueue("clayPit");
            GameManager.instance.PopQueue();
        }
    }

    public void ClayPitStart()
    {
        int userId = GameManager.instance.localPlayerIndex;

        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];

        ResourceManager.instance.addResource(userId, "clay", stack * 2);

        Debug.Log("Player " + userId + " get " + stack * 2 + " clay!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")] = 0;

        ResourceManager.instance.minusResource(userId, "family", 1);

        GameManager.instance.PopQueue();
    }
}
