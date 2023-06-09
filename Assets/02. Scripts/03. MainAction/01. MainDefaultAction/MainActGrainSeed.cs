using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActGrainSeed : ButtonParents
{
    public override void OnClick()
    {

        // �ִٸ� �Ϲ� ��� �Լ� ȣ��
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "wheat", 1);

        //Ȯ�� message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " wheat!");

        //�ൿ�� �� �� ���� �� �ϳ� ���̱�
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn�� �����ٴ� flag 
        GameManager.instance.endTurnFlag = true;

    }
}
