using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpperbarResource : MonoBehaviour
{
    public static UpperbarResource instance;

    public GameObject upperbar;
    public void Awake() {
        UpperbarResource.instance = this;
    }
    // Start is called before the first frame update

    public void UpperbarResourcebarUpdate(int playerIndex){
        upperbar.transform.Find("family").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].family.ToString();
        upperbar.transform.Find("fence").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].fence.ToString();
        upperbar.transform.Find("shed").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].shed.ToString();
        upperbar.transform.Find("cow").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].cow.ToString();
        upperbar.transform.Find("pig").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].pig.ToString();
        upperbar.transform.Find("sheep").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].sheep.ToString();
        upperbar.transform.Find("clay").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].clay.ToString();
        upperbar.transform.Find("rock").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].rock.ToString();
        upperbar.transform.Find("reed").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].reed.ToString();
        upperbar.transform.Find("wood").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].wood.ToString();
        upperbar.transform.Find("wheat").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].wheat.ToString();
        upperbar.transform.Find("vegetable").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].vegetable.ToString();
        upperbar.transform.Find("food").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].food.ToString();
        upperbar.transform.Find("begging").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].begging.ToString();
    }
}
