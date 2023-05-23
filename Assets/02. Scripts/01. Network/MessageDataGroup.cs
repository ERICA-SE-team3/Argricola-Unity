using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class PlayerMessageData
{
    public bool isFirstPlayer = false;
    public int pig,cow,sheep;
    public int wheat,vegetable;
    public int wood,rock,reed,dirt;
    public int food,begging;
    public int family,fence,shed,room;
    public int houseGrade;
    public List<int> card_owns;
    public List<int> card_hands;
    public int Jobs {
        get         { return CountJobs(); }
        private set { ; }
    }

    int CountJobs()
    {
        // Count Job cars at card_owns
        return 0;
    }

    public void Init()
    {
        this.isFirstPlayer = false;
        this.pig = 0; this.cow = 0; this.sheep = 0;
        this.wheat = 0; this.vegetable = 0;
        this.wood = 0; this.rock = 0; this.reed = 0; this.dirt = 0;
        this.food = 3; this.begging = 0;
        this.family = 2; this.fence = 0; this.shed = 0; this.room = 2;
        this.card_owns = new List<int>();
        this.card_hands = new List<int>();
    }
}

[System.Serializable]
public class PlayerBoardMessageData
{
    public BlockData[] blockDatas;
}

[System.Serializable]
public class BlockData
{
    public int row;
    public int col;
    public BlockType type;
    public bool hasShed;
    public int[] fence;
    public int cow;
    public int pig;
    public int sheep;
    public int family;
    public SeedType seedType;
    public int seedCount;
}

[System.Serializable]
public enum BlockType
{
    EMTPY,
    FENCE,
    HOUSE,
    FARM
}

[System.Serializable]
public enum SeedType
{
    WHEAT,
    VEGETABLE
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
    FRAMLAND,
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
    CHANGE_BOARD // 가축 옮기기
}