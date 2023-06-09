using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class AnimalAction : PlayerBoardAction
{
    public override BoardEventStrategy StartInstall(PlayerBoard playerBoard)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy moveAnimalStrategy = new MoveAnimalEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return moveAnimalStrategy;
        }
        else
        {
            Debug.LogError("���� �ű�� �ൿ�� ������ �� �����ϴ�.");
            return null;
        }
    }

    public override void EndInstall(PlayerBoard playerBoard)
    {
        if (IsEndInstall())
        {
            throw new System.NotImplementedException();
        }
        else
        {
            Debug.LogWarning("���� �ű� �� �����ϴ�. �ٽ� �������ּ���.");
        }
    }

    public override bool IsStartInstall()
    {
        Debug.LogError("��ġ ���� �� �������� �˻��ϴ� �Լ� - ���� ���� �ȵ�");
        return true;
    }

    public override bool IsEndInstall()
    {
        Debug.LogError("��ġ �������� �˻��ϴ� �Լ� - ���� ���� �ȵ�");
        return true;
    }
}
