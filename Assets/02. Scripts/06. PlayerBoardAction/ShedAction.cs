using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ShedAction : PlayerBoardAction
{
    public override BoardEventStrategy StartInstall(PlayerBoard playerBoard)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy shedStrategy = new ShedEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return shedStrategy;
        }
        else
        {
            Debug.LogError("외양간 설치 행동을 시작할 수 없습니다.");
            return null;
        }
    }

    public override void EndInstall(PlayerBoard playerBoard)
    {
        if (IsEndInstall())
        {
            foreach (Block block in playerBoard.selectedBlocks)
            {
                block.SetShed();
                block.ShowTransparent();
            }
            playerBoard.selectedBlocks.Clear();
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }

    public override bool IsStartInstall()
    {
        Debug.LogError("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    public override bool IsEndInstall()
    {
        Debug.LogError("설치 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }
}
