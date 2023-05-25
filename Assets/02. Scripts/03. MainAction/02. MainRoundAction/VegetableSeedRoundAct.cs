using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSeedRoundAct : MonoBehaviour
{
    public int playerIndex = 0;
    public override void OnClick()
    {
        ResourceManager.instance.addResource(playerIndex, "grain", 1);
    }
}
