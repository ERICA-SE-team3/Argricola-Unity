using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class FarmAction : PlayerBoardAction
{
    public bool isFarmInBoard(PlayerBoard playerBoard)
    {
        foreach (Block block in playerBoard.blocks)
        {
            if (block.type == BlockType.FARM)
            {
                return true;
            }
        }
        return false;
    }

    public override BoardEventStrategy StartInstall(PlayerBoard playerBoard)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy farmStrategy = new FarmEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return farmStrategy;
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
                block.ChangeFarm();
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
