using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SidebarManager : MonoBehaviour
{
    public static SidebarManager instance;

    public void Awake()
    {
        SidebarManager.instance = this;
    }

    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        GameObject sidebarPlayerObject = players[GameManager.instance.localPlayerIndex];
        sidebarPlayerObject.transform.Find("selfObject").GetComponent<Text>().enabled = true;
    }

    // Update is called once per frame
    public void SidebarUpdate(int playerIndex){
        GameObject sidebarPlayerObject = players[playerIndex];
        sidebarPlayerObject.transform.Find("woodObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].wood.ToString();
        sidebarPlayerObject.transform.Find("clayObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].clay.ToString();
        sidebarPlayerObject.transform.Find("rockObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].rock.ToString();
        sidebarPlayerObject.transform.Find("reedObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].reed.ToString();
        sidebarPlayerObject.transform.Find("wheatObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].wheat.ToString();
        sidebarPlayerObject.transform.Find("vegetableObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].vegetable.ToString();
        sidebarPlayerObject.transform.Find("foodObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].food.ToString();
        sidebarPlayerObject.transform.Find("beggingObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].begging.ToString();
        sidebarPlayerObject.transform.Find("cowObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].cow.ToString();
        sidebarPlayerObject.transform.Find("pigObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].pig.ToString();
        sidebarPlayerObject.transform.Find("sheepObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].sheep.ToString();
        sidebarPlayerObject.transform.Find("familyObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].family.ToString();
        sidebarPlayerObject.transform.Find("fenceObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].fence.ToString();
        sidebarPlayerObject.transform.Find("shedObject").Find("NumberBox").Find("NumberCounter").GetComponent<TMPro.TMP_Text>().text = GameManager.instance.players[playerIndex].shed.ToString();
        if(isMyTurn(playerIndex)){
            UpperbarResource.instance.UpperbarResourcebarUpdate(playerIndex);
        }
    }

    public void HighlightCurrentPlayer(int playerIndex){
        GameObject sidebarPlayerObject;
        for(int i = 0; i < 4; i++){
            sidebarPlayerObject = players[i];
            if(i == playerIndex){
                sidebarPlayerObject.GetComponentInChildren<Outline>().enabled = true;
            }else{
                sidebarPlayerObject.GetComponentInChildren<Outline>().enabled = false;
            }
        }
    }

    public void FirstPlayerIcon(int playerIndex){
        GameObject sidebarPlayerObject;
        for(int i = 0; i < 4; i++){
            sidebarPlayerObject = players[i];
            if(i == playerIndex){
                sidebarPlayerObject.transform.Find("firstObject").Find("firstPlayer").GetComponent<Image>().enabled = true;
            }else{
                sidebarPlayerObject.transform.Find("firstObject").Find("firstPlayer").GetComponent<Image>().enabled = false;
            }
        }
    }

    public bool isMyTurn(int playerIndex){
        return GameManager.instance.localPlayerIndex == playerIndex;
    }
}
