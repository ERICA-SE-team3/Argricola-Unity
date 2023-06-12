using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warner : MonoBehaviour
{
    public static Warner instance;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        text = transform.Find("Text").GetComponent<Text>();
        this.gameObject.SetActive(false);

    }

    public void LogWarning(string msg)
    {
        text.text = msg;
        this.gameObject.SetActive(true);    
    }
}
