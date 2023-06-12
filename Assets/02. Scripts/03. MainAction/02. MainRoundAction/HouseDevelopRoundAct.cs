using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseDevelopRoundAct : ButtonParents
{
  /* 집 개조 행동 (집 개조 이후 주요설비 or 보조설비 )
    1. 해당 행동 Onclick
    2. 사용자의 집 정보 가져오기 ( 종류, 방 개수 )
    3. 종류와 개수에 알맞게 자원소모     ex. 나무집 방 2개 -> 갈대 1개 + 흙 2개 소모
    4. 주요설비 또는 보조설비 하나 고르기
  */

    public GameObject cardMain;
    GameObject[] buttonArray = new GameObject[10];

    public int playerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[22]==false)
        {
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.HOUSE_RENOVATION_END;
            GameManager.instance.SendMessage(ActionType.HOUSE_RENOVATION);
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[22] = true;
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1); 

            GameManager.instance.actionQueue.Enqueue("hdHouseDevelop");
            
            // //한 후에, 주요설비 및 보조설비 구매 <-- 미구현
            GameManager.instance.actionQueue.Enqueue( "hdImprovements" );


            GameManager.instance.PopQueue();
            // 집개조 이후, 주요설비 및 보조설비 카드펴짐 -> 카드 하나 고르기 함수 호출
        }
    }

    public void StartHouseDeveloping() {
        GameManager.instance.playerBoards[playerIndex].StartUpgradeHouse();
    }
    public void ImprovementsStart() {
        //메인카드 구매하는 창 on

        //OnCLick1~10까지 script 가져오기
        MainFacilBuy mb = cardMain.GetComponent<MainFacilBuy>();

        //버튼찾기
        //1. menu1
        GameObject menu1 = cardMain.transform.GetChild(0).gameObject;

        //1. 화로1 버튼
        GameObject mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[0] = mainButton;
        Button button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick1);

        //화로2
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[1] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick2);

        //화덕1
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[2] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick3);

        //화덕2
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[3] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick4);

        //흙가마
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[4] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick5);

        //돌가마
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[5] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick6);

        //가구 제작소
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[6] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick7);

        //그릇 제작소
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[7] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick8);

        //바구니 제작소
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[8] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick9);

        //우물
        mainButton = menu1.transform.GetChild(0).gameObject;
        buttonArray[9] = mainButton;
        button = mainButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(mb.OnClick10);
    }

    public void ClearButtons() {

        //버튼 기능 제거
        for(int i=0; i<10; i++) 
        {
            buttonArray[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
}
