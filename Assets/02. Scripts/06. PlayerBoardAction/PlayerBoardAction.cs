using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerBoardAction
{
    public PlayerBoard board;
    public PlayerBoardAction(PlayerBoard board) {
        this.board = board;
    }

    public virtual bool StartInstall() { return false; }

    public virtual void EndInstall() { }

    public virtual bool IsStartInstall() { return true; }

    public virtual bool IsEndInstall() { return true; }

    public void ResetBoard()
    {
        board.selectedBlocks.Clear();
        board.strategy = new BoardEventStrategy();
    }
}
