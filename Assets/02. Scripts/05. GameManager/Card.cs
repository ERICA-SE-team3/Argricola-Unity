using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cards
    {
        //0~7 : 직업 카드
        //단순자원 직업카드
        magician, //마술사
        woodCutter, //나무꾼
        vegetableSeller,  //채소 장수

        //추가 행동에 적용되는 카드
        stoneCutter, //돌 자르는 사람
        wallMaster, //초벽질공
        woodPicker, //장작 채집자

        //점수 계산에 적용되는 카드
        organicFarmer, //유기 농부

        //여러 항목에 걸친 카드
        pigBreeder //돼지 사육사

        //8~15 : 보조 설비 카드

        //16 ~ 25 : 주요 설비 카드
    }
