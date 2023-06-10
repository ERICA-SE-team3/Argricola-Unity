using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerBoardAction
{
    public virtual BoardEventStrategy StartInstall(PlayerBoard playerBoard) { return null; }

    public virtual void EndInstall(PlayerBoard playerBoard) { }

    public virtual bool IsStartInstall() { return true; }

    public virtual bool IsEndInstall() { return true; }
}
