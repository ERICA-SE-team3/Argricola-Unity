using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HouseEventStrategy : BoardEventStrategy
{
    Block block;

    public override void OnHoverEnter(Block block) {
        PlayerBoard board = block.board;
        if(isHouseAvailable(block)) 
        {
            Debug.Log("House is available");
            block.ShowGreen();
            if(block.type == BlockType.EMPTY) { block.ChangeEmpty(); }
        }
        else if (!board.selectedBlocks.Contains(block))
        {
            Debug.Log("House is unavailable");
            block.ShowRed();
        }
    }

    public override void OnHoverExit(Block block) 
    {
        PlayerBoard board = block.board;

        if(!board.selectedBlocks.Contains(block))
            block.ShowTransparent();
        // block.ChangeEmpty();
    }

    public override void OnClick(Block block) 
    { 
        PlayerBoard board = block.board;

        if(isHouseAvailable(block))
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

    bool isHouseAvailable(Block block)
    {
        PlayerBoard board = block.board;

        // Block should be empty
        bool isBlockEmpty;
        // Block should be adjacent to a house
        bool isBlockAdjacentToHouse;
        // Block shouldn't be in selected blocks
        bool isBlockInSelectedBlocks = board.selectedBlocks.Contains(block);

        // Check if block is empty
        isBlockEmpty = block.type == BlockType.EMPTY;

        // Check if block is adjacent to a house
        isBlockAdjacentToHouse = IsBlockAdjacentToHouse(block);
        
        if(isBlockEmpty && isBlockAdjacentToHouse && !isBlockInSelectedBlocks)
        {
            return true;
        }
        return false;
    }

    bool IsBlockAdjacentToHouse(Block block)
    {
        PlayerBoard board = block.board;
        int x = block.row;
        int y = block.col;

        // Check if block is adjacent to a house
        if(x > 0 && board.blocks[x-1, y].type == BlockType.HOUSE) return true;
        if(x < board.row - 1 && board.blocks[x+1, y].type == BlockType.HOUSE) return true;
        if(y > 0 && board.blocks[x, y-1].type == BlockType.HOUSE) return true;
        if(y < board.col - 1 && board.blocks[x, y+1].type == BlockType.HOUSE) return true;

        return false;
    }
}
