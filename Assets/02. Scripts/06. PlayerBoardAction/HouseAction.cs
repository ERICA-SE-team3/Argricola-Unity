using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HouseAction : PlayerBoardAction
{
    public override BoardEventStrategy StartInstall(PlayerBoard playerBoard)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy houseStrategy = new HouseEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return houseStrategy;
        }
        else
        {
            Debug.LogError("�� ��ġ �ൿ�� ������ �� �����ϴ�.");
            return null;
        }
    }

    public override void EndInstall(PlayerBoard playerBoard)
    {
        if (IsEndInstall())
        {
            foreach (Block block in playerBoard.selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeHouse();
            }
            playerBoard.selectedBlocks.Clear();
        }
        else
        {
            Debug.LogWarning("��ġ�� �� �����ϴ�. �ٽ� �������ּ���.");
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