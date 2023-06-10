using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundDescriptor : MonoBehaviour
{
    public static RoundDescriptor instance;
    public GameObject roundDescriptior;
    public void Awake() {
        RoundDescriptor.instance = this;
    }

    public void RoundNumberUpdate(int round){
        roundDescriptior.transform.Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = round.ToString();
    }

    public void RoundDescriptiorUpdate(string description){
        roundDescriptior.transform.Find("StringBox").Find("StringDescription").GetComponent<Text>().text = description;
    }
    // Start is called before the first frame update
}
