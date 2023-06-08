using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestmainActLessonFood1 : ButtonParents
{
    public override void OnClick()
    {
        //플레이어의 내려놓은 직업 카드가 0개 일 때 -> 무료
        //나머지 -> 음식 1개
        //지금은 플레이어 별로 제공할 카드를 정해놓자.

        //플레이어의 현재 카드가 0개
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Count == 0)
        {
            switch (GameManager.instance.getCurrentPlayerId())
            {
                //플레이어 0 - 마술사
                case 0:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.magician);
                    Debug.Log("player 0" + " get MAGICIAN job card!");
                    break;
                //플레이어 1 - 채소장수
                case 1:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.vegetableSeller);
                    Debug.Log("player 1" + " get VEGETABLESELLER job card!");
                    break;
                //플레이어 2 - 초벽질공
                case 2:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.wallMaster);
                    Debug.Log("player 2" + " get WALLMASTER job card!");
                    break;
                //플레이어 3 - 유기 농부
                case 3:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.organicFarmer);
                    Debug.Log("player 3" + " get ORGANICFARMER job card!");
                    break;
            }

            //무료니까 음식 감소 없음.
        }

        //플레이어의 현재 카드가 1개
        else
        {
            switch (GameManager.instance.getCurrentPlayerId())
            {
                //플레이어 0 - 나무꾼
                case 0:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.woodCutter);
                    Debug.Log("player 0" + " get WOODCUTTER job card!");
                    break;
                //플레이어 1 - 장작채집자
                case 1:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.woodPicker);
                    Debug.Log("player 1" + " get WOODPICKER job card!");
                    break;
                //플레이어 2 - 돌 자르는 사람
                case 2:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.stoneCutter);
                    Debug.Log("player 2" + " get STONECUTTER job card!");
                    break;
                //플레이어 3 - 돼지 사육사
                case 3:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)Cards.pigBreeder);
                    Debug.Log("player 3" + " get PIGBREEDER job card!");
                    break;
            }

            //음식 감소 1개
            ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "food", 1);
        }

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}
