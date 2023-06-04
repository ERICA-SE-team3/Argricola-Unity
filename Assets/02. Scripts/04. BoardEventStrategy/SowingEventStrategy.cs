using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SowingEventStrategy : BoardEventStrategy
{
    public override void OnHoverEnter(Block block) 
    {
        PlayerBoard board = block.board;

        if( !isSowingAvailable(block) ) { block.ShowRed(); }
    }

    public override void OnHoverExit(Block block) 
    { 
        block.ShowTransparent();
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

    public bool isSowingAvailable(Block block)
    {
        return block.type == BlockType.FARM && block.seedType == SeedType.NONE;
    }
}
