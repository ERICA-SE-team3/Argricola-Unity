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
        GameObject upperbarResource = upperbar;
        upperbarResource.transform.Find("family").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].family.ToString();
        upperbarResource.transform.Find("fence").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].fence.ToString();
        upperbarResource.transform.Find("shed").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].shed.ToString();
        upperbarResource.transform.Find("cow").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].cow.ToString();
        upperbarResource.transform.Find("pig").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].pig.ToString();
        upperbarResource.transform.Find("sheep").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].sheep.ToString();
        upperbarResource.transform.Find("clay").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].clay.ToString();
        upperbarResource.transform.Find("rock").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].rock.ToString();
        upperbarResource.transform.Find("reed").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].reed.ToString();
        upperbarResource.transform.Find("wood").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].wood.ToString();
        upperbarResource.transform.Find("wheat").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].wheat.ToString();
        upperbarResource.transform.Find("vegetable").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].vegetable.ToString();
        upperbarResource.transform.Find("food").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].food.ToString();
        upperbarResource.transform.Find("begging").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = GameManager.instance.players[playerIndex].begging.ToString();
    }
}
