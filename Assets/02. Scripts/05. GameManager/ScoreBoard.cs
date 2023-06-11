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
        int[] scoreIndex = new int[15] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] scoreCoefficent = new int[15] {0, 0, 0, 0, 0, 0, 0, -1, 0, 1, 2, 3, -3, 1, 1};
        int sum = 0;
        for(int playerIndex = 0; playerIndex < 4; playerIndex++){
            playerScoreBoard = playerScoreBoards[playerIndex];
            PlayerBoard playerBoard = GameManager.instance.playerBoards[playerIndex];
            scoreIndex = new int[15] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            scoreCoefficent = new int[15] {0, 0, 0, 0, 0, 0, 0, -1, 0, 1, 2, 3, -3, 1, 1};
            sum = 0;
            foreach(Block b in playerBoard.blocks){
                if(b.type == BlockType.FARM){
                    scoreIndex[0] += 1;
                    if(scoreIndex[0] < 2){
                        scoreCoefficent[0] = -1;
                    }
                    else if(scoreIndex[0] < 3){
                        scoreCoefficent[0] = 1;
                    }
                    else if(scoreIndex[0] < 4){
                        scoreCoefficent[0] = 2;
                    }
                    else if(scoreIndex[0] < 5){
                        scoreCoefficent[0] = 3;
                    }
                    else{
                        scoreCoefficent[0] = 4;
                    }
                }
                else if(b.type == BlockType.FENCE){
                    scoreIndex[1] += 1;
                    if(b.hasShed){
                        scoreIndex[8] += 1;
                        if(scoreIndex[1] < 1){
                            scoreCoefficent[1] = -1;
                        }
                        else if(scoreIndex[1] < 2){
                            scoreCoefficent[1] = 1;
                        }
                        else if(scoreIndex[1] < 3){
                            scoreCoefficent[1] = 2;
                        }
                        else if(scoreIndex[1] < 4){
                            scoreCoefficent[1] = 3;
                        }
                        else{
                            scoreCoefficent[1] = 4;
                        }
                    }
                }
                else if(b.type == BlockType.EMPTY){
                    scoreIndex[7] += 1;
                }
                else if(b.type == BlockType.HOUSE){
                    if(playerBoard.houseType == HouseType.CLAY){
                        scoreIndex[9] += 1;
                    }
                    else if(playerBoard.houseType == HouseType.STONE){
                        scoreIndex[10] += 1;
                    }
                }
            }

            //점수 범위에 따른 계수 설정
            scoreIndex[2] = GameManager.instance.players[playerIndex].wheat;
            if(scoreIndex[2] < 1){
                scoreCoefficent[2] = -1;
            }
            else if(scoreIndex[2] < 4){
                scoreCoefficent[2] = 1;
            }
            else if(scoreIndex[2] < 6){
                scoreCoefficent[2] = 2;
            }
            else if(scoreIndex[2] < 8){
                scoreCoefficent[2] = 3;
            }
            else{
                scoreCoefficent[2] = 4;
            }

            scoreIndex[3] = GameManager.instance.players[playerIndex].vegetable;
            if(scoreIndex[3] < 1){
                scoreCoefficent[3] = -1;
            }
            else if(scoreIndex[3] < 2){
                scoreCoefficent[3] = 1;
            }
            else if(scoreIndex[3] < 3){
                scoreCoefficent[3] = 2;
            }
            else if(scoreIndex[3] < 4){
                scoreCoefficent[3] = 3;
            }
            else{
                scoreCoefficent[3] = 4;
            }
            scoreIndex[4] = GameManager.instance.players[playerIndex].sheep;
            if(scoreIndex[4] < 1){
                scoreCoefficent[4] = -1;
            }
            else if(scoreIndex[4] < 4){
                scoreCoefficent[4] = 1;
            }
            else if(scoreIndex[4] < 6){
                scoreCoefficent[4] = 2;
            }
            else if(scoreIndex[4] < 8){
                scoreCoefficent[4] = 3;
            }
            else{
                scoreCoefficent[4] = 4;
            }
            scoreIndex[5] = GameManager.instance.players[playerIndex].pig;
            if(scoreIndex[5] < 1){
                scoreCoefficent[5] = -1;
            }
            else if(scoreIndex[5] < 3){
                scoreCoefficent[5] = 1;
            }
            else if(scoreIndex[5] < 5){
                scoreCoefficent[5] = 2;
            }
            else if(scoreIndex[5] < 7){
                scoreCoefficent[5] = 3;
            }
            else{
                scoreCoefficent[5] = 4;
            }

            scoreIndex[6] = GameManager.instance.players[playerIndex].cow;
            if(scoreIndex[6] < 1){
                scoreCoefficent[6] = -1;
            }
            else if(scoreIndex[6] < 2){
                scoreCoefficent[6] = 1;
            }
            else if(scoreIndex[6] < 4){
                scoreCoefficent[6] = 2;
            }
            else if(scoreIndex[6] < 6){
                scoreCoefficent[6] = 3;
            }
            else{
                scoreCoefficent[6] = 4;
            }

            scoreIndex[11] = GameManager.instance.players[playerIndex].family;
            scoreIndex[12] = GameManager.instance.players[playerIndex].begging;
            
            playerScoreBoard.transform.Find("scoreboardField").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[0].ToString();
            playerScoreBoard.transform.Find("scoreboardHutch").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[1].ToString();
            playerScoreBoard.transform.Find("scoreboardWheat").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[2].ToString();
            playerScoreBoard.transform.Find("scoreboardVegetable").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[3].ToString();
            playerScoreBoard.transform.Find("scoreboardSheep").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[4].ToString();
            playerScoreBoard.transform.Find("scoreboardPig").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[5].ToString();
            playerScoreBoard.transform.Find("scoreboardCow").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[6].ToString();
            playerScoreBoard.transform.Find("scoreboardBlank").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[7].ToString();
            playerScoreBoard.transform.Find("scoreboardShed").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[8].ToString();
            playerScoreBoard.transform.Find("scoreboardClayhouse").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[9].ToString();
            playerScoreBoard.transform.Find("scoreboardRockhouse").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[10].ToString();
            playerScoreBoard.transform.Find("scoreboardFamily").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[11].ToString();
            playerScoreBoard.transform.Find("scoreboardBegging").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[12].ToString();
            //playerScoreBoard.transform.Find("scoreboardCard").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[13].ToString();
            //playerScoreBoard.transform.Find("scoreboardAdditional").Find("NumberBox1").Find("NumberCounter").GetComponent<Text>().text = scoreIndex[14].ToString();
            
            playerScoreBoard.transform.Find("scoreboardField").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[0]*scoreCoefficent[0]).ToString();
            playerScoreBoard.transform.Find("scoreboardHutch").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[1]*scoreCoefficent[1]).ToString();
            playerScoreBoard.transform.Find("scoreboardWheat").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[2]*scoreCoefficent[2]).ToString();
            playerScoreBoard.transform.Find("scoreboardVegetable").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[3]*scoreCoefficent[3]).ToString();
            playerScoreBoard.transform.Find("scoreboardSheep").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[4]*scoreCoefficent[4]).ToString();
            playerScoreBoard.transform.Find("scoreboardPig").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[5]*scoreCoefficent[5]).ToString();
            playerScoreBoard.transform.Find("scoreboardCow").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[6]*scoreCoefficent[6]).ToString();
            playerScoreBoard.transform.Find("scoreboardBlank").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[7]*scoreCoefficent[7]).ToString();
            playerScoreBoard.transform.Find("scoreboardShed").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[8]*scoreCoefficent[8]).ToString();
            playerScoreBoard.transform.Find("scoreboardClayhouse").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[9]*scoreCoefficent[9]).ToString();
            playerScoreBoard.transform.Find("scoreboardRockhouse").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[10]*scoreCoefficent[10]).ToString();
            playerScoreBoard.transform.Find("scoreboardFamily").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[11]*scoreCoefficent[11]).ToString();
            playerScoreBoard.transform.Find("scoreboardBegging").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[12]*scoreCoefficent[12]).ToString();
            //playerScoreBoard.transform.Find("scoreboardCard").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[13]*scoreCoefficent[13]).ToString();
            //playerScoreBoard.transform.Find("scoreboardAdditional").Find("NumberBox2").Find("NumberCounter").GetComponent<Text>().text = (scoreIndex[14]*scoreCoefficent[14]).ToString();
            for(int i = 0; i < 15; i++){
                sum += scoreIndex[i]*scoreCoefficent[i];
            }
            playerScoreBoard.transform.Find("sum").Find("NumberBox").Find("NumberCounter").GetComponent<Text>().text = sum.ToString();
        }
    }
}
