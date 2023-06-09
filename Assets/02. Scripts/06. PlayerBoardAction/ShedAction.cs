﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ShedAction : PlayerBoardAction
{
    Player player;
    int playerID;

    public ShedAction(PlayerBoard board) : base(board)
    {
        player = board.player;
    }

    public override bool StartInstall()
    {
        if (IsStartInstall())
        {
            board.strategy = new ShedEventStrategy();

            Button button = board.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall());
        }
        else
        {
            Warner.instance.LogAction("외양간 설치 행동을 시작할 수 없습니다.");
            // Debug.LogError("외양간 설치 행동을 시작할 수 없습니다.");
            // GameManager.instance.PopQueue();
        }
        return false;
    }

    public override void EndInstall()
    {
        if (!IsEndInstall())
        {
            Debug.LogError("외양간 설치 행동을 끝낼 수 없습니다.");
            return;
        }

        foreach (Block block in board.selectedBlocks)
        {
            block.SetShed();
            block.ShowTransparent();
        }

        ResetBoard();
        GameManager.instance.PopQueue();
    }

    public override bool IsStartInstall()
    {
        player = board.player;
        playerID = player.id;
        int wood = ResourceManager.instance.getResourceOfPlayer(playerID, "wood");
        if(wood >= 2) return true;

        return false;
    }

    public override bool IsEndInstall()
    {
        int needWood = 2 * board.selectedBlocks.Count;
        int wood = ResourceManager.instance.getResourceOfPlayer(playerID, "wood");

        if (wood < needWood) return false;
        
        return true;
    }
}
