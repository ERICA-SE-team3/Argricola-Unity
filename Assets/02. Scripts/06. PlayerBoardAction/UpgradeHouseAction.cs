﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UpgradeHouseAction : PlayerBoardAction
{
    Player player;
    HouseType houseType;
    int playerID;
    Block[,] blocks;

    public UpgradeHouseAction(PlayerBoard board) : base(board) 
    {
        player = board.player;
        houseType = board.houseType;
        playerID = board.player.id;
        blocks = board.blocks;
    }

    public override bool StartInstall()
    {
        if(!IsStartInstall())
        {
            Debug.LogError("집 업그레이드 행동을 시작할 수 없습니다.");
            return false;
        }

        board.strategy = new BoardEventStrategy();
        board.houseType += 1;
        UpgradeHouse();
        return true;
    }


    public override bool IsStartInstall()
    {
        player = board.player;
        houseType = board.houseType;
        playerID = board.player.id;
        blocks = board.blocks;

        if(houseType == HouseType.STONE) { 
            Debug.LogWarning("더이상 집을 업그레이드 할 수 없습니다.");
            return false; 
        }
        
        int houseNumber = 0;
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.HOUSE) { houseNumber++; }
        }

        int playerReed, playerWood, playerClay, playerStone;
        playerReed = ResourceManager.instance.getResourceOfPlayer(player.id, "reed");
        playerWood = ResourceManager.instance.getResourceOfPlayer(player.id, "wood");
        playerClay = ResourceManager.instance.getResourceOfPlayer(player.id, "clay");
        playerStone = ResourceManager.instance.getResourceOfPlayer(player.id, "stone");

        switch(houseType)
        {
            case HouseType.WOOD:

                if(playerClay < 1 * houseNumber || playerReed < 1) {
                    Debug.LogWarning("자원이 부족합니다.");
                    return false; 
                }
                break;

            case HouseType.CLAY:
                if(playerStone < 1 * houseNumber || playerReed < 1) {
                    Debug.LogWarning("자원이 부족합니다.");
                    return false; 
                }
                break;

            case HouseType.STONE:
                Debug.Log("돌집을 업그레이드 할 수 없습니다.");
                return false;
        }
        return true;
    }

    void UpgradeHouse()
    {
        Debug.Log("HouseType:" + houseType);
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.HOUSE) {
                block.ChangeHouse(); 
                ResourceManager.instance.minusResource(player.id, houseType.ToString().ToLower(), 1);
            }
        }
        ResourceManager.instance.minusResource(player.id, "reed", 1);
        
        //돌 자르는 사람
        if( houseType == HouseType.STONE ) {
                    if( player.HasJobCard( "stoneCutter" ) ) {
                        ResourceManager.instance.addResource( player.id, "stone", 1 );
                        Debug.Log( "Player " + player.id + " get 1 stone because of STONECUTTER" );
                    }
        }

        //초벽질공
        if( houseType == HouseType.STONE ) {
                    if( player.HasJobCard( "wallMaster" ) ) {
                        ResourceManager.instance.addResource( player.id, "food", 3 );
                        Debug.Log( "Player " + player.id + " get 3 food because of WALLMASTER" );
                    }
        }
    }
}
