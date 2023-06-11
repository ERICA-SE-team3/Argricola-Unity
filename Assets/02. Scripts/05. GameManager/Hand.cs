using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject handplayer1;

    public void closeHandPlayer1()
    {
        handplayer1.SetActive(false);
    }

    public void openHandPlayer1()
    {
        handplayer1.SetActive(true);
    }
}

