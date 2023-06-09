using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 흙 채굴장
public class MainActDirtPit : ButtonParents
{
    //stack 정보 가져오기
    int stack;
    public int playerIndex;

    TMPro.TMP_Text text;
    private void Start() {
        text = this.transform.Find("Icon").Find("Number").GetComponent<TMPro.TMP_Text>();
    }
    private void Update() {
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];
        text.text = stack.ToString();
    }

    // 사용자가 행동을 클릭했을 때
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[13]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.DIRT_PIT;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[13] = true;
            GameManager.instance.actionQueue.Enqueue("dirtPit");
            GameManager.instance.PopQueue();
        }
    }

    public void DirtPitStart()
    {
        int id = GameManager.instance.localPlayerIndex;
        
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("dirtPit")];

        ResourceManager.instance.addResource(id, "clay", stack * 1);

        Debug.Log("Player " + id + " get " + stack * 1 + " clay!");

        //stack 초기화
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("dirtPit")] = 0;

        ResourceManager.instance.minusResource(id, "family", 1);
        GameManager.instance.PopQueue();
    }
}
