using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class FenceAction : PlayerBoardAction
{

    public bool IsFenceInBoard(PlayerBoard playerBoard)
    {
        foreach (Block block in playerBoard.blocks)
        {
            if (block.type == BlockType.FENCE)
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
            BoardEventStrategy fenceStrategy = new FenceEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return fenceStrategy;
        }
        else
        {
            Debug.LogError("��Ÿ�� ��ġ �ൿ�� ������ �� �����ϴ�.");
            return null;
        }
    }

    public override void EndInstall(PlayerBoard playerBoard)
    {
        if (IsEndInstall())
        {
            InstallFence(playerBoard);
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


    public void InstallFence(PlayerBoard playerBoard)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Debug.LogError("��Ÿ�� ��ġ �ϴ� �迭 ����, �ش� �迭�� ���� ��ġ");
        for (int j = 0; j < playerBoard.selectedBlocks.Count; j++)
        {
            var block = playerBoard.selectedBlocks[j];
            bool[] fence = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                fence[i] = true;
            }
            for (int i = 0; i < playerBoard.selectedBlocks.Count; i++)
            {
                if (i != j)
                {
                    var otherBlock = playerBoard.selectedBlocks[i];
                    int gapRow = otherBlock.row - block.row;
                    int gapCol = otherBlock.col - block.col;
                    for (int k = 0; k < 4; k++)
                    {
                        if (dx[k] == gapRow && dy[k] == gapCol)
                        {
                            fence[k] = false;
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (!fence[i]) continue;
                int adjBlockRow = block.row + dx[i];
                int adjBlockCol = block.col + dy[i];
                if (adjBlockRow < 0 || adjBlockRow >= playerBoard.row || adjBlockCol < 0 || adjBlockCol >= playerBoard.col) continue;
                if (playerBoard.blocks[adjBlockRow, adjBlockCol].type == BlockType.FENCE)
                {
                    fence[i] = false;
                }
            }
            block.SetFence(fence);
            block.ChangeFence();
        }
        playerBoard.selectedBlocks.Clear();
    }

}
