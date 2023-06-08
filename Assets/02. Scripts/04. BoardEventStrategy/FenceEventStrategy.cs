using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FenceEventStrategy : BoardEventStrategy
{
    public override void OnHoverEnter(Block block) 
    {
        PlayerBoard board = block.board;
        if(isFenceAvailable(block)) 
        {
            Debug.Log("Fence is available");
            block.ShowGreen();
            if(block.type == BlockType.EMPTY) { block.ChangeEmpty(); }
        }
        else if (!board.selectedBlocks.Contains(block))
        {
            Debug.Log("Farm is unavailable");
            block.ShowRed();
        }
    }

    public override void OnHoverExit(Block block) 
    { 
        PlayerBoard board = block.board;
        
        if(!board.selectedBlocks.Contains(block))
        {
            block.ShowTransparent();
        }
    }

    public override void OnClick(Block block) 
    { 
        PlayerBoard board = block.board;

        if(!isFenceAvailable(block)) { return; }

        if(board.selectedBlocks.Count == 0)
        {
            GameObject installButton = board.GetInstallButton();
            installButton.SetActive(true);

            Button button = installButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => {
                board.InstallFence();
                installButton.SetActive(false);
            });
        }

        if(isFenceAvailable(block))
        {
            board.selectedBlocks.Add(block);
            block.ShowGreen();
        }
        else if (board.selectedBlocks.Contains(block))
        {
            if(board.selectedBlocks.Count == 1)
            {
                GameObject installButton = board.GetInstallButton();
                installButton.SetActive(false);
            }
            board.selectedBlocks.Remove(block);
            block.ShowTransparent();
        }
    }

    bool isFenceAvailable(Block block)
    {
        PlayerBoard board = block.board;

        // Block should be empty
        bool isBlockEmpty;
        // Block should be Fence
        bool isBlockFence;
        // Block should be adjacent to a Fence
        bool isBlockAdjacentToFence;
        // Block shouldn't be in selected blocks
        bool isBlockInSelectedBlocks = board.selectedBlocks.Contains(block);

        // Check if block is empty
        isBlockEmpty = block.type == BlockType.EMPTY;
        // Check if block is fence
        isBlockFence = block.type == BlockType.FENCE;
        // Check if block is adjacent to a fence
        isBlockAdjacentToFence = IsBlockAdjacentToFence(block);

        return (isBlockEmpty || isBlockFence) && isBlockAdjacentToFence && !isBlockInSelectedBlocks;
    }

    bool IsBlockAdjacentToFence(Block block)
    {
        PlayerBoard board = block.board;

        if(!board.IsFenceInBoard() && board.selectedBlocks.Count == 0) { return true; } // fence가 없으면 처음 설치하는거니까 true

        // 선택한 애들이랑, 기존 fence들까지 해서 인접해있는지 확인.
        int x = block.row;
        int y = block.col;

        int row = board.row;
        int col = board.col;

        // Check if block is adjacent to a fence
        for(int i = x - 1; i <= x + 1; i++)
        {
            for(int j = y - 1; j <= y + 1; j++)
            {
                if(i != x && j != y) { continue; }
                if(i < 0 || i >= row || j < 0 || j >= col) { continue; }
                if(board.blocks[i, j].type == BlockType.FENCE) { return true; }
                if(board.selectedBlocks.Contains(board.blocks[i, j])) { return true; }
            }
        }

        return false;
    }
}
