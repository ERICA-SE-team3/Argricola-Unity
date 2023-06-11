using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager: MonoBehaviour
{
    int playerStartX = 0, offsetX = 1500;
    int playerY = 1050;
    Vector3 playerCameraOffset = new Vector3(150, -80, 0);
    List<Vector3> playerPositions = new List<Vector3>();

    public Vector3 mainBoardPosition, mainCardPosition;

    Vector3 position_camera_mainboard = new Vector3(0,0,-10);
    Vector3 position_Lobby_player = new Vector3(0, 1588, -1);
    Vector3 position_mainCard = new Vector3( 10000, 5000, -1 );
    public GameObject MainCamera;

    private void Start() {
        for(int i = 0; i < 4; i++)
        {
            playerPositions.Add(new Vector3(playerStartX + offsetX *i, playerY, -1) - playerCameraOffset);
        }

        MainCamera = Camera.main.gameObject;
    }

    public void ShowPlayer(int playerId)
    {
        MainCamera.transform.position = playerPositions[playerId];
    }

    public void ShowMainboard()
    {
        MainCamera.transform.position = position_camera_mainboard;
    }

    public void ShowLobby()
    {
        MainCamera.transform.position = position_Lobby_player;
    }

    //--------------------아래로 삭제 예정 -----------------------------
    public void ShowPlayer()
    {
        int index = GameManager.instance.localPlayerIndex;
        ShowPlayer(index);
    }
}

