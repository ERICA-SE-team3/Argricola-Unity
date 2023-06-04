using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public PlayerBoard board;
    GameObject currentBackground, backgroundParent;

    public int row, col;
    public BlockType type;
    public bool hasShed;
    public bool[] fence;
    public int cow, pig, sheep, family;
    public SeedType seedType;
    public int seedCount;
    
    public void Init(PlayerBoard board, int row, int col, BlockType type)
    {
        this.board = board;
        this.row = row; this.col = col;
        this.type = type;
        hasShed = false;
        fence = new bool[4] {false,false,false,false};
        
        cow = 0; pig = 0; sheep = 0; family = 0;

        seedType = SeedType.NONE;
        seedCount = 0;

        backgroundParent = this.transform.Find("Backgrounds").gameObject;
        currentBackground = backgroundParent.transform.Find("Empty").gameObject;
    }

    public bool ChangeBlockType(BlockType type)
    {
        switch(type)
        {
            case BlockType.FARM:
                if(this.type == BlockType.FARM)
                    return false;
                return ChangeFarm();
            case BlockType.FENCE:
                if(this.type == BlockType.FENCE)
                    return false;
                return ChangeFence();
            case BlockType.HOUSE:
                if(this.type == BlockType.HOUSE)
                    return false;
                return ChangeHouse();
            case BlockType.EMPTY:
                return false;
            default:
                return false;
        }
    }

    public bool ChangeFarm()
    {
        currentBackground?.SetActive(false);
        currentBackground = backgroundParent.transform.Find("Farm").gameObject;
        currentBackground.SetActive(true);
        type = BlockType.FARM;
        return true;
    }

    public bool ChangeFence()
    {
        currentBackground?.SetActive(false);
        currentBackground = backgroundParent.transform.Find("Fences").gameObject;
        currentBackground.SetActive(true);
        type = BlockType.FENCE;
        return true;
    }

    public bool ChangeHouse()
    {
        currentBackground?.SetActive(false);
        string houseName = GetHouseBackgroundName(board.houseType);
        currentBackground = backgroundParent.transform.Find(houseName).gameObject;
        currentBackground.SetActive(true);
        type = BlockType.HOUSE;
        return true;
    }

    public bool ChangeEmpty()
    {
        currentBackground?.SetActive(false);
        currentBackground = backgroundParent.transform.Find("Empty").gameObject;
        currentBackground.SetActive(true);
        type = BlockType.EMPTY;
        return true;
    }

    public bool ShowGreen()
    {
        RawImage empty = backgroundParent.transform.Find("Empty").GetComponent<RawImage>();

        Color color = new Color(0,0.5f,0);
        color.a = 0.725f;
        empty.color = color; 

        return true;
    }

    public bool ShowRed()
    {
        backgroundParent.transform.Find("Empty").gameObject.SetActive(true);
        RawImage empty = backgroundParent.transform.Find("Empty").GetComponent<RawImage>();
    
        Color color = new Color(0.5f,0,0);
        color.a = 0.725f;
        empty.color = color;

        return true;
    }

    public bool ShowTransparent()
    {
        backgroundParent.transform.Find("Empty").gameObject.SetActive(false);
        RawImage empty = backgroundParent.transform.Find("Empty").GetComponent<RawImage>();
        // hex : #FFFFFFF00
        empty.color = new Color(255,255,255,0);
        return true;
    }

    public void ShowSowing()
    {
        // backgroundParent.transform.Find("Empty").gameObject.SetActive(true);
        // RawImage empty = backgroundParent.transform.Find("Empty").GetComponent<RawImage>();
        // // hex : #FFFFFFF00
        // empty.color = new Color(255,255,255,0.725f);
    }

    public void ShowConfirm()
    {
        // backgroundParent.transform.Find("Empty").gameObject.SetActive(true);
        // RawImage empty = backgroundParent.transform.Find("Empty").GetComponent<RawImage>();
        // // hex : #FFFFFFF00
        // empty.color = new Color(255,255,255,0.725f);
    }

    string GetHouseBackgroundName(HouseType type)
    {
        switch(type)
        {
            case HouseType.WOOD:
                return "WoodHouse";
            case HouseType.CLAY:
                return "ClayHouse";
            case HouseType.STONE:
                return "StoneHouse";
            default:
                throw new System.Exception("Wrong HouseType");
        }
    }

    public BlockData GetBlockData()
    {
        BlockData blockData = new BlockData();
        blockData.row = row; blockData.col = col;
        blockData.type = type;
        blockData.hasShed = hasShed;
        blockData.fence = fence;
        blockData.cow = cow; blockData.pig = pig; blockData.sheep = sheep; blockData.family = family;
        blockData.seedType = seedType; blockData.seedCount = seedCount;
        return blockData;
    }

    public void SetSeed(SeedType type) 
    {
        if(type == SeedType.WHEAT)
        {
            seedType = type;
            seedCount = 3;
        }
        if(type == SeedType.VEGETABLE)
        {
            seedType = type;
            seedCount = 2;
        }
    }

    public void SetAnimal(int sheep, int pig, int cow) 
    {
        this.sheep = sheep; this.pig = pig; this.cow = cow;
    }

    public void SetShed() 
    {
        this.hasShed = true;
        this.transform.Find("Shed").gameObject.SetActive(true);
    }

    public void SetFence(bool[] dir) 
    {
        // dir : {상, 하, 좌, 우}
        for(int i = 0; i < 4; i++)
        {
            fence[i] = dir[i];
            backgroundParent.transform.Find("Fences").GetChild(i).gameObject.SetActive(fence[i]);
        }
    }

    public void _TestSetFence()
    {
        bool[] dir = {true, true, true, true};
        SetFence(dir);
        ChangeFence();
    }

    public void _TestSetShed()
    {
        SetShed();
    }

    public void _TestSetHouse()
    {
        ChangeHouse();
    }

    public void _TestSetFarm()
    {
        ChangeFarm();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        board.OnHoverEnter(this);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(transform))
            return;

        board.OnHoverExit(this);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        board.OnClick(this);
    }

}
