using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActResMarket : ButtonParents
{
    public int playerIndex = 0;
    public override void OnClick()
    {
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "stone", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "food", 1);

        //Ȯ�� message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + "reed and stone and food");

        //�ൿ�� �� �� ���� �� �ϳ� ���̱�
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn�� �����ٴ� flag 
        GameManager.instance.endTurnFlag = true;

    }
}
