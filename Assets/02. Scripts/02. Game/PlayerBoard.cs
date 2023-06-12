using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerBoard : MonoBehaviour
{
    public int row = 3, col = 5;

    public int house1x = 1, house1y = 0;
    public int house2x = 2, house2y = 0;

    public GameObject blockPrefab, confirmButton;
    
    GameObject BoardGrid, InstallButton;

    public Player player;
    public Block[,] blocks;
    public HouseType houseType;

    public int leftSheep, leftPig, leftCow;
    public Block PetHouseBlock;

    public List<Block> selectedBlocks;


    public BoardEventStrategy strategy;
    BoardEventStrategy sowingStrategy, moveAnimalStrategy;

    public PlayerBoardAction action;
    public PlayerBoardAction houseAction, farmAction, shedAction, sowingAction, moveAnimalAction;
    public FenceAction fenceAction;
    public List<Block> familyBlocks;

    public PlayerBoardMessageData GetBoardMessageData()
    {
        PlayerBoardMessageData boardMessageData = new PlayerBoardMessageData();

        boardMessageData.blockDatas = new BlockData[blocks.GetLength(0) 
                                                    * blocks.GetLength(1)];
        int index = 0;
        for(int row = 0; row < blocks.GetLength(0); row++)
        {
            for(int col = 0; col < blocks.GetLength(1); col++)
            {
                boardMessageData.blockDatas[index] = blocks[row,col].GetBlockData();
                index++;
            }
        }
        return boardMessageData;
    }

    public void SetBoardMessageData(PlayerBoardMessageData data)
    {
        for(int i = 0; i < data.blockDatas.Length; i++)
        {
            BlockData blockData = data.blockDatas[i];
            blocks[blockData.row, blockData.col].SetBlockMessageData(blockData);
        }
    }

    // -------------------------------------------------------------------------

    public void Start() {
        selectedBlocks = new List<Block>();

        sowingStrategy = new SowingEventStrategy();
        moveAnimalStrategy = new MoveAnimalEventStrategy();

        houseAction = new HouseAction(this);
        farmAction = new FarmAction(this);
        fenceAction = new FenceAction(this);
        shedAction = new ShedAction(this);
        sowingAction = new SowingAction(this);
        moveAnimalAction = new MoveAnimalAction(this);

        strategy = new BoardEventStrategy();
        action = new PlayerBoardAction(this);
        
        familyBlocks = new List<Block>();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;

        InitBoard(player);
        SetFirstHouse();
    }

    public void InitBoard(Player player)
    {
        BoardGrid = transform.Find("BoardGrid").gameObject;
        InstallButton = transform.Find("InstallButton").gameObject;

        blocks = new Block[row, col];
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                GameObject tmp = Instantiate(blockPrefab);
                tmp.transform.SetParent(BoardGrid.transform);
                tmp.transform.localScale = Vector3.one;
                Block tmpBlock = tmp.GetComponent<Block>();
                tmpBlock.Init(this, i, j, BlockType.EMPTY);
                blocks[i,j] = tmpBlock;
            }
        }
        houseType = HouseType.WOOD;
    }
    
    void SetFirstHouse()
    {
        blocks[house1x, house1y].ChangeHouse();
        blocks[house2x, house2y].ChangeHouse();
        blocks[house1x, house1y].SetFamily();
        blocks[house2x, house2y].SetFamily();
    }

    public GameObject GetInstallButton()
    {
        return InstallButton;
    }

    public void ShowAnimalModal(Block block)
    {
        transform.Find("MoveAnimalModal").gameObject.SetActive(true);
        transform.Find("MoveAnimalModal").GetComponent<AnimalModalManager>().SetModal(block);
    }

    public void UseFamily()
    {
        if(familyBlocks.Count > 0)
        {
            familyBlocks[0].UseFamily();
            familyBlocks.RemoveAt(0);
        }
        else
        {
            Debug.LogWarning("가족이 없습니다.");
        }
    }

    public void ResetFamily()
    {
        familyBlocks.Clear();
        foreach(Block block in blocks)
        {
            if(block.hasFamily)
            {
                block.ResetFamily();
                familyBlocks.Add(block);
            }
        }
    }

    public void AddFamily()
    {
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.HOUSE && !block.hasFamily)
            {
                block.SetFamily();
                familyBlocks.Add(block);
            }
        }
        if(familyBlocks.Count < player.family)
        {
            // 급한 가족 늘리기 함수.
            Debug.LogWarning("급한 가족 늘리기 - 미구현");
        }
    }

    //-------------------------------------------------------------------------- 
    public bool StartInstallHouse()
    {
        action = houseAction;
        bool result = action.StartInstall();

        return result;
    }
    // -------------------------------------------------------------------------
    public void StartUpgradeHouse()
    {
        action = new UpgradeHouseAction(this);
        action.StartInstall();
        GameManager.instance.PopQueue();
    }
    // -------------------------------------------------------------------------
    public bool isFarmInBoard()
    {
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.FARM)
            {
                return true;
            }
        }
        return false;
    }

    public bool StartInstallFarm()
    {
        action = farmAction;
        bool result = action.StartInstall();

        return result;
    }
    // -------------------------------------------------------------------------
    public bool StartInstallFence()
    {
        action = fenceAction;
        bool result = action.StartInstall();

        return result;
    }

    public bool InstallFence()
    {
        return fenceAction.InstallFence();
    }

    public bool IsFenceInBoard()
    {
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.FENCE)
            {
                return true;
            }
        }
        return false;
    }
    // -------------------------------------------------------------------------
    public bool StartInstallShed()
    {
        action = shedAction;

        bool result = action.StartInstall();
        return result;
    }
    // -------------------------------------------------------------------------
    /// <summary>
    /// 씨 뿌리기 시작
    /// </summary>
    public bool StartSowing()
    {
        action = sowingAction;
        bool result = action.StartInstall();

        return result;
    }

    public void Cultivate()
    {
        foreach (var block in blocks)
        {
            if (block.type == BlockType.FARM && block.seedType != SeedType.NONE)
            {
                block.seedCount -= 1;
                ResourceManager.instance.addResource(player.id, block.seedType.ToString().ToLower(), 1);
                if(block.seedCount == 0)
                {
                    block.seedType = SeedType.NONE;
                }
                block.RenewSeedUI();
            }
        }
    }
    // -------------------------------------------------------------------------
    /// <summary>
    /// 동물 옮기기 시작
    /// </summary>
    public bool StartMoveAnimal()
    {
        action = moveAnimalAction;
        bool result = action.StartInstall();

        return result;
    }

    public void Breeding()
    {
        int cow = player.cow;
        int sheep = player.sheep;
        int pig = player.pig;

        if(sheep > 2)
        {
            ResourceManager.instance.addResource(player.id, "sheep", 1);
            foreach(Block b in blocks)
            {
                if(b.sheep > 0 && AnimalModalManager.CalculateMaxAnimal(b) >= b.sheep + 1)
                {
                    b.SetAnimal(b.sheep + 1, b.pig, b.cow);
                    break;
                }
            }
        }

        if(pig > 2)
        {
            ResourceManager.instance.addResource(player.id, "pig", 1);
            foreach(Block b in blocks)
            {
                if(b.pig > 0 && AnimalModalManager.CalculateMaxAnimal(b) >= b.pig + 1)
                {
                    b.SetAnimal(b.sheep, b.pig + 1, b.cow);
                    break;
                }
            }
        }

        if(cow > 2)
        {
            ResourceManager.instance.addResource(player.id, "cow", 1);
            foreach(Block b in blocks)
            {
                if(b.cow > 0 && AnimalModalManager.CalculateMaxAnimal(b) >= b.cow + 1)
                {
                    b.SetAnimal(b.sheep, b.pig, b.cow + 1);
                    break;
                }
            }
        }
    }

    public void Feeding()
    {
        ResourceManager.instance.minusResource(player.id, "food", player.family * 2 + player.baby);
    }


    // -------------------------------------------------------------------------
    public void _TestSetFence() { blocks[2,4]._TestSetFence(); }

    public void _TestSetShed() { blocks[2,4]._TestSetShed(); }

    public void _TestSetHouse() { blocks[2,4]._TestSetHouse(); }

    public void _TestSetFarm() { blocks[2,4]._TestSetFarm(); }

    public void _SetPlayer() { 
        SetPlayer(GameManager.instance.players[0]); 
        ResourceManager.instance.addResource(player.id, "wood", 30);
        ResourceManager.instance.addResource(player.id, "clay", 10);
        ResourceManager.instance.addResource(player.id, "stone", 10);
        ResourceManager.instance.addResource(player.id, "reed", 10);

        // ! 테스팅용 코드
        leftSheep = 3;
        leftPig = 2;
        leftCow = 1;

        ResourceManager.instance.addResource(player.id,"sheep", 3);
        ResourceManager.instance.addResource(player.id,"pig", 2);
        ResourceManager.instance.addResource(player.id,"cow", 1);
        
        AnimalModalManager.leftSheep = this.leftSheep;
        AnimalModalManager.leftPig = this.leftPig;
        AnimalModalManager.leftCow = this.leftCow;
    }

    // -------------------------------------------------------------------------

    public void OnHoverEnter(Block block) { strategy.OnHoverEnter(block); }

    public void OnHoverExit(Block block) { strategy.OnHoverExit(block); }

    public void OnClick(Block block) { strategy.OnClick(block); }

}
