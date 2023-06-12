using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleCounter : MonoBehaviour
{
    public Text textObject;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<Text>();
        textObject.text = count.ToString();
    }

    // Update is called once per frame
    void CountUp()
    {
        count++;
        textObject.text = count.ToString();
    }

    void CountDown()
    {
        if (count > 0) {
            count--;
            textObject.text = count.ToString();
        }
    }
        public void OnCountUpButtonClick()
    {
        CountUp();
    }
    
    public void OnCountDownButtonClick()
    {
        CountDown();
    }
}