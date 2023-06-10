using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class AnimalAction : PlayerBoardAction
{
    public override BoardEventStrategy StartInstall(PlayerBoard playerBoard)
    {
        if (IsStartInstall())
        {
            BoardEventStrategy moveAnimalStrategy = new MoveAnimalEventStrategy();

            Button button = playerBoard.confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => EndInstall(playerBoard));
            return moveAnimalStrategy;
        }
        else
        {
            Debug.LogError("동물 옮기기 행동을 시작할 수 없습니다.");
            return null;
        }
    }

    public override void EndInstall(PlayerBoard playerBoard)
    {
        if (IsEndInstall())
        {
            throw new System.NotImplementedException();
        }
        else
        {
            Debug.LogWarning("동물 옮길 수 없습니다. 다시 선택해주세요.");
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
