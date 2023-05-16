using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResourceManager : MonoBehaviour
{
    public MessageData messagedata;
    
    // Start is called before the first frame update
    void Start()
    {
        //player 1 initialize
        this.messagedata.player.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addResource( int Playernumber, string Resourcename, int count )
    {
        switch (Resourcename)
        {

            case "pig":
                for(int i=0; i<count; i++) { this.pigIncrement(); }
                break;

            case "cow":
                for (int i = 0; i < count; i++) { this.cowIncrement(); }
                break;

            case "sheep":
                for (int i = 0; i < count; i++) { this.sheepIncrement(); }
                break;

            case "wheat":
                for (int i = 0; i < count; i++) { this.wheatIncrement(); }
                break;

            case "vegetable":
                for (int i = 0; i < count; i++) { this.vegetableIncrement(); }
                break;

            case "wood":
                for (int i = 0; i < count; i++) { this.woodIncrement(); }
                break;

            case "rock":
                for (int i = 0; i < count; i++) { this.rockIncrement(); }
                break;

            case "reed":
                for (int i = 0; i < count; i++) { this.reedIncrement(); }
                break;

            case "dirt":
                for (int i = 0; i < count; i++) { this.dirtIncrement(); }
                break;

            case "food":
                for (int i = 0; i < count; i++) { this.foodIncrement(); }
                break;

            case "begging":
                for (int i = 0; i < count; i++) { this.beggingIncrement(); }
                break;

            case "family":
                for (int i = 0; i < count; i++) { this.familyIncrement(); }
                break;

            case "fence":
                for (int i = 0; i < count; i++) { this.fenceIncrement(); }
                break;

            case "shed":
                for (int i = 0; i < count; i++) { this.shedIncrement(); }
                break;

            case "room":
                for (int i = 0; i < count; i++) { this.roomIncrement(); }
                break;
        }
    }

    public void minusResource(int Playernumber, string Resourcename, int count)
    {
        switch (Resourcename)
        {

            case "pig":
                for (int i = 0; i < count; i++) { this.pigDecrement(); }
                break;

            case "cow":
                for (int i = 0; i < count; i++) { this.cowDecrement(); }
                break;

            case "sheep":
                for (int i = 0; i < count; i++) { this.sheepDecrement(); }
                break;

            case "wheat":
                for (int i = 0; i < count; i++) { this.wheatDecrement(); }
                break;

            case "vegetable":
                for (int i = 0; i < count; i++) { this.vegetableDecrement(); }
                break;

            case "wood":
                for (int i = 0; i < count; i++) { this.woodDecrement(); }
                break;

            case "rock":
                for (int i = 0; i < count; i++) { this.rockDecrement(); }
                break;

            case "reed":
                for (int i = 0; i < count; i++) { this.reedDecrement(); }
                break;

            case "dirt":
                for (int i = 0; i < count; i++) { this.dirtDecrement(); }
                break;

            case "food":
                for (int i = 0; i < count; i++) { this.foodDecrement(); }
                break;

            case "begging":
                for (int i = 0; i < count; i++) { this.beggingDecrement(); }
                break;

            case "family":
                for (int i = 0; i < count; i++) { this.familyDecrement(); }
                break;

            case "fence":
                for (int i = 0; i < count; i++) { this.fenceDecrement(); }
                break;

            case "shed":
                for (int i = 0; i < count; i++) { this.shedDecrement(); }
                break;

            case "room":
                for (int i = 0; i < count; i++) { this.roomDecrement(); }
                break;
        }
    }


    //increment functions
    void pigIncrement()
    {
        this.messagedata.player.pig = this.messagedata.player.pig + 1;
    }

    void cowIncrement()
    {
        this.messagedata.player.cow = this.messagedata.player.cow + 1;
    }

    void sheepIncrement()
    {
        this.messagedata.player.sheep = this.messagedata.player.sheep + 1;
    }

    void wheatIncrement()
    {
        this.messagedata.player.wheat = this.messagedata.player.wheat + 1;
    }

    void vegetableIncrement()
    {
        this.messagedata.player.vegetable = this.messagedata.player.vegetable + 1;
    }

    void woodIncrement()
    {
        this.messagedata.player.wood = this.messagedata.player.wood + 1;
    }

    void rockIncrement()
    {
        this.messagedata.player.rock = this.messagedata.player.rock + 1;
    }

    void reedIncrement()
    {
        this.messagedata.player.reed = this.messagedata.player.reed + 1;
    }

    void dirtIncrement()
    {
        this.messagedata.player.dirt = this.messagedata.player.dirt + 1;
    }

    void foodIncrement()
    {
        this.messagedata.player.food = this.messagedata.player.food + 1;
    }

    void beggingIncrement()
    {
        this.messagedata.player.begging = this.messagedata.player.begging + 1;
    }

    void familyIncrement()
    {
        this.messagedata.player.family = this.messagedata.player.family + 1;
    }

    void fenceIncrement()
    {
        this.messagedata.player.fence = this.messagedata.player.fence + 1;
    }

    void shedIncrement()
    {
        this.messagedata.player.shed = this.messagedata.player.shed + 1;
    }

    void roomIncrement()
    {
        this.messagedata.player.room = this.messagedata.player.room + 1;
    }


    //Decrement functions
    void pigDecrement()
    {
        this.messagedata.player.pig = this.messagedata.player.pig - 1;
    }

    void cowDecrement()
    {
        this.messagedata.player.cow = this.messagedata.player.cow - 1;
    }

    void sheepDecrement()
    {
        this.messagedata.player.sheep = this.messagedata.player.sheep - 1;
    }

    void wheatDecrement()
    {
        this.messagedata.player.wheat = this.messagedata.player.wheat - 1;
    }

    void vegetableDecrement()
    {
        this.messagedata.player.vegetable = this.messagedata.player.vegetable - 1;
    }

    void woodDecrement()
    {
        this.messagedata.player.wood = this.messagedata.player.wood - 1;
    }

    void rockDecrement()
    {
        this.messagedata.player.rock = this.messagedata.player.rock - 1;
    }

    void reedDecrement()
    {
        this.messagedata.player.reed = this.messagedata.player.reed - 1;
    }

    void dirtDecrement()
    {
        this.messagedata.player.dirt = this.messagedata.player.dirt - 1;
    }

    void foodDecrement()
    {
        this.messagedata.player.food = this.messagedata.player.food - 1;
    }

    void beggingDecrement()
    {
        this.messagedata.player.begging = this.messagedata.player.begging - 1;
    }

    void familyDecrement()
    {
        this.messagedata.player.family = this.messagedata.player.family - 1;
    }

    void fenceDecrement()
    {
        this.messagedata.player.fence = this.messagedata.player.fence - 1;
    }

    void shedDecrement()
    {
        this.messagedata.player.shed = this.messagedata.player.shed - 1;
    }

    void roomDecrement()
    {
        this.messagedata.player.room = this.messagedata.player.room - 1;
    }
}
