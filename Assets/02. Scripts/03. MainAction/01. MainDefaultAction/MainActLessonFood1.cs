using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActLessonFood1 : ButtonParents
{
    public int playerIndex;
    public int localPlayerIndex;
    
    public override void OnClick()
    {
        //플레이어의 내려놓은 직업 카드가 0개 거나 1개일 때 -> 직업당 음식 1
        playerIndex = GameManager.instance.getCurrentPlayerId();
        localPlayerIndex = GameManager.instance.localPlayerIndex;
        if(playerIndex == localPlayerIndex && GameManager.instance.IsDoingAct[10]==false)
        {
            GameManager.instance.queueActionType = ActionType.LESSON_ONE_END;
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.SendMessage(ActionType.LESSON_ONE);

            //행동을 했음 표시
            GameManager.instance.IsDoingAct[10] = true;
            // GameManager.instance.actionQueue.Enqueue("lessonFood1");
            GameManager.instance.actionQueue.Enqueue("lesson");
            GameManager.instance.PopQueue();
        }
    }

    public void Lesson()
    {
        localPlayerIndex = GameManager.instance.localPlayerIndex;
        ResourceManager.instance.minusResource(localPlayerIndex, "family", 1);
        Warner.instance.LogAction("음식을 소모하고 직업을 얻습니다.");
    }

    public void LessonFoodStartOne()
    {
        //플레이어의 현재 카드가 0개
        if (GameManager.instance.players[localPlayerIndex].jobcard_owns.Count == 0)
        {
            //핸드에 있는 제일 처음 카드 Get
            GameManager.instance.players[localPlayerIndex].jobcard_owns.Add( GameManager.instance.players[localPlayerIndex].jobcard_hands[0] );
            Debug.Log("player " + localPlayerIndex + " get job card!");
            
            //처음이므로 음식 소모는 없다.

        }

        //플레이어의 현재 카드가 1개
        else
        {
            GameManager.instance.players[localPlayerIndex].jobcard_owns.Add( GameManager.instance.players[localPlayerIndex].jobcard_hands[1] );
            Debug.Log("player " + localPlayerIndex + " get job card!");
                    
                
            //음식 감소 - 현재 최대 카드는 2개 이므로 여기서 음식을 하나씩만 뺀다.
            ResourceManager.instance.minusResource(localPlayerIndex, "food", 1);
                    
        }
        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(localPlayerIndex, "family", 1);

        GameManager.instance.PopQueue();
    }
}