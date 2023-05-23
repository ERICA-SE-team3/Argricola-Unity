using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActExpand : ButtonParents
{
    public int playerIndex = 0;
    public int playerReed;
    public int playerWood;
    public int playerClay;
    public int playerRock;
    public override void OnClick()
    {
        playerReed = ResourceManager.instance.getResourceOfPlayer(playerIndex, "reed");
        playerWood = ResourceManager.instance.getResourceOfPlayer(playerIndex, "wood");
        playerClay = ResourceManager.instance.getResourceOfPlayer(playerIndex, "dirt");
        playerRock = ResourceManager.instance.getResourceOfPlayer(playerIndex, "Rock");

        if(playerReed > 1){
            if(playerWood > 4){
                ResourceManager.instance.minusResource(playerIndex, "reed", 2);
                ResourceManager.instance.minusResource(playerIndex, "wood", 5);
                ResourceManager.instance.addResource(playerIndex, "room", 1);
            }
        }
        if(playerWood > 1){
            ResourceManager.instance.minusResource(playerIndex, "wood", 2);
            ResourceManager.instance.addResource(playerIndex, "shed", 1);
        }
    }
}
