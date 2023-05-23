using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HouseEventStrategy : BoardEventStrategy
{
    public override void HoverEnter(PointerEventData eventData) {
        Debug.Log("HouseEventStrategy HoverEnter");
        Debug.Log(eventData.pointerEnter.name);
     }

    public override void HoverExit(PointerEventData eventData) { }

    public override void OnClick(PointerEventData eventData) { }
}
