using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActMeeting : ButtonParents
{
    public override void OnClick() {
        ;
    }

//=======================================================================

    public void _OnClick() {

        //플레이어의 현재 보조설비카드가 0개
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Count == 0)
        {
            switch (GameManager.instance.getCurrentPlayerId())
            {
                //플레이어 0 - 돌집게
                case 0:
                    //살 자원이 있으면 - 나무 1개 이상
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].wood > 1 ){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "wood", 1 );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.stoneClamp);
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
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].wood > 1){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "wood", 1 );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.rake);
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
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].clay > 1 ){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "clay", 1 );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.watterBottle);
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
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].wood > 1 ){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "wood", 1 );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.butter);
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
            switch (GameManager.instance.getCurrentPlayerId())
            {
                //플레이어 0 - 양토채굴장 
                case 0:
                    //살 자원이 있으면 - 음식 1개, 직업 3개( .......... 일단은 예... )
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].food > 1 ){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "food", 1 );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.clayMining);
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
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].wood > 2 && GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Count >= 1 ){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "wood", 2 );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.woodBoat);
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
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].rock > 2 && GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Count >= 1 ){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "stone", 2 );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.woodYard);
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
                    if ( GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].clay > GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].family
                    && GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].food > GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].family ){
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "clay", GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].family );
                        ResourceManager.instance.minusResource( GameManager.instance.getCurrentPlayerId(), "food", GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].family );
                        GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].subcard_owns.Add((int)Cards.woodYard);
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
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;



    }
}
