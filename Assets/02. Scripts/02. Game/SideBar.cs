using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideBar : MonoBehaviour
{
    public static SideBar instance;
    public void Awake()
    {
        SideBar.instance = this;
    }

    public int playerIndex = 0;
    public int targetPlayerIndex = 0;
    public Text pigTxt, cowTxt, sheepTxt;
    public Text wheatTxt, vegetableTxt;
    public Text woodTxt, rockTxt, reedTxt, dirtTxt;
    public Text foodTxt, beggingTxt;
    public Text familyTxt, fenceTxt, shedTxt; 
    public Text upperPigTxt, upperCowTxt, upperSheepTxt;
    public Text upperWheatTxt, upperVegetableTxt;
    public Text upperWoodTxt, upperRockTxt, upperReedTxt, upperDirtTxt;
    public Text upperFoodTxt, upperBeggingTxt;
    public Text upperFamilyTxt, upperFenceTxt, upperShedTxt; 
    // Start is called before the first frame update
    public void ResourceUpdate()
    {
        targetPlayerIndex = ResourceManager.instance.getPlayerIndex();
        pigTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "pig").ToString();
        cowTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "cow").ToString();
        sheepTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "sheep").ToString();

        wheatTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "wheat").ToString();
        vegetableTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "vegetable").ToString();

        woodTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "wood").ToString();
        rockTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "rock").ToString();
        reedTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "reed").ToString();
        dirtTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "dirt").ToString();

        foodTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "food").ToString();
        beggingTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "begging").ToString();

        familyTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "family").ToString();
        fenceTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "fence").ToString();
        shedTxt.text = ResourceManager.instance.getResourceOfPlayer(targetPlayerIndex, "shed").ToString();
        if(isMyTurn()){
            upperPigTxt.text = pigTxt.text;
            upperCowTxt.text = cowTxt.text;
            upperSheepTxt.text = sheepTxt.text;

            upperWheatTxt.text = wheatTxt.text;
            upperVegetableTxt.text = vegetableTxt.text;

            upperWoodTxt.text = woodTxt.text;
            upperRockTxt.text = rockTxt.text;
            upperReedTxt.text = reedTxt.text;
            upperDirtTxt.text = dirtTxt.text;

            upperFoodTxt.text = foodTxt.text;
            upperBeggingTxt.text = beggingTxt.text;

            upperFamilyTxt.text = familyTxt.text;
            upperFenceTxt.text = fenceTxt.text;
            upperShedTxt.text = shedTxt.text;
        }
    }
    
    public bool isMyTurn(){
        return(playerIndex == targetPlayerIndex);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
