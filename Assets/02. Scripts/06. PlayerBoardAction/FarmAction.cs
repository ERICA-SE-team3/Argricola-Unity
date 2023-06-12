using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class FarmAction : PlayerBoardAction
{
    public FarmAction(PlayerBoard board) : base(board) { }

    public override bool StartInstall()
    {
        if(!IsStartInstall())
        {
            Debug.LogError("밭 설치 행동을 시작할 수 없습니다.");
            return false;
        }

        board.strategy = new FarmEventStrategy();

        Button button = board.confirmButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => EndInstall());

        return true;
    }

    public override void EndInstall()
    {
        if(!IsEndInstall())
        {
            Debug.LogError("밭 설치 행동을 종료할 수 없습니다.");
            return;
        }

        foreach (Block block in board.selectedBlocks)
        {
            block.ShowTransparent();
            block.ChangeFarm();
        }
        
        ResetBoard();
        GameManager.instance.PopQueue();
    }

    public override bool IsStartInstall()
    {
        bool isEmptyBlockExist = false;
        foreach (Block block in board.blocks)
        {
            if (block.type == BlockType.EMPTY)
            {
                isEmptyBlockExist = true;
                break;
            }
        }
        return isEmptyBlockExist;
    }

    public override bool IsEndInstall()
    {
        if (board.selectedBlocks.Count == 0)
        {
            Debug.LogError("선택된 블록이 없습니다.");
            return false;
        }

        return true;
    }
}
