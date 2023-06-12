using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMessageData
{
    // public bool isFirstPlayer = false;
    public int pig,cow,sheep;
    public int wheat,vegetable;
    public int wood,rock,reed,clay;
    public int food,begging;
    public int family,fence,shed,room, baby;
    public int houseGrade;

    public bool isFirstPlayer;

    public int remainFamilyOfCurrentPlayer;
    //직업 카드
    public List<int> jobcard_owns;
    public List<int> jobcard_hands;

    //보조설비 카드
    public List<int> subcard_owns;
    public List<int> subcard_hands;

    //주요 카드
    public List<int> maincard_owns;

    public int Jobs {
        get         { return CountJobs(); }
        private set { ; }
    }

    int CountJobs()
    {
        return this.jobcard_hands.Count;
    }

    public void Init()
    {
        // this.isFirstPlayer = false;
        this.pig = 0; this.cow = 0; this.sheep = 0;
        this.wheat = 0; this.vegetable = 0;
        this.wood = 0; this.rock = 0; this.reed = 0; this.clay = 0;
        this.food = 3; this.begging = 0;
        this.family = 2; this.fence = 0; this.shed = 0; this.room = 2; this.baby = 0;
        this.jobcard_owns = new List<int>();
        this.jobcard_hands = new List<int>();
        this.subcard_owns = new List<int>();
        this.subcard_hands = new List<int>();
        this.maincard_owns = new List<int>(); 

        this.remainFamilyOfCurrentPlayer = family;
        
    }
}


[System.Serializable]
public class PlayerBoardMessageData
{
    public HouseType houseType;
    public BlockData[] blockDatas;
}

[System.Serializable]
public class BlockData
{
    public int row;
    public int col;
    public BlockType type;
    public bool hasShed;
    public bool hasFamily;
    public bool[] fence;
    public int cow;
    public int pig;
    public int sheep;
    public SeedType seedType;
    public int seedCount;
}

[System.Serializable]
public enum BlockType
{
    EMPTY,
    FENCE,
    HOUSE,
    FARM
}

[System.Serializable]
public enum SeedType
{
    WHEAT,
    VEGETABLE,
    NONE,
}

[System.Serializable]
public enum HouseType
{
    WOOD,
    CLAY,
    STONE,
    NONE
}

public enum AnimalType
{
    NONE,
    SHEEP,
    PIG,
    COW
}

[System.Serializable]
public class MainBoardMessageData
{
    
}

[System.Serializable]
public enum ActionType
{
    BUSH,
    DOBULE_BUSH,
    RESOURCE_MARKET,
    CLAY_PIT,
    LESSON_ONE,
    LESSON_ONE_END,
    LESSON_TWO,
    LESSON_TWO_END,
    TROUPE,
    FARM_EXPANSION,
    FARM_EXPANSION_END,
    MEETING_PLACE,
    MEETING_PLACE_END,
    SEED,
    FARMLAND,
    FARMLAND_END,
    DATALLER,
    FOREST,
    DIRT_PIT,
    REED_FIELD,
    FISHING,
    MAJOR_FACILITIES,
    MAJOR_FACILITIES_END,
    FENCE,
    FENCE_END,
    GRAIN_UTILIZATION,
    GRAIN_UTILIZATION_END,
    SHEEP_MARKET,
    BASIC_FAMILY_INCREASE,
    BASIC_FAMILY_INCREASE_END,
    WESTREN_QUARRY,
    HOUSE_RENOVATION,
    HOUSE_RENOVATION_END,
    PIG_MARKET,
    VEGETABLE_SEEDS,
    COW_MARKET,
    EASTERN_QUARRY,
    FIELD_FARMING,
    FIELD_FARMING_END,
    URGENT_FAMILY_INCREASE,
    URGENT_FAMILY_INCREASE_END,
    FARM_REMODELING,
    FARM_REMODELING_END,
    CHANGE_RESOURCE, // 변환기 사용
    MOVE_ANIMAL, // 가축 옮기기
    NONE
}