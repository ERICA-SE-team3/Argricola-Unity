using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    static Text textBox; 

    void Start()
    {
        textBox = this.transform.GetComponent<Text>();
        textBox.text = "";
    }

    public static void Log(MessageData messageData)
    {
        textBox.text += "- 플레이어 " + messageData.actionPlayerId + "가 " + messageData.actionType + " 행동을 했습니다.\n";
    }
}
