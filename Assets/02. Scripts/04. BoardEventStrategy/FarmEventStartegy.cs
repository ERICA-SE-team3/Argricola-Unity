using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FarmEventStrategy : BoardEventStrategy
{
    public override void OnHoverEnter(Block block) 
    {
        PlayerBoard board = block.board;
        if(isFarmAvailable(block)) 
        {
            Debug.Log("Farm is available");
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
            block.ShowTransparent();

    }

    public override void OnClick(Block block) 
    { 
        PlayerBoard board = block.board;

        if(isFarmAvailable(block))
        {
            if(board.selectedBlocks.Count > 0)
            {
                Debug.LogWarning("You can only build one farm at a time");
            }
            else
            {
                board.selectedBlocks.Add(block);
                block.ShowGreen();
            }
        }
        else if (board.selectedBlocks.Contains(block))
        {
            board.selectedBlocks.Remove(block);
            block.ShowTransparent();
        }
    }

    bool isFarmAvailable(Block block)
    {
        PlayerBoard board = block.board;

        // Block should be empty
        bool isBlockEmpty;
        // Block should be adjacent to a Farm
        bool isBlockAdjacentToFarm = true;
        // Block shouldn't be in selected blocks
        bool isBlockInSelectedBlocks = board.selectedBlocks.Contains(block);

        // Check if block is empty
        isBlockEmpty = block.type == BlockType.EMPTY;
        // Check if block is adjacent to a house
        if(board.isFarmInBoard())
        {
            isBlockAdjacentToFarm = IsBlockAdjacentToFarm(block);
        }

        return isBlockEmpty && isBlockAdjacentToFarm && !isBlockInSelectedBlocks;
    }

    bool IsBlockAdjacentToFarm(Block block)
    {
        PlayerBoard board = block.board;
        int x = block.row;
        int y = block.col;

        // Check if block is adjacent to a house
        bool isBlockAdjacentToFarm = false;
        if(x > 0) { isBlockAdjacentToFarm = isBlockAdjacentToFarm || board.blocks[x-1, y].type == BlockType.FARM; }
        if(x < board.row - 1) { isBlockAdjacentToFarm = isBlockAdjacentToFarm || board.blocks[x+1, y].type == BlockType.FARM; }
        if(y > 0) { isBlockAdjacentToFarm = isBlockAdjacentToFarm || board.blocks[x, y-1].type == BlockType.FARM; }
        if(y < board.col - 1) { isBlockAdjacentToFarm = isBlockAdjacentToFarm || board.blocks[x, y+1].type == BlockType.FARM; }

        return isBlockAdjacentToFarm;
    }
}
