using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : MonoBehaviour
{
    public static EndPhase instance;

    public GameObject scoreBoard;

    public void Awake()
    {
        EndPhase.instance = this;
    }
    
    public void EndGame(){
        scoreBoard.SetActive(true);
        ScoreBoard.instance.UpdateScore();
    }
}
