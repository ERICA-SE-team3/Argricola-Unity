using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShedEventStrategy : BoardEventStrategy
{
    public override void OnHoverEnter(Block block) 
    {
        PlayerBoard board = block.board;
        if(isShedAvailable(block)) 
        {
            Debug.Log("Shed is available");
            block.ShowGreen();
        }
        else if (!board.selectedBlocks.Contains(block))
        {
            Debug.Log("Shed is unavailable");
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

        if(isShedAvailable(block))
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

    bool isShedAvailable(Block block)
    {
        PlayerBoard board = block.board;

        // Block should be empty
        bool isBlockContainsShed;
        bool isBlockEmpty;
        bool isBlockFence;
        bool isBlockInSelectedBlocks = board.selectedBlocks.Contains(block);
        
        // Check if block contains shed
        isBlockContainsShed = block.hasShed;

        // Check if block is empty
        isBlockEmpty = block.type == BlockType.EMPTY;

        // Check if block is fence
        isBlockFence = block.type == BlockType.FENCE;

        if(!isBlockContainsShed && (isBlockEmpty || isBlockFence) && !isBlockInSelectedBlocks)
        {
            return true;
        }
        return false;
    }
}
