using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndPhase : MonoBehaviour
{
    public static EndPhase instance;

    GameObject scoreBoard;

    private void Start() {
        instance = this;
        scoreBoard = this.gameObject;
        gameObject.SetActive(false);
    }
    
    public void EndGame(){
        scoreBoard.SetActive(true);
        ScoreBoard.instance.UpdateScore();

        this.transform.Find("buttonClose").Find("Text").GetComponent<Text>().text = "로비로";
        this.transform.Find("buttonClose").GetComponent<Button>().onClick.RemoveAllListeners();
        this.transform.Find("buttonClose").GetComponent<Button>().onClick.AddListener(() =>MoveToLobby());
    }

    void MoveToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
