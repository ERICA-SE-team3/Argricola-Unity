using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionDescriptor : MonoBehaviour
{
    public static ActionDescriptor instance;
    public GameObject actionDescriptor;
    public void Awake() {
        ActionDescriptor.instance = this;
    }

    public void ActionDescriptorUpdate(string description){
        GameObject actionDescriptorObject = actionDescriptor;
        actionDescriptorObject.transform.Find("StringBox").Find("StringDescription").GetComponent<Text>().text = description;
    }
}
