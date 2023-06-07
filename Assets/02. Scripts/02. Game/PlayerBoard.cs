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

    int[] dx = {-1,1,0,0};
    int[] dy = {0,0,-1,1};   

    public GameObject blockPrefab, confirmButton;
    public Player player;
    public Block[,] blocks;
    public HouseType houseType;

    public List<Block> selectedBlocks;


    BoardEventStrategy strategy;
    BoardEventStrategy houseStrategy, farmStrategy, fenceStrategy, shedStrategy, sowingStrategy, moveAnimalStrategy;


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

    public void Start() {
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
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(EndInstallHouse);
        }
        else
        {
            Debug.LogWarning("집 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void EndInstallHouse()
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

    /// <summary>
    /// 플레이어의 최소 자원 등을 검사해서 유효성 검사하는 함수
    /// 집 개수도 확인해야함.
    /// 처음 입장할때 지을 공간이 있는지는 따로 검사해야함.
    /// </summary>
    /// <returns></returns>
    bool isHouseInstallStartAvailable()
    {
        Debug.LogWarning("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    /// <summary> <summary>
    /// 플레이어 자원 등을 검사해서 유효성 검사하는 함수
    /// 집 개수도 확인해야함.
    /// 하나도 안짓는지도 확인해야함.
    /// </summary>
    bool isHouseInstallEndAvailable()
    {
        Debug.LogWarning("설치 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    // -------------------------------------------------------------------------

    
    public void StartUpgradeHouse()
    {
        if(isHouseUpgradeStartAvailable())
        {
            strategy = houseStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(EndUpgradeHouse);
        }
        else
        {
            Debug.LogWarning("집 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void EndUpgradeHouse()
    {
        if(isHouseUpgradeEndAvailable())
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

    /// <summary>
    /// 플레이어의 최소 자원 등을 검사해서 유효성 검사하는 함수
    /// 집 개수도 확인해야함.
    /// 처음 입장할때 지을 공간이 있는지는 따로 검사해야함.
    /// </summary>
    /// <returns></returns>
    bool isHouseUpgradeStartAvailable()
    {
        Debug.LogWarning("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    /// <summary> <summary>
    /// 플레이어 자원 등을 검사해서 유효성 검사하는 함수
    /// 집 개수도 확인해야함.
    /// 하나도 안짓는지도 확인해야함.
    /// </summary>
    bool isHouseUpgradeEndAvailable()
    {
        Debug.LogWarning("설치 가능한지 검사하는 함수 - 아직 구현 안됨");
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
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(EndInstallFarm);
        }
        else
        {
            Debug.LogWarning("밭 설치 행동을 시작할 수 없습니다.");
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
        Debug.LogWarning("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    /// <summary> <summary>
    /// 플레이어 자원 등을 검사해서 유효성 검사하는 함수
    /// 하나도 안짓는지 검사해야함.
    /// 지을 공간이 있었는지는 따로 검사해야함.
    /// </summary>
    bool isFarmInstallEndAvailable()
    {
        Debug.LogWarning("설치 완료 할 수 있는지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    // -------------------------------------------------------------------------
    
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

    public void StartInstallFence()
    {
        if(IsInstallFenceStartAvailable())
        {
            strategy = fenceStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(EndInstallFence);
        }
        else
        {
            Debug.LogWarning("울타리 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void EndInstallFence()
    {
        if(IsInstallFenceEndAvailable())
        {
            InstallFence();
        }
        else
        {
            Debug.LogError("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool IsInstallFenceStartAvailable()
    {
        Debug.LogWarning("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        // 나무 개수 확인
        // 울타리 지을 수 있는 영역 확인
        // 등등..
        return true;
    }

    bool IsInstallFenceEndAvailable()
    {
        foreach(Block block in selectedBlocks)
        {
            if(block.type == BlockType.FARM)
            {
                Debug.LogWarning("밭에는 울타리를 설치할 수 없습니다.");
                return false;
            }
            if(block.type == BlockType.HOUSE)
            {
                Debug.LogWarning("집에는 울타리를 설치할 수 없습니다.");
                return false;
            }
        }
        Debug.LogWarning("설치 완료 할 수 있는지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    void InstallFence()
    {
        Debug.LogWarning("울타리 설치 하는 배열 생성, 해당 배열을 통해 설치");
        for (int j=0;j<selectedBlocks.Count;j++)
        {
            if(selectedBlocks[j].type == BlockType.FENCE)
            {
                ReInstallFence(selectedBlocks[j]);
                selectedBlocks[j].ShowTransparent();
                continue;
            }

            var block = selectedBlocks[j];
            bool[] fence = new bool[4];
            
            for (int i=0;i<4;i++) {
                fence[i] = true;
            }

            for (int i=0;i<selectedBlocks.Count;i++) {
                if (i!=j) {
                    var otherBlock = selectedBlocks[i];
                    int gapRow = otherBlock.row - block.row;
                    int gapCol = otherBlock.col - block.col;
                    for (int k=0;k<4;k++) {
                        if (dx[k] == gapRow && dy[k] == gapCol) {
                            fence[k] = false;
                        }
                    }
                }
            }
            
            for (int i=0;i<4;i++) {
                if (!fence[i]) continue;
                int adjBlockRow = block.row + dx[i];
                int adjBlockCol = block.col + dy[i];
                if (adjBlockRow < 0 || adjBlockRow >= this.row || adjBlockCol < 0 || adjBlockCol >= this.col) continue;
                if (blocks[adjBlockRow,adjBlockCol].type == BlockType.FENCE) {
                        fence[i] = false;
                }
            }

            block.SetFence(fence);
            block.ChangeFence();
        }
        selectedBlocks.Clear();
    }

    void ReInstallFence(Block block)
    {
        int[] adjFenceIndex = {1,0,3,2};
        bool[] fence = new bool[4];
        for (int i=0;i<4;i++) {
            fence[i] = block.fence[i];
        }
        for (int i=0;i<4;i++) {
            int adjBlockRow = block.row + dx[i];
            int adjBlockCol = block.col + dy[i];
            if (adjBlockRow < 0 || adjBlockRow >= this.row || adjBlockCol < 0 || adjBlockCol >= this.col) continue;
            if (blocks[adjBlockRow,adjBlockCol].fence[adjFenceIndex[i]] == false) {
                fence[i] = true;
            }
        }
        block.SetFence(fence);
        block.ChangeFence();
    }
    
    // -------------------------------------------------------------------------

    public void StartInstallShed()
    {
        if(IsInstallShedStartAvailable())
        {
            strategy = shedStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(EndInstallShed);
        }
        else
        {
            Debug.LogWarning("헛간 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void EndInstallShed()
    {
        if(IsInstallShedEndAvailable())
        {
            foreach(Block block in selectedBlocks)
            {
                block.SetShed();
                block.ShowTransparent();
            }
            selectedBlocks.Clear();
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool IsInstallShedStartAvailable()
    {
        Debug.LogWarning("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    bool IsInstallShedEndAvailable()
    {
        Debug.LogWarning("설치 완료 할 수 있는지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    // -------------------------------------------------------------------------

    public class SowingBlockNode
    {
        public Block block;
        public SeedType type;
    }

    void SetFarmBlockToSow()
    {
        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                if(blocks[i,j].type == BlockType.FARM && blocks[i,j].seedType == SeedType.NONE)
                {
                    blocks[i,j].ShowSowing();
                }
            }
        }
    }

    /// <summary>
    /// 씨 뿌리기 시작
    /// </summary>
    public void StartSowing()
    {
        if(IsSowingStartAvailable())
        {
            SetFarmBlockToSow();
            strategy = sowingStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(EndSowing);
        }
        else
        {
            Debug.LogWarning("씨 뿌리기 행동을 시작할 수 없습니다.");
        }
    }

    /// <summary>
    /// 씨 뿌리기 마무리
    /// </summary>
    public void EndSowing()
    {
        if(IsSowingEndAvailable())
        {
            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    if(blocks[i,j].sowingType != SeedType.NONE)
                    {
                        blocks[i,j].SetSeed(blocks[i,j].sowingType);
                    }

                    blocks[i,j].CloseSowing();
                }
            }

            // action.EndSowingCallback();
        }
        else
        {
            Debug.LogWarning("씨 뿌릴 수 없습니다. 다시 선택해주세요.");
        }
    }

    bool IsSowingStartAvailable()
    {
        Debug.LogWarning("씨뿌리기 시작 전 가능한지 검사하는 함수 " + 
                        " - 아직 구현 안됨");
        return true;
    }

    bool IsSowingEndAvailable()
    {
        Debug.LogWarning("씨뿌리기 완료 할 수 있는지 검사하는 함수" + 
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
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(EndMoveAnimal);
        }
        else
        {
            Debug.LogWarning("동물 옮기기 행동을 시작할 수 없습니다.");
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
        Debug.LogWarning("동물 옮기기 시작 전 가능한지 검사하는 함수 " + 
                        " - 아직 구현 안됨");
        return true;
    }

    bool IsMoveAnimalEndAvailable()
    {
        Debug.LogWarning("동물 옮기기 완료 할 수 있는지 검사하는 함수" + 
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
