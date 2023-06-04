using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SowingEventStrategy : BoardEventStrategy
{
    public override void OnHoverEnter(Block block) 
    {
        PlayerBoard board = block.board;
        if(isSowingAvailable(block)) 
        {
            Debug.Log("Sowing is available");
            block.ShowGreen();
        }
        else if (!board.selectedBlocks.Contains(block))
        {
            Debug.Log("Sowing is unavailable");
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

        if(isSowingAvailable(block))
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

    bool isSowingAvailable(Block block)
    {
        PlayerBoard board = block.board;

        // 선택한 애들이랑, 기존 fence들까지 해서 인접해있는지 확인.

        // Block should be empty
        bool isBlockFarm;
        // Block shouldn't be in selected blocks
        bool isBlockInSelectedBlocks = board.selectedBlocks.Contains(block);

        // Check if block is empty
        isBlockEmpty = block.type == BlockType.EMPTY;
        // Check if block is fence
        isBlockFence = block.type == BlockType.FENCE;
        // Check if block is adjacent to a fence
        foreach(Block selectedBlock in board.selectedBlocks)
        {
            if(!block.IsAdjacentTo(selectedBlock))
            {
                isBlockAdjacentToFence = false;
                break;
            }
        }

        return isBlockEmpty && !isBlockFence && isBlockAdjacentToFence && !isBlockInSelectedBlocks;
    }
}
