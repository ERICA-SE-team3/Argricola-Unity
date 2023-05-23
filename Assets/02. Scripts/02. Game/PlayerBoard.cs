using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerBoard : MonoBehaviour
{
    public int row, col;

    public int house1x, house1y;
    public int house2x, house2y;

    public GameObject blockPrefab, confirmButton;
    public Player player;
    public Block[,] blocks;
    public HouseType houseType;

    public List<Block> selectedBlocks;

    BoardEventStrategy startegy;

    BoardEventStrategy houseStargety;
    BoardEventStrategy farmStargety;
    BoardEventStrategy fenceStargety;
    BoardEventStrategy shedStartegy;
    BoardEventStrategy sowingStrategy;
    BoardEventStrategy moveAnimalStrategy;

    private void Start() {
        selectedBlocks = new List<Block>();

        houseStargety = new HouseEventStrategy();
        farmStargety = new FarmEventStrategy();
        fenceStargety = new FenceEventStrategy();
        shedStartegy = new ShedEventStrategy();
        sowingStrategy = new SowingEventStrategy();
        moveAnimalStrategy = new MoveAnimalEventStrategy();

        startegy = new BoardEventStrategy();

        InitBoard(player);
        SetFirstHouse();
    }

    public void InitBoard(Player player)
    {
        blocks = new Block[row, col];
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                GameObject tmp = Instantiate(blockPrefab);
                tmp.transform.SetParent(transform);
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
    }

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

    public void StartInstallHouse()
    {
        if(isHouseInstallStartAvailable())
        {
            startegy = houseStargety;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.AddListener(EndInstallHouse);
        }
        else
        {
            Debug.LogError("집 설치 행동을 시작할 수 없습니다.");
        }
    }

    void EndInstallHouse()
    {
        if(isHouseInstallEndAvailable())
        {
            foreach(Block block in selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeHouse();
            }
            selectedBlocks.Clear();
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool isHouseInstallStartAvailable()
    {
        Debug.LogError("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    /// <summary> <summary>
    /// 플레이어 자원 등을 검사해서 유효성 검사하는 함수
    /// 집 개수도 확인해야함.
    /// 하나도 안짓는지도 확인해야함.
    /// 처음 입장할때 지을 공간이 있는지는 따로 검사해야함.
    /// </summary>
    bool isHouseInstallEndAvailable()
    {
        Debug.LogError("설치 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
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

    public void StartInstallFarm()
    {
        if(isFarmInstallStartAvailable())
        {
            startegy = farmStargety;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.AddListener(EndInstallFarm);
        }
        else
        {
            Debug.LogError("밭 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void EndInstallFarm()
    {
        if(isFarmInstallEndAvailable())
        {
            foreach(Block block in selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeFarm();
            }
            selectedBlocks.Clear();
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool isFarmInstallStartAvailable()
    {
        Debug.LogError("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    /// <summary> <summary>
    /// 플레이어 자원 등을 검사해서 유효성 검사하는 함수
    /// 하나도 안짓는지 검사해야함.
    /// 지을 공간이 있었는지는 따로 검사해야함.
    /// </summary>
    bool isFarmInstallEndAvailable()
    {
        Debug.LogError("설치 완료 할 수 있는지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    public void StartInstallFence()
    {
        startegy = fenceStargety;
    }

    public void EndInstallFence()
    {

    }

    public void StartInstallShed()
    {
        startegy = shedStartegy;
    }

    public void EndInstallShed()
    {

    }

    /// <summary>
    /// 씨 뿌리기 시작
    /// </summary>
    public void StartSowing()
    {
        startegy = sowingStrategy;
    }

    /// <summary>
    /// 씨 뿌리기 마무리
    /// </summary>
    public void EndSowing()
    {

    }

    /// <summary>
    /// 동물 옮기기 시작
    /// </summary>
    public void StartAnimalMoving()
    {
        startegy = moveAnimalStrategy;
    }

    /// <summary>
    /// 동물 옮기기 마무리
    /// </summary>
    public void EndAnimalMoving()
    {

    }

    public void _TestSetFence()
    {
        blocks[2,4]._TestSetFence();
    }

    public void _TestSetShed()
    {
        blocks[2,4]._TestSetShed();
    }

    public void _TestSetHouse()
    {
        blocks[2,4]._TestSetHouse();
    }

    public void _TestSetFarm()
    {
        blocks[2,4]._TestSetFarm();
    }

    public void OnHoverEnter(Block block)
    {
        startegy.OnHoverEnter(block);
    }

    public void OnHoverExit(Block block)
    {
        startegy.OnHoverExit(block);
    }

    public void OnClick(Block block)
    {
        startegy.OnClick(block);
    }

}
