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
        GameObject roundDescriptiorObject = roundDescriptior;
        roundDescriptiorObject.transform.Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = round.ToString();
    }

    public void RoundDescriptiorUpdate(string description){
        GameObject roundDescriptiorObject = roundDescriptior;
        roundDescriptiorObject.transform.Find("StringBox").Find("StringDescription").GetComponent<Text>().text = description;
    }
    // Start is called before the first frame update
}
