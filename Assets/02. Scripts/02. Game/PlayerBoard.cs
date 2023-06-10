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
    int[] dfence = {1,0,3,2};

    public GameObject blockPrefab, confirmButton;
    
    GameObject BoardGrid, InstallButton;

    public Player player;
    public Block[,] blocks;
    public HouseType houseType;

    public int leftSheep, leftPig, leftCow;
    public Block PetHouseBlock;

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

        // InitBoard(player);
        // SetFirstHouse();
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
                ResourceManager.instance.minusResource(player.id, houseType.ToString().ToLower(), 5);
                ResourceManager.instance.minusResource(player.id, "reed", 2);
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
        if(player.room >= Player.MAXROOM)
        {
            Debug.LogWarning("더이상 집을 지을 수 없습니다.");
            return false;
        }

        int playerReed, playerWood, playerClay, playerStone;
        playerReed = ResourceManager.instance.getResourceOfPlayer(player.id, "reed");
        playerWood = ResourceManager.instance.getResourceOfPlayer(player.id, "wood");
        playerClay = ResourceManager.instance.getResourceOfPlayer(player.id, "clay");
        playerStone = ResourceManager.instance.getResourceOfPlayer(player.id, "stone");

        if(playerReed < 2)
        {
            Debug.LogWarning("갈대가 부족합니다.");
            return false;
        }

        switch(houseType)
        {
            case HouseType.WOOD:
                if(playerWood < 5)
                {
                    Debug.LogWarning("목재가 부족합니다.");
                    return false;
                }
                break;
            case HouseType.CLAY:
                if(playerClay < 5)
                {
                    Debug.LogWarning("점토가 부족합니다.");
                    return false;
                }
                break;
            case HouseType.STONE:
                if(playerStone < 5)
                {
                    Debug.LogWarning("돌이 부족합니다.");
                    return false;
                }
                break;
        }

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
        strategy = new BoardEventStrategy();
        if(isHouseUpgradeStartAvailable()) {
            houseType += 1; 
            UpgradeHouse(); 
        }
        GameManager.instance.PopQueue();
    }

    /// <summary>
    /// 플레이어의 최소 자원 등을 검사해서 유효성 검사하는 함수
    /// </summary>
    public bool isHouseUpgradeStartAvailable()
    {
        if(houseType == HouseType.STONE) { 
            Debug.LogWarning("더이상 집을 업그레이드 할 수 없습니다.");
            return false; 
        }
        
        int houseNumber = 0;
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.HOUSE) { houseNumber++; }
        }

        int playerReed, playerWood, playerClay, playerStone;
        switch(houseType)
        {
            case HouseType.WOOD:
                playerWood = ResourceManager.instance.getResourceOfPlayer(player.id, "wood");
                playerReed = ResourceManager.instance.getResourceOfPlayer(player.id, "reed");

                if(playerWood < 5 * houseNumber || playerReed < 2 * houseNumber) {
                    Debug.LogWarning("자원이 부족합니다.");
                    return false; 
                }
                break;

            case HouseType.CLAY:
                playerClay = ResourceManager.instance.getResourceOfPlayer(player.id, "clay");
                playerReed = ResourceManager.instance.getResourceOfPlayer(player.id, "reed");

                if(playerClay < 5 * houseNumber || playerReed < 2 * houseNumber) {
                    Debug.LogWarning("자원이 부족합니다.");
                    return false; 
                }
                break;

            case HouseType.STONE:
                playerStone = ResourceManager.instance.getResourceOfPlayer(player.id, "stone");
                playerReed = ResourceManager.instance.getResourceOfPlayer(player.id, "reed");

                if(playerStone < 5 * houseNumber || playerReed < 2 * houseNumber) {
                    Debug.LogWarning("자원이 부족합니다.");
                    return false; 
                }
                break;
        }
        return true;
    }

    void UpgradeHouse()
    {
        Debug.Log("HouseType:" + houseType);
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.HOUSE) {
                block.ChangeHouse(); 
                ResourceManager.instance.minusResource(player.id, houseType.ToString().ToLower(), 5);
                ResourceManager.instance.minusResource(player.id, "reed", 2);
            }
        }
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
            strategy = new BoardEventStrategy();
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
        GameManager.instance.PopQueue(); 
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
        if(isFenceActionEndAvailable())
        {
            strategy = new BoardEventStrategy();
            // InstallFence();
        }
        else
        {
            Debug.LogError("설치할 수 없습니다. 다시 선택해주세요.");
        }
        GameManager.instance.PopQueue();
    }

    bool IsInstallFenceStartAvailable()
    {
        Debug.LogWarning("설치 시작 전 가능한지 검사하는 함수 - 아직 구현 안됨");
        // 나무 개수 확인
        // 울타리 지을 수 있는 영역 확인
        // 등등..
        return true;
    }

    bool isFenceActionEndAvailable()
    {
        if(selectedBlocks.Count != 0) {
            Debug.LogWarning("울타리 설치를 완료해주세요.");
            return false; 
        }

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

    public bool InstallFence()
    {
        int playerWood = ResourceManager.instance.getResourceOfPlayer(player.id, "wood");
        List<Tuple<int,int,bool[]>> fenceList = GetFenceList();
        int woodNeed = GetNeedFenceNumber(fenceList);
    
        Debug.LogWarning("자원 계산 결과." + playerWood + " / " + woodNeed);

        if(playerWood < woodNeed) {
            Debug.LogWarning("자원이 부족합니다." + playerWood + " / " + woodNeed);
            selectedBlocks.Clear();
            InstallButton.SetActive(false);
            return false; 
        }

        ResourceManager.instance.minusResource(player.id, "wood", woodNeed);
        
        SetFence(fenceList);

        foreach(Block block in blocks)
        {
            block.CheckIsBlockSurroundedWithFence();
        }
        return true;
    }

    int GetNeedFenceNumber(List<Tuple<int,int,bool[]>> fenceList)
    {
        int woodCount = 0;
        foreach (Tuple<int,int,bool[]> fence in fenceList) {
            for (int i=0;i<4;i++) {
                if (fence.Item3[i]) woodCount++;
            }
        }
        return woodCount;
    }

    void SetFence(List<Tuple<int,int,bool[]>> fenceList)
    {
        foreach(Tuple<int,int,bool[]> fence in fenceList)
        {
            Block block = blocks[fence.Item1, fence.Item2];
            bool[] fenceArray = fence.Item3;
            for(int i = 0; i < 4; i++)
            {
                if(block.fence[i])
                    { fenceArray[i] = true; }
            }
            block.SetFence(fenceArray);
            block.ChangeFence();

            block.ShowTransparent();
        }
        selectedBlocks.Clear();
    }

    public List<Tuple<int,int,bool[]>> GetFenceList()
    {
        List<Tuple<int,int,bool[]>> fenceList = new List<Tuple<int,int,bool[]>>();

        foreach(Block sb in selectedBlocks)
        {
            Tuple<int,int,bool[]> fence = new Tuple<int,int,bool[]>(sb.row, sb.col, new bool[4]);
            for(int i = 0; i < 4; i++) 
            {
                fence.Item3[i] = true;
            }

            for(int i = 0; i < 4; i++)
            {
                if(sb.type == BlockType.FENCE && sb.fence[i])
                {
                    fence.Item3[i] = false;
                    continue;
                } 

                int nx = sb.row + dx[i];
                int ny = sb.col + dy[i];

                if(nx < 0 || nx >= this.row || ny < 0 || ny >= this.col) continue;
                if(selectedBlocks.Contains(blocks[nx, ny])) {
                    fence.Item3[i] = false;
                    continue; 
                }
                if(blocks[nx, ny].type == BlockType.EMPTY)
                {
                    fence.Item3[i] = true;
                    continue;
                }
                if(blocks[nx, ny].type == BlockType.FENCE && blocks[nx,ny].fence[dfence[i]]) 
                    fence.Item3[i] = false;
            }
            Debug.Log(fence.Item3);
            fenceList.Add(fence);
        }
        return fenceList;
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
            
            selectedBlocks.Clear();
            strategy = new BoardEventStrategy();
            // action.EndSowingCallback();
        }
        else
        {
            Debug.LogWarning("씨 뿌릴 수 없습니다. 다시 선택해주세요.");
        }
        GameManager.instance.PopQueue();
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

    public void TestStartInstallHouse()
    {
        if(isHouseInstallStartAvailable())
        {
            Debug.Log( "Let's start to make House!" );
            strategy = houseStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(TestEndInstallHouse);

            GameManager.instance.actionFlag = true;
        }
        else
        {
            Debug.LogWarning("집 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void TestEndInstallHouse()
    {
        if(isHouseInstallEndAvailable())
        {
            foreach(Block block in selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeHouse();
            }
            selectedBlocks.Clear();

            GameManager.instance.actionFlag = false;
            GameManager.instance.endTurnFlag = true;

            Debug.Log( "Making Home is Finish!" );
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }
    
    public void TestStartUpgradeHouse()
    {
        strategy = new BoardEventStrategy();
        if(isHouseUpgradeStartAvailable()) {
            houseType += 1; 

            Debug.Log( "Let's Upgrade Houses!!" );
            GameManager.instance.actionFlag = true;

            TestUpgradeHouse(); 
        }
    }

    void TestUpgradeHouse()
    {
        Debug.Log("HouseType:" + houseType);
        foreach(Block block in blocks)
        {
            if(block.type == BlockType.HOUSE) { block.ChangeHouse(); }
        }

        GameManager.instance.actionFlag = false;
        GameManager.instance.endTurnFlag = true;

        Debug.Log( "Upgrading Home is Finish!" );
    }

    public void TestStartInstallFarm()
    {
        if(isFarmInstallStartAvailable())
        {
            strategy = farmStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(TestEndInstallFarm);

            Debug.Log( "Let's start to make Farm!" );
            GameManager.instance.actionFlag = true;
        }
        else
        {
            Debug.LogWarning("밭 설치 행동을 시작할 수 없습니다.");
        }
    }

    public void TestEndInstallFarm()
    {
        if(isFarmInstallEndAvailable())
        {
            foreach(Block block in selectedBlocks)
            {
                block.ShowTransparent();
                block.ChangeFarm();
            }
            selectedBlocks.Clear();

            GameManager.instance.actionFlag = false;
            GameManager.instance.endTurnFlag = true;

            Debug.Log( "Making Farm is Finish!" );
        }
        else
        {
            Debug.LogWarning("설치할 수 없습니다. 다시 선택해주세요.");
        }
    }
    
    public void TestStartSowing()
    {
        if(IsSowingStartAvailable())
        {
            SetFarmBlockToSow();
            strategy = sowingStrategy;
            Button button = confirmButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(TestEndSowing);

            Debug.Log( "Let's start to sowing!" );
            GameManager.instance.actionFlag = true;

        }
        else
        {
            Debug.LogWarning("씨 뿌리기 행동을 시작할 수 없습니다.");
        }
    }

    /// <summary>
    /// 씨 뿌리기 마무리
    /// </summary>
    public void TestEndSowing()
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

            Debug.Log( "Sowing is Finish!" );

            // action.EndSowingCallback();
            GameManager.instance.actionFlag = false;
            GameManager.instance.endTurnFlag = true;

        }
        else
        {
            Debug.LogWarning("씨 뿌릴 수 없습니다. 다시 선택해주세요.");
        }
    }



    // -------------------------------------------------------------------------

    public void OnHoverEnter(Block block) { strategy.OnHoverEnter(block); }

    public void OnHoverExit(Block block) { strategy.OnHoverExit(block); }

    public void OnClick(Block block) { strategy.OnClick(block); }

}
