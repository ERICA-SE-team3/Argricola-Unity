using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActMeeting : ButtonParents
{
    public int playerIndex = GameManager.instance.getCurrentPlayerId();
    
    public override void OnClick() {
        //플레이어의 현재 보조설비카드가 0개

        playerIndex = GameManager.instance.getCurrentPlayerId();
        
        if (GameManager.instance.players[playerIndex].subcard_owns.Count == 0)
        {
            switch (playerIndex)
            {
                //플레이어 0 - 돌집게
                case 0:
                    //살 자원이 있으면 - 나무 1개 이상
                    if ( GameManager.instance.players[playerIndex].wood > 1 ){
                        ResourceManager.instance.minusResource( playerIndex, "wood", 1 );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.stoneClamp);
                        Debug.Log("player 0" + " get stoneClamp sub card!");
                    }

                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }

                    break;

                //플레이어 1 - 쇠스랑
                case 1:
                    //살 자원이 있으면 - 나무 1개이상
                    if ( GameManager.instance.players[playerIndex].wood > 1){
                        ResourceManager.instance.minusResource( playerIndex, "wood", 1 );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.rake);
                        Debug.Log("player 1" + " get rake sub card!");
                    }

                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }

                    
                    break;

                //플레이어 2 - 물통
                case 2:
                    //살 자원이 있으면 - 흙 1개 이상
                    if ( GameManager.instance.players[playerIndex].clay > 1 ){
                        ResourceManager.instance.minusResource( playerIndex, "clay", 1 );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.watterBottle);
                        Debug.Log("player 2" + " get watterBottle sub card!");
                    }

                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }
                    break;
                //플레이어 3 - 버터 제조기
                case 3:
                    //살 자원이 있으면 - 나무 1개 이상, 직업 3개 이하( 구현 안할게요 )
                    if ( GameManager.instance.players[playerIndex].wood > 1 ){
                        ResourceManager.instance.minusResource( playerIndex, "wood", 1 );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.butter);
                        Debug.Log("player 3" + " get butter sub card!");
                    }

                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }
                    break;
            }

            //보조설비니까 
        }

        //플레이어의 현재 카드가 1개
        else
        {
            switch (playerIndex)
            {
                //플레이어 0 - 양토채굴장 
                case 0:
                    //살 자원이 있으면 - 음식 1개, 직업 3개( .......... 일단은 예... )
                    if ( GameManager.instance.players[playerIndex].food > 1 ){
                        ResourceManager.instance.minusResource( playerIndex, "food", 1 );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.clayMining);
                        Debug.Log("player 0" + " get clayMining sub card!");
                    }

                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }

                    break;
                //플레이어 1 - 통나무배
                case 1:
                    //살 자원이 있으면 - 나무 2개 이상, 직업 1개 보유
                    if ( GameManager.instance.players[playerIndex].wood > 2 && GameManager.instance.players[playerIndex].subcard_owns.Count >= 1 ){
                        ResourceManager.instance.minusResource( playerIndex, "wood", 2 );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.woodBoat);
                        Debug.Log("player 1" + " get woodBoat sub card!");
                    }

                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }
                    break;
                //플레이어 2 - 목재소
                case 2:
                    //살 자원이 있으면 - 바위 2개 이상, 직업 3개 이하
                    if ( GameManager.instance.players[playerIndex].rock > 2 && GameManager.instance.players[playerIndex].subcard_owns.Count >= 1 ){
                        ResourceManager.instance.minusResource( playerIndex, "stone", 2 );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.woodYard);
                        Debug.Log("player 2" + " get woodYard sub card!");
                    }

                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }
                    break;
                    
                //플레이어 3 - 병
                case 3:
                    //살 자원이 있으면 - 가족 1명당 흙 1개, 음식 1개
                    if ( GameManager.instance.players[playerIndex].clay > GameManager.instance.players[playerIndex].family
                    && GameManager.instance.players[playerIndex].food > GameManager.instance.players[playerIndex].family ){
                        ResourceManager.instance.minusResource( playerIndex, "clay", GameManager.instance.players[playerIndex].family );
                        ResourceManager.instance.minusResource( playerIndex, "food", GameManager.instance.players[playerIndex].family );
                        GameManager.instance.players[playerIndex].subcard_owns.Add((int)Cards.woodYard);
                        Debug.Log("player 2" + " get BOTTLE sub card!");
                    } 
                    //없으면
                    else {
                        Debug.Log( "자원이 부족해서 보조설비 구매에 실패하셨습니다." );
                    }

                    break;
            }

        }

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }

}
