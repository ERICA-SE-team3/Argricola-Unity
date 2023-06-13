using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandUIManager : MonoBehaviour
{
    public static HandUIManager instance;

    public int job1 = -1, job2;
    public int sub1, sub2;

    void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        if(job1 == -1)
        {
            job1 = GameManager.instance.deck.cards[GameManager.instance.localPlayerIndex].jobCards[0]-1;
            job2 = GameManager.instance.deck.cards[GameManager.instance.localPlayerIndex].jobCards[1]-1;

            sub1 = GameManager.instance.deck.cards[GameManager.instance.localPlayerIndex].facilityCards[0]-1;
            sub2 = GameManager.instance.deck.cards[GameManager.instance.localPlayerIndex].facilityCards[1]-1;
        }

        GameObject JobCardParent = transform.Find("Hands").Find("job").Find("cards").gameObject;
        GameObject SubCardParent = transform.Find("Hands").Find("sub").Find("cards").gameObject;

        for(int i = 0; i < 8; i++)
        {
            if(i == job1 || i == job2)
            {
                JobCardParent.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                JobCardParent.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,1f);
            }
        }

        for(int i = 0; i < 8; i++)
        {
            if(i == sub1 || i == sub2)
            {
                SubCardParent.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                SubCardParent.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,1f);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
