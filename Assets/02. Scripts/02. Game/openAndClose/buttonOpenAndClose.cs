using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOpenAndClose : MonoBehaviour
{
    public GameObject handplayer1;

    public void closeHandPlayer1()
    {
        handplayer1.SetActive(false);
    }
}
