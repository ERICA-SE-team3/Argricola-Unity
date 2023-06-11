using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainboardUIController : MonoBehaviour
{
    public static MainboardUIController instance;

    public List<ButtonParents> buttons;

    public Sprite[] playerSprites;

    public SceneInitializer sceneInit;

    
    GameObject sheepMarket, wishChildren, westernQuarry, pigMarket, vegetableSeed, easternQuarry, cowMarket;
    GameObject grainUtilization, fencing, houseDevelop, cultivation, farmDevelop, improvements, urgentWishChildren;
    GameObject clayPit, copse, dayLaborer, dirtPit, expand, farming, fishing, forest, grainSeed, grove, lessonFood1, lessonFood2, meeting, reedFeild, resMarket, trevelingTheater;


    private void Start() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        buttons = new List<ButtonParents>();
        InitButtonParentsGameObject();
    }

    void InitButtonParentsGameObject()
    {
        sheepMarket = sceneInit.sheepMarket;
        wishChildren = sceneInit.wishChildren;
        westernQuarry = sceneInit.westernQuarry;
        pigMarket = sceneInit.pigMarket;
        vegetableSeed = sceneInit.vegetableSeed;
        easternQuarry = sceneInit.easternQuarry;
        cowMarket = sceneInit.cowMarket;
        grainUtilization = sceneInit.grainUtilization;
        fencing = sceneInit.fencing;
        houseDevelop = sceneInit.houseDevelop;
        cultivation = sceneInit.cultivation;
        farmDevelop = sceneInit.farmDevelop;
        improvements = sceneInit.improvements;
        urgentWishChildren = sceneInit.urgentWishChildren;
        clayPit = sceneInit.clayPit;
        copse = sceneInit.copse;
        dayLaborer = sceneInit.dayLaborer;
        dirtPit = sceneInit.dirtPit;
        expand = sceneInit.expand;
        farming = sceneInit.farming;
        fishing = sceneInit.fishing;
        forest = sceneInit.forest;
        grainSeed = sceneInit.grainSeed;
        grove = sceneInit.grove;
        lessonFood1 = sceneInit.lessonFood1;
        lessonFood2 = sceneInit.lessonFood2;
        meeting = sceneInit.meeting;
        reedFeild = sceneInit.reedFeild;
        resMarket = sceneInit.resMarket;
        trevelingTheater = sceneInit.trevelingTheater;
    }

    public void ActivatePlayerOnButton(ButtonParents button, int playerIndex)
    {
        buttons.Add(button);
        GameObject image = button.gameObject.transform.Find("Player").gameObject;
        image.GetComponent<Image>().sprite = playerSprites[playerIndex];
    }

    public void ActivatePlayerOnButton(ActionType type, int playerIndex)
    {
        if(GameManager.instance.isActionTypeEndTurn(type))
        {
            return;
        }
        ButtonParents button = GetButtonObject(type).GetComponent<ButtonParents>();
        buttons.Add(button);
        GameObject image = button.gameObject.transform.Find("Player").gameObject;
        image.GetComponent<Image>().sprite = playerSprites[playerIndex];
    }

    public void ResetBoard()
    {
        foreach(ButtonParents button in buttons)
        {
            GameObject image = button.gameObject.transform.Find("Player").gameObject;
            image.GetComponent<Image>().sprite = null;
        }
        buttons.Clear();
    }

    public GameObject GetButtonObject(ActionType type)
    {
        switch(type)
        {
            case ActionType.SHEEP_MARKET:
                return sheepMarket;
            case ActionType.BASIC_FAMILY_INCREASE:
                return wishChildren;
            case ActionType.WESTREN_QUARRY:
                return westernQuarry;
            case ActionType.PIG_MARKET:
                return pigMarket;
            case ActionType.VEGETABLE_SEEDS:
                return vegetableSeed;
            case ActionType.EASTERN_QUARRY:
                return easternQuarry;
            case ActionType.COW_MARKET:
                return cowMarket;
            case ActionType.GRAIN_UTILIZATION:
            case ActionType.GRAIN_UTILIZATION_END:
                return grainUtilization;
            case ActionType.FENCE:
            case ActionType.FENCE_END:
                return fencing;
            case ActionType.HOUSE_RENOVATION:
            case ActionType.HOUSE_RENOVATION_END:
                return houseDevelop;
            case ActionType.FIELD_FARMING:
            case ActionType.FIELD_FARMING_END:
                return cultivation;
            case ActionType.FARM_REMODELING:
            case ActionType.FARM_REMODELING_END:
                return farmDevelop;
            case ActionType.MAJOR_FACILITIES:
            case ActionType.MAJOR_FACILITIES_END:
                return improvements;
            case ActionType.URGENT_FAMILY_INCREASE:
            case ActionType.URGENT_FAMILY_INCREASE_END:
                return urgentWishChildren;
            case ActionType.CLAY_PIT:
                return clayPit;
            case ActionType.BUSH:
                return copse;
            case ActionType.DATALLER:
                return dayLaborer;
            case ActionType.DIRT_PIT:
                return dirtPit;
            case ActionType.FARM_EXPANSION:
            case ActionType.FARM_EXPANSION_END:
                return expand;
            case ActionType.FRAMLAND:
            case ActionType.FARMLAND_END:
                return farming;
            case ActionType.FISHING:
                return fishing;
            case ActionType.FOREST:
                return forest;
            case ActionType.SEED:
                return grainSeed;
            case ActionType.DOBULE_BUSH:
                return grove;
            case ActionType.LESSON_ONE:
            case ActionType.LESSON_ONE_END:
                return lessonFood1;
            case ActionType.LESSON_TWO:
            case ActionType.LESSON_TWO_END:
                return lessonFood2;
            case ActionType.MEETING_PLACE:
            case ActionType.MEETING_PLACE_END:
                return meeting;
            case ActionType.REED_FIELD:
                return reedFeild;
            case ActionType.RESOURCE_MARKET:
                return resMarket;
            case ActionType.TROUPE:
                return trevelingTheater;
            default:
                Debug.Log("Error");
                return null;
        }
    }
}
