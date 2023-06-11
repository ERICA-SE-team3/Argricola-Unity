using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : MonoBehaviour
{
    public static EndPhase instance;

    public void Awake()
    {
        EndPhase.instance = this;
    }

    public void EndGame(){
        public GameObject ScoreBoard;
        ScoreBoard.SetActive(true);
        ScoreBoard.instance.ScoreBoardUpdate();
    }
}
