using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

        if(isFenceAvailable(block))
        {
            board.selectedBlocks.Add(block);
            block.ShowGreen();
        }
        else if (board.selectedBlocks.Contains(block))
        {
            board.selectedBlocks.Remove(block);
            block.ShowTransparent();
        }
    }

    bool isFenceAvailable(Block block)
    {
        PlayerBoard board = block.board;

        // 선택한 애들이랑, 기존 fence들까지 해서 인접해있는지 확인.

        // Block should be empty
        bool isBlockEmpty;
        // Block should be Fence
        bool isBlockFence;
        // Block should be adjacent to a Fence
        bool isBlockAdjacentToFence = true;
        // Block shouldn't be in selected blocks
        bool isBlockInSelectedBlocks = board.selectedBlocks.Contains(block);

        // Check if block is empty
        isBlockEmpty = block.type == BlockType.EMPTY;
        // Check if block is fence
        isBlockFence = block.type == BlockType.FENCE;
        // Check if block is adjacent to a house
        if(board.IsFenceInBoard())
        {
            isBlockAdjacentToFence = IsBlockAdjacentToFence(block);
        }

        return (isBlockEmpty || isBlockFence) && isBlockAdjacentToFence && !isBlockInSelectedBlocks;
    }

    bool IsBlockAdjacentToFence(Block block)
    {
        PlayerBoard board = block.board;

        // 선택한 애들이랑, 기존 fence들까지 해서 인접해있는지 확인.
        foreach(Block selectedBlock in board.selectedBlocks)
        {
            
        }
        return true;
    }
}
