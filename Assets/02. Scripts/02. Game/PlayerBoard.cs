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
    public List<SowingBlockNode> selectedSowingBlocks; 

    BoardEventStrategy strategy;

    BoardEventStrategy houseStrategy;
    BoardEventStrategy farmStrategy;
    BoardEventStrategy fenceStrategy;
    BoardEventStrategy shedStrategy;
    BoardEventStrategy sowingStrategy;
    BoardEventStrategy moveAnimalStrategy;

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

    // -------------------------------------------------------------------------

    private void Start() {
        selectedBlocks = new List<Block>();

        houseStrategy = new HouseEventStrategy();
        farmStrategy = new FarmEventStrategy();
        fenceStrategy = new FenceEventStrategy();
        shedStrategy = new ShedEventStrategy();
        sowingStrategy = new SowingEventStrategy();
        moveAnimalStrategy = new MoveAnimalEventStrategy();

        strategy = new BoardEventStrategy();

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

    //-------------------------------------------------------------------------- 

    public void StartInstallHouse()
    {
        if(isHouseInstallStartAvailable())
        {
            strategy = houseStrategy;
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
            strategy = farmStrategy;
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

    // -------------------------------------------------------------------------
    
    public void StartInstallFence()
    {
        if(IsInstallFenceStartAvailable())
        {
            strategy = fenceStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.AddListener(EndInstallFence);
        }
        else
        {
            Debug.LogError("울타리 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void EndInstallFence()
    {
        if(IsInstallFenceEndAvailable())
        {
            Debug.LogError("울타리 설치 하는 배열 생성, 해당 배열을 통해 설치");
            throw new System.NotImplementedException();
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool IsInstallFenceStartAvailable()
    {
        Debug.LogError("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    bool IsInstallFenceEndAvailable()
    {
        Debug.LogError("설치 완료 할 수 있는지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }
    
    // -------------------------------------------------------------------------

    public void StartInstallShed()
    {
        if(IsInstallShedStartAvailable())
        {
            strategy = shedStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.AddListener(EndInstallShed);
        }
        else
        {
            Debug.LogError("헛간 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void EndInstallShed()
    {
        if(IsInstallShedEndAvailable())
        {
            foreach(Block block in selectedBlocks)
            {
                block.SetShed();
            }
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool IsInstallShedStartAvailable()
    {
        Debug.LogError("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    bool IsInstallShedEndAvailable()
    {
        Debug.LogError("설치 완료 할 수 있는지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    // -------------------------------------------------------------------------

    public class SowingBlockNode
    {
        public Block block;
        public SeedType type;
    }


    public void StartSowing(GrainUtilizationRoundAct action)
    {
        StartSowing();
    }

    /// <summary>
    /// 씨 뿌리기 시작
    /// </summary>
    public void StartSowing()
    {
        if(IsSowingStartAvailable())
        {
            strategy = sowingStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.AddListener(EndSowing);
        }
        else
        {
            Debug.LogError("씨 뿌리기 행동을 시작할 수 없습니다.");
        }
    }

    /// <summary>
    /// 씨 뿌리기 마무리
    /// </summary>
    public void EndSowing()
    {
        if(IsSowingEndAvailable())
        {
            foreach(SowingBlockNode node in selectedSowingBlocks)
            {
                node.block.SetSeed(node.type);
            }

            action.EndSowingCallback();
        }
        else
        {
            Debug.LogWarning("씨 뿌릴 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool IsSowingStartAvailable()
    {
        Debug.LogError("씨뿌리기 시작 전 가능한지 검사하는 함수 " + 
                        " - 아직 구현 안됨");
        return true;
    }

    bool IsSowingEndAvailable()
    {
        Debug.LogError("씨뿌리기 완료 할 수 있는지 검사하는 함수" + 
                        "- 아직 구현 안됨");
        return true;
    }

    // -------------------------------------------------------------------------

    /// <summary>
    /// 동물 옮기기 시작
    /// </summary>
    public void StartMoveAnimal()
    {
        if(IsMoveAnimalStartAvailable())
        {
            strategy = moveAnimalStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.AddListener(EndMoveAnimal);
        }
        else
        {
            Debug.LogError("동물 옮기기 행동을 시작할 수 없습니다.");
        }
    }

    /// <summary>
    /// 동물 옮기기 마무리
    /// </summary>
    public void EndMoveAnimal()
    {
        if(IsMoveAnimalEndAvailable())
        {
            throw new System.NotImplementedException();
        }
        else
        {
            Debug.LogWarning("동물 옮길 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool IsMoveAnimalStartAvailable()
    {
        Debug.LogError("씨뿌리기 시작 전 가능한지 검사하는 함수 " + 
                        " - 아직 구현 안됨");
        return true;
    }

    bool IsMoveAnimalEndAvailable()
    {
        Debug.LogError("씨뿌리기 완료 할 수 있는지 검사하는 함수" + 
                        "- 아직 구현 안됨");
        return true;
    }


    // -------------------------------------------------------------------------

    public void _TestSetFence() { blocks[2,4]._TestSetFence(); }

    public void _TestSetShed() { blocks[2,4]._TestSetShed(); }

    public void _TestSetHouse() { blocks[2,4]._TestSetHouse(); }

    public void _TestSetFarm() { blocks[2,4]._TestSetFarm(); }

    // -------------------------------------------------------------------------

    public void OnHoverEnter(Block block) { strategy.OnHoverEnter(block); }

    public void OnHoverExit(Block block) { strategy.OnHoverExit(block); }

    public void OnClick(Block block) { strategy.OnClick(block); }

}
