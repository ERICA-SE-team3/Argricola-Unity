using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HouseAction : PlayerBoardAction
{
    public override BoardEventStrategy StartInstall(GameObject confirmButton, List<Block> selectedBlocks)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy houseStrategy = new HouseEventStrategy();

            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(selectedBlocks));
            return houseStrategy;
        }
        else
        {
            Debug.LogError("�� ��ġ �ൿ�� ������ �� �����ϴ�.");
            return null;
        }
        return null;
    }

    public override void EndInstall(List<Block> selectedBlocks)
    {
        if (IsEndInstall())
        {
            foreach (Block block in selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeHouse();
            }
            selectedBlocks.Clear();
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
