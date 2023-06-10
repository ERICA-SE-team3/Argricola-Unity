using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager: MonoBehaviour
{
    Vector3 position_camera_mainboard = new Vector3(66, 0, -1);
    Vector3 position_camera_player1 = new Vector3(0, 4000, -1);
    Vector3 position_camera_player2 = new Vector3(4000, 0, -1);
    Vector3 position_camera_player3 = new Vector3(0, -4000, -1);
    Vector3 position_camera_player4 = new Vector3(-4000, 0, -1);
    Vector3 position_Lobby_player = new Vector3(0, 1588, -1);
    Vector3 position_mainCard = new Vector3( 10000, 5000, -1 );
    public GameObject MainCamera;

    public void Show_Player1()
    {
        MainCamera.transform.position = position_camera_player1;
        Debug.Log(MainCamera.transform.position);
    }

    public void Show_Player2()
    {
        MainCamera.transform.position = position_camera_player2;
        Debug.Log(MainCamera.transform.position);
    }

    public void Show_Player3()
    {
        MainCamera.transform.position = position_camera_player3;
        Debug.Log(MainCamera.transform.position);
    }

    public void Show_Player4()
    {
        MainCamera.transform.position = position_camera_player4;
        Debug.Log(MainCamera.transform.position);
    }

    public void Show_Mainboard()
    {
        MainCamera.transform.position = position_camera_mainboard;
        Debug.Log(MainCamera.transform.position);
    }

    public void Show_Lobby()
    {
        MainCamera.transform.position = position_Lobby_player;
        Debug.Log(MainCamera.transform.position);
    }

}

