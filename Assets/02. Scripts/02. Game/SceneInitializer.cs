using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public GameObject playerBoardsParent, roundButtonParent;

    private void Start() 
    {
        InitGameManager();
        GameManager.instance.preRound();

        for(int i = 0; i < 4; i++){
            SidebarManager.instance.SidebarUpdate(i);
        }

        GameManager.instance.isGameScene = true;
    }

    public void InitGameManager()
    {
        GameManager.instance.Init();

        //playerboard start
        for (int i = 0; i < 4; i++)
        {
            PlayerBoard tmpPlayerBoard = playerBoardsParent.transform.GetChild(i).GetComponent<PlayerBoard>();
            tmpPlayerBoard.SetPlayer(GameManager.instance.players[i]);
            GameManager.instance.playerBoards.Add(tmpPlayerBoard);
        }

         //라운드 카드 가져오기
        for (int i=0; i<14; i++)
        {
            //라운드 카드 받아오기
            GameObject tmp = this.roundButtonParent.transform.GetChild(i).gameObject;
            GameManager.instance.roundcards.Add(tmp);
            GameManager.instance.roundcards[i].SetActive(false);
        }
    }


}
