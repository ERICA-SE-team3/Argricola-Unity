using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public List<GameObject> playerScoreBoards;
    public void UpdateScore()
    {
        GameObject playerScoreBoard;
        int[] scoreIndex = new int[15];
        for(int playerIndex = 0; playerIndex < 4; playerIndex++){
            playerScoreBoard = playerScoreBoards[playerIndex];
            int sum = 0;
            //scoreIndex[0] = GameManager.instance.players[playerIndex].filed.ToString();
            //scoreIndex[0] = GameManager.instance.players[playerIndex].hutch.ToString();
            scoreIndex[0] = GameManager.instance.players[playerIndex].wheat;
            scoreIndex[0] = GameManager.instance.players[playerIndex].vegetable;
            scoreIndex[0] = GameManager.instance.players[playerIndex].sheep;
            scoreIndex[0] = GameManager.instance.players[playerIndex].pig;
            scoreIndex[0] = GameManager.instance.players[playerIndex].cow;
            //scoreIndex[0] = GameManager.instance.players[playerIndex].blank;
            scoreIndex[0] = GameManager.instance.players[playerIndex].shed;
            scoreIndex[0] = GameManager.instance.players[playerIndex].room;
            //scoreIndex[0] = GameManager.instance.players[playerIndex].room;
            scoreIndex[0] = GameManager.instance.players[playerIndex].family;
            scoreIndex[0] = GameManager.instance.players[playerIndex].begging;
            //scoreIndex[0] = GameManager.instance.players[playerIndex].card;
            //scoreIndex[0] = GameManager.instance.players[playerIndex].additional;
            //this.transform.Find("scoreboardField").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            //this.transform.Find("scoreboardHutch").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardWheat").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardVegetable").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardSheep").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardPig").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardCow").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            //playerScoreBoard.transform.Find("scoreboardBlank").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardShed").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardClayhouse").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            //playerScoreBoard.transform.Find("scoreboardRockhouse").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardFamily").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardBegging").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            //playerScoreBoard.transform.Find("scoreboardCard").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            //playerScoreBoard.transform.Find("scoreboardAdditional").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            
        }
    }
}
