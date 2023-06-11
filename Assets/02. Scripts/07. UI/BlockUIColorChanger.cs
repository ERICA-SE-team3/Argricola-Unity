using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockUIColorChanger : MonoBehaviour
{
    Block block;

    public Sprite[] shedSprites;
    public Sprite[] familySprites;
    
    bool isUpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        block = transform.GetComponent<Block>();
    }
    
    private void Update() {
        if(!isUpdate)
        {
            isUpdate = true;
            transform.Find("Shed").GetComponent<Image>().sprite = shedSprites[block.board.player.id];
            transform.Find("Family").GetComponent<Image>().sprite = familySprites[block.board.player.id];
        }
    }
}
