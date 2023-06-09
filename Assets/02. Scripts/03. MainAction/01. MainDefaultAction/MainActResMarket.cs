using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActResMarket : ButtonParents
{
    public override void OnClick()
    {

        // �ִٸ� �Ϲ� ��� �Լ� ȣ��
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "stone", 1);
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "food", 1);

        //Ȯ�� message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " reed/stone/food!");

        //�ൿ�� �� �� ���� �� �ϳ� ���̱�
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn�� �����ٴ� flag 
        GameManager.instance.endTurnFlag = true;

    }
}
