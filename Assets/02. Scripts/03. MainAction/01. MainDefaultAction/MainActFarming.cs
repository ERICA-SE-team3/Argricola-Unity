using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActFarming : MonoBehaviour
{
    
    //===============================================
    public void _OnClick() {
        //농지
        GameManager.instance.playerBoards[ GameManager.instance.getCurrentPlayerId() ].TestStartInstallFarm();

        //
    }
}
