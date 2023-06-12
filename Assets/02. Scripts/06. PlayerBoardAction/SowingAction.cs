using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class SowingAction : PlayerBoardAction
{
    public SowingAction(PlayerBoard board) : base(board) { }

    public override bool StartInstall()
    {
        if(!IsStartInstall())
        {
            Warner.instance.LogAction("씨 뿌리기 행동을 시작할 수 없습니다.");
            return false;
        }

        board.strategy = new SowingEventStrategy();

        SetFarmBlockToSow();
        Button button = board.confirmButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => EndInstall());
        return true;

    }
    
    public override void EndInstall()
    {
        if(!IsEndInstall())
        {
            Debug.LogWarning("씨 뿌리기 행동을 종료할 수 없습니다.");
            return;
        }

        SetSeed();
        ResetBoard();
        GameManager.instance.PopQueue();
    }

    public override bool IsStartInstall()
    {
        if(!board.isFarmInBoard())
        {
            Debug.LogError("씨 뿌리기 행동을 시작할 수 없습니다. 농장이 없습니다.");
            return false;
        }

        int wheat, vegetable;
        wheat = ResourceManager.instance.getResourceOfPlayer(board.player.id, "wheat");
        vegetable = ResourceManager.instance.getResourceOfPlayer(board.player.id, "vegetable");

        if(wheat+vegetable == 0)
        {
            Debug.LogError("씨 뿌리기 행동을 시작할 수 없습니다. 씨가 없습니다.");
            return false;
        }

        return true;
    }

    public override bool IsEndInstall()
    {
        bool isUserSowed = false;

        int needWheat = 0;
        int needVegetable = 0;

        for(int i=0;i<board.row;i++)
        {
            for(int j=0;j<board.col;j++)
            {
                if(board.blocks[i,j].sowingType != SeedType.NONE)
                {
                    isUserSowed = true;
                    if(board.blocks[i,j].sowingType == SeedType.WHEAT)
                    {
                        needWheat += 1;
                    }
                    else if(board.blocks[i,j].sowingType == SeedType.VEGETABLE)
                    {
                        needVegetable += 1;
                    }
                }
            }
        }

        int wheat, vegetable;
        wheat = ResourceManager.instance.getResourceOfPlayer(board.player.id, "wheat");
        vegetable = ResourceManager.instance.getResourceOfPlayer(board.player.id, "vegetable");

        if(!isUserSowed)
        {
            Debug.LogError("씨 뿌리기 행동을 종료할 수 없습니다. 씨를 뿌리지 않았습니다.");
            return false;
        }

        if(wheat < needWheat || vegetable < needVegetable)
        {
            Debug.LogError("씨 뿌리기 행동을 종료할 수 없습니다. 씨가 부족합니다.");
            return false;
        }
        
        return true;
    }

    void SetSeed()
    {
        int row = board.row;
        int col = board.col;
        Block[,] blocks = board.blocks;

        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                if(blocks[i,j].sowingType != SeedType.NONE)
                {
                    blocks[i,j].SetSeed(blocks[i,j].sowingType);
                }
                blocks[i,j].CloseSowing();
            }
        }
    }

    public void SetFarmBlockToSow()
    {
        int row = board.row;
        int col = board.col;
        Block[,] blocks = board.blocks;

        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                if(blocks[i,j].type == BlockType.FARM && blocks[i,j].seedType == SeedType.NONE)
                {
                    blocks[i,j].ShowSowing();
                }
            }
        }
    }
}
