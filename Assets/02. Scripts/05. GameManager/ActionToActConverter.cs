using System;
using System.Collections;
using UnityEngine;

public static class ActionToActConverter
{
    public static int ActionTypeToActIndex(ActionType type)
    {
        switch(type)
        {
            case ActionType.BUSH:
                return 0;
            case ActionType.DOBULE_BUSH:
                return 1;
            case ActionType.RESOURCE_MARKET:
                return 2;
            case ActionType.CLAY_PIT:
                return 3;
            case ActionType.LESSON_ONE:
                return 10;
            case ActionType.TROUPE:
                return 5;
            case ActionType.FARM_EXPANSION:
                return 6;
            case ActionType.MEETING_PLACE:
                return 7;
            case ActionType.SEED:
                return 8;
            case ActionType.FARMLAND:
                return 9;
            case ActionType.LESSON_TWO:
                return 4;
            case ActionType.DATALLER:
                return 11;
            case ActionType.FOREST:
                return 12;
            case ActionType.DIRT_PIT:
                return 13;
            case ActionType.REED_FIELD:
                return 14;
            case ActionType.FISHING:
                return 15;
            case ActionType.GRAIN_UTILIZATION:
                return 16;
            case ActionType.SHEEP_MARKET:
                return 17;
            case ActionType.FENCE:
                return 18;
            case ActionType.MAJOR_FACILITIES:
                return 19;
            case ActionType.BASIC_FAMILY_INCREASE:
                return 20;
            case ActionType.WESTREN_QUARRY:
                return 21;
            case ActionType.HOUSE_RENOVATION:
                return 22;
            case ActionType.PIG_MARKET:
                return 23;
            case ActionType.VEGETABLE_SEEDS:
                return 24;
            case ActionType.EASTERN_QUARRY:
                return 25;
            case ActionType.COW_MARKET:
                return 26;
            case ActionType.URGENT_FAMILY_INCREASE:
                return 27;
            case ActionType.FIELD_FARMING:
                return 28;
            case ActionType.FARM_REMODELING:
                return 29;
        }
        
        Debug.LogError("ActionTypeToActIndex: ActionType is not valid");
        Debug.LogError("ActionTypeToActIndex: " + type);
        throw new Exception("ActionTypeToActIndex: ActionType is not valid");
    }  
}