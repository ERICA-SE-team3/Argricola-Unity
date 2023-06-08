using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerBoardAction
{
    public virtual BoardEventStrategy StartInstall(GameObject confirmButton, List<Block> selectedBlocks) { }

    public virtual void EndInstall(List<Block> selectedBlocks) { }

    public virtual bool IsStartInstall() { return true; }

    public virtual bool IsEndInstall() { return true; }
}
