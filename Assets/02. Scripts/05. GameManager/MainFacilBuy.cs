using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFacilBuy : MonoBehaviour
{
    public int userPlayerId;
    
    private void Start() {
        userPlayerId = GameManager.instance.localPlayerIndex;
    }
    
    public void OnClick1() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "fireplace1" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "fireplace1" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick2() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "fireplace2" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "fireplace2" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick3() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "cookingHearth1" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "cookingHearth1" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick4() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "cookingHearth2" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "cookingHearth2" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick5() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "clayOven" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "clayOven" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick6() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "stoneOven" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "stoneOven" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick7() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "joinery" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "joinery" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick8() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "pottery" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "pottery" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick9() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "basket" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "basket" ); 
        }
        GameManager.instance.PopQueue();
    }
    public void OnClick10() {
        if( !GameManager.instance.players[userPlayerId].HasMainCard( "well" ) ) {
            GameManager.instance.players[userPlayerId].GetMainCard( "well" ); 
        }
        GameManager.instance.PopQueue();
    }
    
}
