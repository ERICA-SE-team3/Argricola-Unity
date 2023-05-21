using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActReedField : ButtonParents
{
    public int playerIndex = 0;
    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "reed", 1);
    }
}
