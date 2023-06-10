using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class SowingAction : PlayerBoardAction
{

    public override BoardEventStrategy StartInstall(PlayerBoard playerBoard)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy sowingStrategy = new SowingEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return sowingStrategy;
        }
        else
        {
            Debug.LogError("씨 뿌리기 행동을 시작할 수 없습니다.");
            return null;
        }
    }
    
    public override void EndInstall(PlayerBoard playerBoard)
    {
        if (IsEndInstall())
        {
            // foreach (PlayerBoard.SowingBlockNode node in playerBoard.selectedSowingBlocks)
            // {
            //     node.block.SetSeed(node.type);
            // }
        }
        else
        {
            Debug.LogWarning("씨 뿌릴 수 없습니다. 다시 선택해주세요.");
        }
    }

    public override bool IsStartInstall()
    {
        Debug.LogError("씨뿌리기 시작 전 가능한지 검사하는 함수 " +
                        " - 아직 구현 안됨"); 
        return true;
    }

    public override bool IsEndInstall()
    {
        Debug.LogError("씨뿌리기 시작 전 가능한지 검사하는 함수 " +
                        " - 아직 구현 안됨");
        return true;
    }
}
