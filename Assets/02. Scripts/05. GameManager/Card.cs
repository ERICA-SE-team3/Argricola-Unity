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
        pigBreeder, //돼지 사육사

        //8~15 : 보조 설비 카드
        //단순 자원
        stoneClamp, //돌집게    8
        clayMining, //양토채굴장
        woodBoat, // 통나무배
        rake, //쇠스랑 
        
        //추가 행동
        watterBottle, //물통

        //설비 구매
        woodYard, //목재소

        //수확
        butter, //버터 제조기

        //점수용 카드
        bottle,  //병   15
        

        //16 ~ 25 : 주요 설비 카드
        fireplace1,  //화로1
        fireplace2,  //화로2
        cookingHearth1, //화덕1
        cookingHearth2, //화덕2
        clayOven, //흙가마
        stoneOven, //돌가마
        joinery, //가구제작소
        pottery, //그릇제작소
        basket, //바구니제작소
        well  //우물
    }

