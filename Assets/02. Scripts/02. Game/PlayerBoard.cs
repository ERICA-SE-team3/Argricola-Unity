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

    public GameObject blockPrefab;
    public Player player;
    public Block[,] blocks;
    public HouseType houseType;

    BoardEventStrategy startegy;

    BoardEventStrategy houseStargety;
    BoardEventStrategy farmStargety;
    BoardEventStrategy fenceStargety;
    BoardEventStrategy shedStartegy;
    BoardEventStrategy sowingStrategy;
    BoardEventStrategy moveAnimalStrategy;

    private void Start() {
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
        boardMessageData.blockDatas = new BlockData[blocks.GetLength(0) * blocks.GetLength(1)];
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

    public bool IsFarmAvailable(Block block)
    {
        throw new System.NotImplementedException();
    }

    public bool IsFenceAvailable(List<Block> blocks)
    {
        throw new System.NotImplementedException();
    }

    public static void IsHouseAvailable(int row, int col)
    {
        throw new System.NotImplementedException();
    }

    public bool isShedAvilable(Block block)
    {
        throw new System.NotImplementedException();
    }

    public void StartInstallHouse()
    {
        startegy = houseStargety;
        SetBlockEvents();
    }


    public void EndInstallHouse()
    {

    }

    public void StartInstallFarm()
    {
        startegy = farmStargety;
        SetBlockEvents();
    }

    public void EndInstallFarm()
    {

    }

    public void StartInstallFence()
    {
        startegy = fenceStargety;
        SetBlockEvents();
    }

    public void EndInstallFence()
    {

    }

    public void StartInstallShed()
    {
        startegy = shedStartegy;
        SetBlockEvents();
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
        SetBlockEvents();
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
        SetBlockEvents();
    }

    /// <summary>
    /// 동물 옮기기 마무리
    /// </summary>
    public void EndAnimalMoving()
    {

    }

    void SetBlockEvents()
    {
         for(int i = 0; i < blocks.GetLength(0); i++)
        {
            for(int j = 0; j < blocks.GetLength(1); j++)
            {
                EventTrigger trigger = blocks[i,j].transform.GetComponent<EventTrigger>();

                EventTrigger.Entry hoverEnterEntry = new EventTrigger.Entry();
                hoverEnterEntry.eventID = EventTriggerType.PointerEnter;
                hoverEnterEntry.callback.AddListener( (eventData) => { HoverEnter((PointerEventData)eventData); } );
                trigger.triggers.Add(hoverEnterEntry);

                EventTrigger.Entry hoverExitEntry = new EventTrigger.Entry();
                hoverExitEntry.eventID = EventTriggerType.PointerExit;
                hoverExitEntry.callback.AddListener( (eventData) => { HoverExit((PointerEventData)eventData); } );
                trigger.triggers.Add(hoverExitEntry);

                EventTrigger.Entry ClickEntry = new EventTrigger.Entry();
                ClickEntry.eventID = EventTriggerType.PointerDown;
                ClickEntry.callback.AddListener( (eventData) => { OnClick((PointerEventData)eventData); } );
                trigger.triggers.Add(ClickEntry);
            }
        }
    }

    void HoverEnter(PointerEventData eventData)
    {
        startegy.HoverEnter(eventData);
    }

    void HoverExit(PointerEventData eventData)
    {
        startegy.HoverExit(eventData);
    }

    void OnClick(PointerEventData eventData)
    {
        startegy.OnClick(eventData);
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
}
