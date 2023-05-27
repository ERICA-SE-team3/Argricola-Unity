using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActResMarket : ButtonParents
{
    public int playerIndex = 0;
    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "reed", 1);
        ResourceManager.instance.addResource(playerIndex, "rock", 1);
        ResourceManager.instance.addResource(playerIndex, "food", 1);
    }
}
