using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActGrainSeed : ButtonParents
{
    public int playerIndex = 0;
    public int stacked = 1;
    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "wheat", stacked);
    }
}
