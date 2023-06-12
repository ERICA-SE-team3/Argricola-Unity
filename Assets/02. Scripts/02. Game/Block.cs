using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Block : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public PlayerBoard board;
    GameObject currentBackground, backgroundParent;

    public int row, col;
    public BlockType type;
    public bool hasShed, hasFamily;
    public bool[] fence;
    public int cow, pig, sheep;
    public SeedType seedType, sowingType;
    public int seedCount;

    int[] dx = {-1,1,0,0};
    int[] dy = {0,0,-1,1};
    int[] dfence = {1,0,3,2};

    bool isUpdated = false;

    public void SetBlockMessageData(BlockData data)
    {
        this.type = data.type;
        this.hasShed = data.hasShed;
        this.fence = data.fence;
        this.cow = data.cow;
        this.pig = data.pig;
        this.sheep = data.sheep;
        this.hasFamily = data.hasFamily;
        this.seedType = data.seedType;
        this.seedCount = data.seedCount;

        isUpdated = true;
    }

    private void Update() {
        if(isUpdated)
        {
            isUpdated = false;
            SetShedUpdate();
            if(type == BlockType.FARM)
            {
                SetSeed(seedType, seedCount);
                ChangeFarm();
            }
            else if(type == BlockType.FENCE)
            {
                SetFence(fence);
                ChangeFence();
            }
            else if(type == BlockType.HOUSE)
            {
                ChangeHouse();
            }
            else if(type == BlockType.EMPTY)
            {
                ChangeEmpty();
            }
            SetAnimal(cow, pig, sheep);
        }
    }

    
    public void Init(PlayerBoard board, int row, int col, BlockType type)
    {
        this.board = board;
        this.row = row; this.col = col;
        this.type = type;
        hasShed = false;
        hasFamily = false;
        fence = new bool[4] {false,false,false,false};
        
        cow = 0; pig = 0; sheep = 0; 

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
        Debug.Log("ChangeFarm");
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
        ResourceManager.instance.addResource(board.player.id, "room", 1);

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
        backgroundParent.transform.Find("Empty").gameObject.SetActive(true);
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
        backgroundParent.transform.Find("Sowing").gameObject.SetActive(true);
        sowingType = SeedType.NONE;
        // RawImage empty = backgroundParent.transform.Find("Empty").GetComponent<RawImage>();
        // // hex : #FFFFFFF00
        // empty.color = new Color(255,255,255,0.725f);
    }

    public void CloseSowing()
    {
        backgroundParent.transform.Find("Sowing").gameObject.SetActive(false);
        sowingType = SeedType.NONE;
    }

    public void ClickWheat() {ClickSeed(SeedType.WHEAT);}
    public void ClickVegetable() {ClickSeed(SeedType.VEGETABLE);}

    public void ClickSeed(SeedType seed)
    {
        if(sowingType == seed)
        {
            ActivateSeed(sowingType, false);
        }
        else
        {
            if(sowingType != SeedType.NONE)
                ActivateSeed(sowingType, false);
            ActivateSeed(seed, true);
        }
    }

    public void ActivateSeed(SeedType type, bool isActive)
    {
        if(type == SeedType.WHEAT)
        {
            if(isActive)
            {
                backgroundParent.transform.Find("Sowing").Find("Wheat").Find("isActive").gameObject.SetActive(true);
                sowingType = SeedType.WHEAT;
                seedCount = 3;
            }
            else
            {
                backgroundParent.transform.Find("Sowing").Find("Wheat").Find("isActive").gameObject.SetActive(false);
                sowingType = SeedType.NONE;
                seedCount = 0;
            }
        }
        else if(type == SeedType.VEGETABLE)
        {
            if(isActive)
            {
                backgroundParent.transform.Find("Sowing").Find("Vegetable").Find("isActive").gameObject.SetActive(true);
                sowingType = SeedType.VEGETABLE;
                seedCount = 2;
            }
            else
            {
                backgroundParent.transform.Find("Sowing").Find("Vegetable").Find("isActive").gameObject.SetActive(false);
                sowingType = SeedType.NONE;
                seedCount = 0;
            }
        }
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
        blockData.cow = cow; blockData.pig = pig; blockData.sheep = sheep; blockData.hasFamily = hasFamily;
        blockData.seedType = seedType; blockData.seedCount = seedCount;
        return blockData;
    }

    public void SetSeed(SeedType type) 
    {
        if(type == SeedType.WHEAT)
        {
            seedType = type;
            seedCount = 3;
            ResourceManager.instance.minusResource(board.player.id, "wheat", 1);
        }
        if(type == SeedType.VEGETABLE)
        {
            seedType = type;
            seedCount = 2;
            ResourceManager.instance.minusResource(board.player.id, "vegetable", 1);
        }
        RenewSeedUI();
    }

    public void SetSeed(SeedType type, int count)
    {
        if(type == SeedType.WHEAT)
        {
            seedCount = count;
        }
        if(type == SeedType.VEGETABLE)
        {
            seedCount = count;
        }
        RenewSeedUI();
    }

    public void RenewSeedUI()
    {
        backgroundParent.transform.Find("Seed").gameObject.SetActive(true);

        if(seedType == SeedType.WHEAT)
        {
            backgroundParent.transform.Find("Seed").Find("Wheat").gameObject.SetActive(true);
            backgroundParent.transform.Find("Seed").Find("Vegetable").gameObject.SetActive(false);
            backgroundParent.transform.Find("Seed").Find("Wheat").Find("Text").GetComponent<TMP_Text>().text = seedCount.ToString();

        }
        else if(seedType == SeedType.VEGETABLE)
        {
            backgroundParent.transform.Find("Seed").Find("Wheat").gameObject.SetActive(false);
            backgroundParent.transform.Find("Seed").Find("Vegetable").gameObject.SetActive(true);
            backgroundParent.transform.Find("Seed").Find("Vegetable").Find("Text").GetComponent<TMP_Text>().text = seedCount.ToString();
        }
        else
        {
            backgroundParent.transform.Find("Seed").gameObject.SetActive(false);
        }
    }

    public void SetAnimal(int sheep, int pig, int cow) 
    {
        this.sheep = sheep; this.pig = pig; this.cow = cow;

        if(sheep > 0)
        {
            backgroundParent.transform.Find("Sheep").gameObject.SetActive(true);
            backgroundParent.transform.Find("Sheep").Find("Text").GetComponent<TMP_Text>().text = sheep.ToString();
        }
        else
        {
            backgroundParent.transform.Find("Sheep").gameObject.SetActive(false);
        }

        if(pig > 0)
        {
            backgroundParent.transform.Find("Pig").gameObject.SetActive(true);
            backgroundParent.transform.Find("Pig").Find("Text").GetComponent<TMP_Text>().text = pig.ToString();
        }
        else
        {
            backgroundParent.transform.Find("Pig").gameObject.SetActive(false);
        }

        if(cow > 0)
        {
            backgroundParent.transform.Find("Cow").gameObject.SetActive(true);
            backgroundParent.transform.Find("Cow").Find("Text").GetComponent<TMP_Text>().text = cow.ToString();
        }
        else
        {
            backgroundParent.transform.Find("Cow").gameObject.SetActive(false);
        }
    }

    public void SetShed() 
    {
        ResourceManager.instance.minusResource(board.player.id, "wood", 2);
        this.hasShed = true;
        this.transform.Find("Shed").gameObject.SetActive(true);
    }

    public void SetShedUpdate()
    {
        if(this.hasShed)
        {
           this.transform.Find("Shed").gameObject.SetActive(true);
        }
    }

    public void SetFamily()
    {
        board.familyBlocks.Add(this);
        this.hasFamily = true;
        this.transform.Find("Family").gameObject.SetActive(true);
    }

    public void UseFamily()
    {
        this.transform.Find("Family").gameObject.SetActive(false);
    }

    public void ResetFamily()
    {
        this.transform.Find("Family").gameObject.SetActive(true);
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

    public void CheckIsBlockSurroundedWithFence()
    {
        if(this.type != BlockType.EMPTY) return;
        
        if(isSurroundedWithFence()) { ChangeFence(); }
    }

    public bool isSurroundedWithFence()
    {
        bool[] isFence = new bool[4];

        int x = this.row;
        int y = this.col;

        int row = this.board.row;
        int col = this.board.col;

        for(int i = 0; i < 4; i++)
        {
            int adjBlockRow = x + dx[i];
            int adjBlockCol = y + dy[i];
            if (adjBlockRow < 0 || adjBlockRow >= row || adjBlockCol < 0 || adjBlockCol >= col) continue;
            if(board.blocks[adjBlockRow, adjBlockCol].type == BlockType.FENCE)
            {
                isFence[i] = true;
            }
        }

        if(isFence[0] && isFence[1] && isFence[2] && isFence[3])
        {
            return true;
        }        
        return false;
    }

    public bool isFourSideIsFence()
    {
        bool[] isFence = new bool[4];
        for(int i = 0; i < 4; i++) { isFence[i] = fence[i]; }

        int x = this.row;
        int y = this.col;

        int row = this.board.row;
        int col = this.board.col;

        for(int i = 0; i < 4; i++)
        {
            int adjBlockRow = x + dx[i];
            int adjBlockCol = y + dy[i];
            if (adjBlockRow < 0 || adjBlockRow >= row || adjBlockCol < 0 || adjBlockCol >= col) continue;
            if(board.blocks[adjBlockRow, adjBlockCol].fence[dfence[i]] || isFence[i] )
            {
                isFence[i] = true;
            }
        }

        if(isFence[0] && isFence[1] && isFence[2] && isFence[3])
        {
            return true;
        }        
        return false;
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
