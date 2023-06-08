using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HouseAction : PlayerBoardAction
{
    public override BoardEventStrategy StartInstall(GameObject confirmButton, List<Block> selectedBlocks)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy houseStrategy = new HouseEventStrategy();

            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(selectedBlocks));
            return houseStrategy;
        }
        else
        {
            Debug.LogError("집 설치 행동을 시작할 수 없습니다.");
            return null;
        }
        return null;
    }

    public override void EndInstall(List<Block> selectedBlocks)
    {
        if (IsEndInstall())
        {
            foreach (Block block in selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeHouse();
            }
            selectedBlocks.Clear();
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
