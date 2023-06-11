using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerIndex : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = "Player: "+ GameManager.instance.localPlayerIndex.ToString();        
    }
}
