using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : ButtonParents
{
    public GameObject scoreBoard;

    public override void OnClick(){
        Instantiate(scoreBoard);
    }
}
