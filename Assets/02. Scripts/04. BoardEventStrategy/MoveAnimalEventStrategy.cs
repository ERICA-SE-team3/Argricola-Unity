using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveAnimalEventStrategy : BoardEventStrategy
{
    public override void OnHoverEnter(Block block) 
    {
        PlayerBoard board = block.board;
        if(isAnimalSettingAvailable(block)) { block.ShowGreen(); }
        else { block.ShowRed(); }
    }

    public override void OnHoverExit(Block block) 
    {  
        PlayerBoard board = block.board;
        block.ShowTransparent();
    }

    public override void OnClick(Block block) 
    { 
        PlayerBoard board = block.board;
        if(isAnimalSettingAvailable(block))
        {
            board.ShowAnimalModal(block);
        }
    }

    bool isAnimalSettingAvailable(Block block)
    {
        // 이미 동물이 들어가 있거나
        if(block.sheep + block.pig + block.cow > 0) return true;

        // 울타리거나
        if(block.type == BlockType.FENCE) return true;

        // 외양간이 있거나
        if(block.hasShed) return true;

        // 집이라면
        if(block.type == BlockType.HOUSE)
        {
            int houseAnimalCount = 0;
            Block animalHouseBlock = null;
            foreach (Block b in block.board.blocks)
            {
                if(b.type == BlockType.HOUSE)
                {
                    houseAnimalCount += b.sheep + b.pig + b.cow;
                    if(b.sheep + b.pig + b.cow > 0)
                    {
                        animalHouseBlock = b;
                    }
                }
            }
            // 보드 전체의 집에 동물이 없거나
            if(houseAnimalCount == 0) return true;
            // 현재 클릭한 집만이 동물을 하나 가지고 있어야 함.
            if(animalHouseBlock == block) return true;
        }

        return false;
    }
}
