using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActClayPit : ButtonParents
{
    //stack ���� ��������
    int stack;

    public override void OnClick()
    {
        //stack ���� ��������
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")];

        // �ִٸ� �Ϲ� ��� �Լ� ȣ��
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "clay", stack * 2);

        //Ȯ�� message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack * 2 + " clay!");

        //stack �ʱ�ȭ
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("clayPit")] = 0;

        //�ൿ�� �� �� ���� �� �ϳ� ���̱�
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn�� �����ٴ� flag 
        GameManager.instance.endTurnFlag = true;

    }
}
