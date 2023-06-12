using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HouseAction : PlayerBoardAction
{
    Player player;
    HouseType houseType;
    int playerID; 

    public HouseAction(PlayerBoard board) : base(board) 
    {
        player = board.player;
        houseType = board.houseType;
    }

    public override bool StartInstall()
    {
        if (IsStartInstall())
        {
            board.strategy = new HouseEventStrategy();

            Button button = board.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall());
        }
        else
        {
            Debug.LogError("집 설치 행동을 시작할 수 없습니다.");
        }
        return false;
    }

    public override void EndInstall()
    {
        if(!IsEndInstall())
        {
            Debug.LogError("집 설치 행동을 끝낼 수 없습니다.");
            return;
        }

        if (IsEndInstall())
        {
            foreach (Block block in board.selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeHouse();
                
                int playerID = board.player.id;
                ResourceManager.instance.minusResource(playerID, houseType.ToString().ToLower(), 5);
                ResourceManager.instance.minusResource(playerID, "reed", 2);
            }
            board.selectedBlocks.Clear();

            //돌 자르는 사람
            if (houseType == HouseType.STONE) 
            {
                if (player.HasJobCard("stoneCutter")) 
                {
                    ResourceManager.instance.addResource(player.id,"stone",1);
                    Debug.Log("Player " + player.id + " get 1 stone because of STONECUTTER");
                }
            }

            //초벽질공
            if (houseType == HouseType.CLAY) 
            {
                if(player.HasJobCard("wallMaster")) 
                {
                    ResourceManager.instance.addResource(player.id, "food", 3);
                    Debug.Log("Player " + player.id + " get 3 food because of WALLMASTER");
                }
            }
        }

        ResetBoard();
        GameManager.instance.PopQueue();
    }

    public override bool IsStartInstall()
    {
        if(player.room >= Player.MAXROOM)
        {
            Debug.LogWarning("더이상 집을 지을 수 없습니다.");
            return false;
        }

        // 집을 지을 공간이 더 없다면 설치 불가
        // 구현 예정

        int playerReed, playerWood, playerClay, playerStone;
        playerReed = ResourceManager.instance.getResourceOfPlayer(player.id, "reed");
        playerWood = ResourceManager.instance.getResourceOfPlayer(player.id, "wood");
        playerClay = ResourceManager.instance.getResourceOfPlayer(player.id, "clay");
        playerStone = ResourceManager.instance.getResourceOfPlayer(player.id, "stone");

        if(playerReed < 2)
        {
            Debug.LogWarning("갈대가 부족합니다.");
            return false;
        }

        switch(houseType)
        {
            case HouseType.WOOD:
                if(playerWood < 5)
                {
                    Debug.LogWarning("목재가 부족합니다.");
                    return false;
                }
                break;
            case HouseType.CLAY:
                if(playerClay < 5)
                {
                    Debug.LogWarning("점토가 부족합니다.");
                    return false;
                }
                break;
            case HouseType.STONE:
                if(playerStone < 5)
                {
                    Debug.LogWarning("돌이 부족합니다.");
                    return false;
                }
                break;
        }
        return true;
    }

    public override bool IsEndInstall()
    {
        List<Block> selectedBlocks = board.selectedBlocks;

        //1. 집을 하나도 선택하지 않은 채로
        if(selectedBlocks.Count == 0)
        {
            Debug.LogWarning("선택된 블록이 없습니다.");
            return false;
        }

        //2. 선택한 집 갯수를 지을 수 있는 자원이 있나
        int playerWood, playerClay, playerStone, playerReed;
        playerReed = ResourceManager.instance.getResourceOfPlayer(player.id, "reed");
        playerWood = ResourceManager.instance.getResourceOfPlayer(player.id, "wood");
        playerClay = ResourceManager.instance.getResourceOfPlayer(player.id, "clay");
        playerStone = ResourceManager.instance.getResourceOfPlayer(player.id, "stone");

        if(playerReed < selectedBlocks.Count * 2)
        {
            Debug.LogWarning("갈대가 부족합니다.");
            return false;
        }

        switch(houseType)
        {
            case HouseType.WOOD:
                if(playerWood < selectedBlocks.Count * 5)
                {
                    Debug.LogWarning("목재가 부족합니다.");
                    return false;
                }
                break;
            case HouseType.CLAY:
                if(playerStone < selectedBlocks.Count * 5)
                {
                    Debug.LogWarning("점토가 부족합니다.");
                    return false;
                }
                break;
            case HouseType.STONE:
                if(playerClay < selectedBlocks.Count * 5)
                {
                    Debug.LogWarning("돌이 부족합니다.");
                    return false;
                }
                break;
        }

        Debug.LogWarning("설치 가능한지 검사하는 함수");
        return true;
    }
}
