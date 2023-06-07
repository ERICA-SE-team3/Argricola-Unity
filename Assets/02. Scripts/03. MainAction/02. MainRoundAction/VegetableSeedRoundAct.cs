using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSeedRoundAct : ButtonParents
{
    public int playerIndex = 0;

    public override void OnClick()
    {
        // �ִٸ� �Ϲ� ��� �Լ� ȣ��
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "vegetable", 1);

        //Ȯ�� message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " vegetable!");

        //�ൿ�� �� �� ���� �� �ϳ� ���̱�
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn�� �����ٴ� flag 
        GameManager.instance.endTurnFlag = true;
    }
}
