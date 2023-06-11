using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MoveAnimalAction : PlayerBoardAction
{
    public MoveAnimalAction(PlayerBoard board) : base(board) { }

    public override bool StartInstall()
    {
        if (!IsStartInstall())
        {
            Debug.LogError("동물 옮기기 행동을 시작할 수 없습니다.");
            return false;
        }

        BoardEventStrategy moveAnimalStrategy = new MoveAnimalEventStrategy();

        Button button = board.confirmButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => EndInstall());

        return true;
    }

    public override void EndInstall()
    {
        if(!IsEndInstall())
        {
            Debug.LogError("동물 옮기기 행동을 종료할 수 없습니다.");
            return;
        }

        ResetBoard();
        GameManager.instance.PopQueue();
    }

    public override bool IsStartInstall()
    {
        if(board.player.sheep + board.player.pig + board.player.cow == 0)
        {
            Debug.LogError("동물이 없습니다.");
            return false;
        }
        return true;
    }

    public override bool IsEndInstall()
    {
        if(AnimalModalManager.leftCow + AnimalModalManager.leftPig + AnimalModalManager.leftSheep == 0)
        {
            return true;
        }
        else
        {
            Debug.LogError("동물을 모두 옮기지 않았습니다.");
            return false;
        }
    }
}
