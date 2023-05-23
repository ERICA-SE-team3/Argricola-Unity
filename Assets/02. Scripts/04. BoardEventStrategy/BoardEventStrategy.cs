using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardEventStrategy
{
    public virtual void OnHoverEnter(Block block) { }

    public virtual void OnHoverExit(Block block) { }

    public virtual void OnClick(Block block) { }
}
