using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public GameObject playerBoardsParent, roundButtonParent;

    public GameObject sheepMarket, wishChildren, westernQuarry, pigMarket, vegetableSeed, easternQuarry, cowMarket;
    public GameObject grainUtilization, fencing, houseDevelop, cultivation, farmDevelop, improvements, urgentWishChildren;
    public GameObject clayPit, copse, dayLaborer, dirtPit, expand, farming, fishing, forest, grainSeed, grove, lessonFood1, lessonFood2, meeting, reedFeild, resMarket, trevelingTheater;
    public GameObject scoreBoard;


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

        GameManager.instance.sheepMarket = sheepMarket;
        GameManager.instance.wishChildren = wishChildren;
        GameManager.instance.westernQuarry = westernQuarry;
        GameManager.instance.pigMarket = pigMarket;
        GameManager.instance.vegetableSeed = vegetableSeed;
        GameManager.instance.easternQuarry = easternQuarry;
        GameManager.instance.cowMarket = cowMarket;
        GameManager.instance.grainUtilization = grainUtilization;
        GameManager.instance.fencing = fencing;
        GameManager.instance.houseDevelop = houseDevelop;
        GameManager.instance.cultivation = cultivation;
        GameManager.instance.farmDevelop = farmDevelop;
        GameManager.instance.improvements = improvements;
        GameManager.instance.urgentWishChildren = urgentWishChildren;
        GameManager.instance.clayPit = clayPit;
        GameManager.instance.copse = copse;
        GameManager.instance.dayLaborer = dayLaborer;
        GameManager.instance.dirtPit = dirtPit;
        GameManager.instance.expand = expand;
        GameManager.instance.farming = farming;
        GameManager.instance.fishing = fishing;
        GameManager.instance.forest = forest;
        GameManager.instance.grainSeed = grainSeed;
        GameManager.instance.grove = grove;
        GameManager.instance.lessonFood1 = lessonFood1;
        GameManager.instance.lessonFood2 = lessonFood2;
        GameManager.instance.meeting = meeting;
        GameManager.instance.reedFeild = reedFeild;
        GameManager.instance.resMarket = resMarket;
        GameManager.instance.trevelingTheater = trevelingTheater;
        GameManager.instance.scoreBoard = scoreBoard;
    }

}
