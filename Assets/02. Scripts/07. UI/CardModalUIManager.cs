using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModalUIManager : MonoBehaviour
{
    public void TakeCard()
    {
        GameManager.instance.PopQueue();
        gameObject.SetActive(false);
    }
}
