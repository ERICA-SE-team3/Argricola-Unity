using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActExpand : ButtonParents
{
    public int playerIndex;
    public int playerReed;
    public int playerWood;
    public int playerClay;
    public int playerRock;
    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        playerReed = ResourceManager.instance.getResourceOfPlayer(playerIndex, "reed");
        playerWood = ResourceManager.instance.getResourceOfPlayer(playerIndex, "wood");
        playerClay = ResourceManager.instance.getResourceOfPlayer(playerIndex, "dirt");
        playerRock = ResourceManager.instance.getResourceOfPlayer(playerIndex, "Rock");

        if(hasReed()){
            if(isWoodHouse()){
            }
            if(isDirtHouse()){
            }
            if(isStoneHouse()){
            }
        }
        if(hasWood()){

        }
    }

    public bool hasReed(){
        if(ResourceManager.instance.getResourceOfPlayer(GameManager.instance.getCurrentPlayerId(), "reed") > 1){
            return true;
        }
        else{
            return false;
        }
    }

    public bool hasWood(){
        if(ResourceManager.instance.getResourceOfPlayer(GameManager.instance.getCurrentPlayerId(), "wood") > 1){
            return true;
        }
        else{
            return false;
        }
    }

    public bool isWoodHouse(){
        return true;
    }

    public bool isDirtHouse(){
        return true;
    }

    public bool isStoneHouse(){
        return true;
    }
}
