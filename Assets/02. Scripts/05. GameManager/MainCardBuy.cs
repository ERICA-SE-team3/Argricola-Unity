using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCardBuy : MonoBehaviour
{
    int playerIndex;


    public void OnClick1() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "fireplace1" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("fireplace1");
        }
    }

    public void OnClick2() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "fireplace2" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("fireplace2");
        }
    }

    public void OnClick3() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "cookingHearth1" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("cookingHearth1");
        }
    }

    public void OnClick4() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "cookingHearth2" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("cookingHearth2");
        }
    }

    public void OnClick5() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "clayOven" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("clayOven");
        }
    }
    public void OnClick6() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "stoneOven" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("stoneOven");
        }
    }
    public void OnClick7() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "joinery" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("joinery");
        }
    }
    public void OnClick8() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "pottery" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("pottery");
        }
    }
    public void OnClick9() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "basket" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("basket");
        }
    }
    public void OnClick10() {
        playerIndex = GameManager.instance.getCurrentPlayerId();

        //갖고 있지 않다면
        if( !GameManager.instance.players[playerIndex].HasMainCard( "well" ) ) {
            GameManager.instance.players[playerIndex].GetMainCard("well");
        }
    }
}
