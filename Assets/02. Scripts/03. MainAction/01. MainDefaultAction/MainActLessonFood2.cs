using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActLessonFood2 : ButtonParents
{
    public override void OnClick()
    {
        //플레이어의 내려놓은 직업 카드가 0개 거나 1개일 때 -> 직업당 음식 1
        //지금은 플레이어 별로 제공할 카드를 정해놓자.

        //플레이어의 현재 카드가 0개
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Count == 0)
        {
            switch (GameManager.instance.getCurrentPlayerId())
            {
                //플레이어 0 - 마술사
                case 0:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.magician);
                    Debug.Log("player 0" + " get MAGICIAN job card!");
                    break;
                //플레이어 1 - 채소장수
                case 1:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.vegetableSeller);
                    Debug.Log("player 1" + " get VEGETABLESELLER job card!");
                    break;
                //플레이어 2 - 초벽질공
                case 2:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.wallMaster);
                    Debug.Log("player 2" + " get WALLMASTER job card!");
                    break;
                //플레이어 3 - 유기 농부
                case 3:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.organicFarmer);
                    Debug.Log("player 3" + " get ORGANICFARMER job card!");
                    break;
            }
        }

        //플레이어의 현재 카드가 1개
        else
        {
            switch (GameManager.instance.getCurrentPlayerId())
            {
                //플레이어 0 - 나무꾼
                case 0:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.woodCutter);
                    Debug.Log("player 0" + " get WOODCUTTER job card!");
                    break;
                //플레이어 1 - 장작채집자
                case 1:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.woodPicker);
                    Debug.Log("player 1" + " get WOODPICKER job card!");
                    break;
                //플레이어 2 - 돌 자르는 사람
                case 2:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.stoneCutter);
                    Debug.Log("player 2" + " get STONECUTTER job card!");
                    break;
                //플레이어 3 - 돼지 사육사
                case 3:
                    GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].jobcard_owns.Add((int)GameManager.Cards.pigBreeder);
                    Debug.Log("player 3" + " get PIGBREEDER job card!");
                    break;
            }
        }

        //음식 감소 - 현재 최대 카드는 2개 이므로 여기서 공통으로 음식을 하나씩만 뺀다.
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "food", 1);

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}