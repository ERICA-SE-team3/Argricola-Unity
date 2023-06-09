 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActReedField : ButtonParents
{
    int stack;

    public override void OnClick()
    {
        //stack ���� ��������
        stack = GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")];

        // �ִٸ� �Ϲ� ��� �Լ� ȣ��
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "reed", stack);

        //Ȯ�� message
        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + stack + " reed!");

        //stack �ʱ�ȭ
        GameManager.instance.stackOfRoundCard[GameManager.instance.getStackBehavior("reedField")] = 0;

        //�ൿ�� �� �� ���� �� �ϳ� ���̱�
        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        //turn�� �����ٴ� flag 
        GameManager.instance.endTurnFlag = true;

    }
}
