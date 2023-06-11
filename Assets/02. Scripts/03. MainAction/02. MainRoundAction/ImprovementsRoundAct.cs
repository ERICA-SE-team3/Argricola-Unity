using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImprovementsRoundAct : ButtonParents
{
  /* 주요설비 행동
    1. 해당 행동 Onclick
    2. 주요설비 / 보조설비 중 택 1
      주요설비  선택 시
      - 주요설비 모달 열림
      보조설비 선택 시
      - 보조설비 모달 열림
    3. 선택한 카드를 얻기위해 해당 카드에 해당하는 비용을 지불하고 카드를 내려놓음
  */
    public GameObject cardMain;
    GameObject[] buttonArray = new GameObject[10];


    public int playerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId)
        {
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[19] = true;
            // 해당 행동을 클릭한 순간 가족 자원수가 하나 줄어야 하므로 
            ResourceManager.instance.minusResource(playerIndex, "family", 1);  
            GameManager.instance.actionQueue.Enqueue("improvements");
            GameManager.instance.PopQueue();
            //핸드열기 동작을 통해 주요설비 / 보조설비 카드가 펴져야 함 (이 둘은 전환 버튼을 통해 고를 수 있게끔)
        } 
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
      for(int i=0; i<10; i++) {
        buttonArray[i].GetComponent<Button>().onClick.RemoveAllListeners();
      }
    }
}

