using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class SowingAction : PlayerBoardAction
{

    public override BoardEventStrategy StartInstall(PlayerBoard playerBoard)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy sowingStrategy = new SowingEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return sowingStrategy;
        }
        else
        {
            Debug.LogError("�� �Ѹ��� �ൿ�� ������ �� �����ϴ�.");
            return null;
        }
    }
    
    public override void EndInstall(PlayerBoard playerBoard)
    {
        if (IsEndInstall())
        {
            foreach (PlayerBoard.SowingBlockNode node in playerBoard.selectedSowingBlocks)
            {
                node.block.SetSeed(node.type);
            }
        }
        else
        {
            Debug.LogWarning("�� �Ѹ� �� �����ϴ�. �ٽ� �������ּ���.");
        }
    }

    public override bool IsStartInstall()
    {
        Debug.LogError("���Ѹ��� ���� �� �������� �˻��ϴ� �Լ� " +
                        " - ���� ���� �ȵ�"); 
        return true;
    }

    public override bool IsEndInstall()
    {
        Debug.LogError("���Ѹ��� ���� �� �������� �˻��ϴ� �Լ� " +
                        " - ���� ���� �ȵ�");
        return true;
    }
}
