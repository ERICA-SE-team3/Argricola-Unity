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

    public void GetReady()
    {
        GameObject buffering = transform.Find("Buffering").gameObject;
        buffering.SetActive(true);
        GameObject Blocker = transform.Find("Blocker").gameObject;
        Blocker.SetActive(true);

        GameObject LoadingComment = transform.Find("LoadingComment").gameObject;
        loadingText = LoadingComment.GetComponent<Text>();
    }

    public void WrongButton()
    {
        GameObject Warning = transform.Find("Warning").gameObject;
        Warning.SetActive(false);
        Warning.SetActive(true);
    }


    private void Update() {
        if(loadingText != null)
        {
            loadingText.text = "Loading..." + playerCount + "/" + maxPlayer;
        }
        if(playerCount == maxPlayer)
        {
            maxPlayer += 1;
            SceneManager.LoadSceneAsync("GameScene");
        }
    }


}
    
