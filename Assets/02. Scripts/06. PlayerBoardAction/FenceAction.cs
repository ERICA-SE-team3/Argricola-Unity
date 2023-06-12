using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class FenceAction : PlayerBoardAction
{
    Block[,] blocks;

    int[] dx = {-1,1,0,0};
    int[] dy = {0,0,-1,1};
    int[] dfence = {1,0,3,2};

    public FenceAction(PlayerBoard board) : base(board) { }

    public override bool StartInstall()
    {
        if (!IsStartInstall())
        {
            Warner.instance.LogAction("울타리 설치 행동을 시작할 수 없습니다.");
            // Debug.LogError("울타리 설치 행동을 시작할 수 없습니다.");
            return false;
        }

        board.strategy = new FenceEventStrategy();
        
        Button button = board.confirmButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => EndInstall());
        return true;
    }

    public override void EndInstall()
    {
        if (!IsEndInstall())
        {
            Debug.LogWarning("울타리 설치 행동을 종료할 수 없습니다.");
            return;
        }

        ResetBoard();
        GameManager.instance.PopQueue();
    }

    public override bool IsStartInstall()
    {
        int id = board.player.id;
        blocks = board.blocks;
        
        int wood = ResourceManager.instance.getResourceOfPlayer(id, "wood");
        if (wood == 0) return false;

        foreach (Block b in board.blocks)
        {
            if (b.type == BlockType.EMPTY)
            {
                return true;
            }
        }
        
        Debug.Log("설치 가능한 블록이 없습니다.");
        return false;
    }

    public override bool IsEndInstall()
    {
        Debug.LogError("설치 가능한지 검사하는 함수 - 아직 구현 안됨");
        return true;
    }

    public bool InstallFence()
    {
        int playerID = board.player.id;

        int playerWood = ResourceManager.instance.getResourceOfPlayer(playerID, "wood");
        List<Tuple<int,int,bool[]>> fenceList = GetFenceList();
        int woodNeed = GetNeedFenceNumber(fenceList);
    
        Debug.LogWarning("자원 계산 결과." + playerWood + " / " + woodNeed);

        if(playerWood < woodNeed) {
            Debug.LogWarning("자원이 부족합니다." + playerWood + " / " + woodNeed);
            board.selectedBlocks.Clear();
            board.GetInstallButton().SetActive(false);
            return false; 
        }

        ResourceManager.instance.minusResource(playerID, "wood", woodNeed);
        
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
        board.selectedBlocks.Clear();
    }

    public List<Tuple<int,int,bool[]>> GetFenceList()
    {
        List<Tuple<int,int,bool[]>> fenceList = new List<Tuple<int,int,bool[]>>();

        foreach(Block sb in board.selectedBlocks)
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

                if(nx < 0 || nx >= board.row || ny < 0 || ny >= board.col) continue;
                if(board.selectedBlocks.Contains(blocks[nx, ny])) {
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
            fenceList.Add(fence);
        }
        return fenceList;
    }
}
