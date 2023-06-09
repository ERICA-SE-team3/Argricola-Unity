using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbySceneManager : MonoBehaviour
{
    Text loadingText;
    int maxPlayer = 4;
    public int playerCount = 0;
    
    GameObject buffering, Blocker, LoadingComment;

    public bool ReadyFlag = false;

    private void Start() {
        buffering = transform.Find("Buffering").gameObject;
        Blocker = transform.Find("Blocker").gameObject;
        LoadingComment = transform.Find("LoadingComment").gameObject;

        loadingText = LoadingComment.GetComponent<Text>();
    }
    public void GetReady()
    {
        ReadyFlag = true;
    }


    public void WrongButton()
    {
        GameObject Warning = transform.Find("Warning").gameObject;
        Warning.SetActive(false);
        Warning.SetActive(true);
    }


    private void Update() {
        if(ReadyFlag)
        {
            buffering.SetActive(true);
            Blocker.SetActive(true);
            LoadingComment.SetActive(true);
            ReadyFlag = false;
        }

        if(loadingText != null)
        {
            loadingText.text = "Loading..." + playerCount + "/" + maxPlayer;
        }

        if(playerCount == maxPlayer)
        {
            maxPlayer += 1;
            SceneManager.LoadSceneAsync("Game");
        }
    }


}
    
