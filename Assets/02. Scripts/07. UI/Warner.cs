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
        this.gameObject.transform.Find("Button").GetComponent<Button>().onClick.RemoveAllListeners();
        text.text = msg;
        this.gameObject.SetActive(true);
    }

    public void LogAction(string msg)
    {
        Debug.Log(msg);
        text.text = msg;
        this.gameObject.SetActive(true);
        this.gameObject.transform.Find("Button").GetComponent<Button>().onClick.RemoveAllListeners();
        this.gameObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => GameManager.instance.PopQueue());
    }   
}
