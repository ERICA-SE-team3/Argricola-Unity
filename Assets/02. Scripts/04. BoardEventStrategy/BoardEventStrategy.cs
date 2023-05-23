using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardEventStrategy
{
    public virtual void HoverEnter(PointerEventData eventData) { }

    public virtual void HoverExit(PointerEventData eventData) { }

    public virtual void OnClick(PointerEventData eventData) { }
}
