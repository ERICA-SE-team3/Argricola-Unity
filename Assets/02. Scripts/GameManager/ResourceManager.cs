using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public void Awake()
    {
        ResourceManager.instance = this;
    }

    //우리는 이 함수만 사용합니다,
    public void addResource( int Playernumber, string Resourcename, int count )
    {
        switch (Resourcename)
        {

            case "pig":
                for(int i=0; i<count; i++) { pigIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "cow":
                for (int i = 0; i < count; i++) { cowIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "sheep":
                for (int i = 0; i < count; i++) { sheepIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "wheat":
                for (int i = 0; i < count; i++) { wheatIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "vegetable":
                for (int i = 0; i < count; i++) { vegetableIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "wood":
                for (int i = 0; i < count; i++) { woodIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "rock":
                for (int i = 0; i < count; i++) { rockIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "reed":
                for (int i = 0; i < count; i++) { reedIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "dirt":
                for (int i = 0; i < count; i++) { dirtIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "food":
                for (int i = 0; i < count; i++) { foodIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "begging":
                for (int i = 0; i < count; i++) { beggingIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "family":
                for (int i = 0; i < count; i++) { familyIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "fence":
                for (int i = 0; i < count; i++) { fenceIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "shed":
                for (int i = 0; i < count; i++) { shedIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "room":
                for (int i = 0; i < count; i++) { roomIncrement( Playernumber ); PrintResourceOfPlayer(); }
                break;
        }
    }

    public void minusResource(int Playernumber, string Resourcename, int count)
    {
        switch (Resourcename)
        {

            case "pig":
                for (int i = 0; i < count; i++) { pigDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "cow":
                for (int i = 0; i < count; i++) { cowDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "sheep":
                for (int i = 0; i < count; i++) { sheepDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "wheat":
                for (int i = 0; i < count; i++) { wheatDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "vegetable":
                for (int i = 0; i < count; i++) { vegetableDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "wood":
                for (int i = 0; i < count; i++) { woodDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "rock":
                for (int i = 0; i < count; i++) { rockDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "reed":
                for (int i = 0; i < count; i++) { reedDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "dirt":
                for (int i = 0; i < count; i++) { dirtDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "food":
                for (int i = 0; i < count; i++) { foodDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "begging":
                for (int i = 0; i < count; i++) { beggingDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "family":
                for (int i = 0; i < count; i++) { familyDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "fence":
                for (int i = 0; i < count; i++) { fenceDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "shed":
                for (int i = 0; i < count; i++) { shedDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;

            case "room":
                for (int i = 0; i < count; i++) { roomDecrement( Playernumber ); PrintResourceOfPlayer(); }
                break;
        }
    }

    public void PrintResourceOfPlayer()
    {
        for(int i=0; i<4; i++)
        {
            Debug.Log("\nPlayer number: " + i +
                "\npig: " + GameManager.instance.players[i].pig +
                "\ncow: " + GameManager.instance.players[i].cow +
                "\nsheep: " + GameManager.instance.players[i].sheep +
                "\nwheat: " + GameManager.instance.players[i].wheat +
                "\nvegetable: " + GameManager.instance.players[i].vegetable +
                "\nwood: " + GameManager.instance.players[i].wood +
                "\nrock: " + GameManager.instance.players[i].rock +
                "\nreed: " + GameManager.instance.players[i].reed +
                "\ndirt: " + GameManager.instance.players[i].dirt +
                "\nfood: " + GameManager.instance.players[i].food +
                "\nbegging: " + GameManager.instance.players[i].begging +
                "\nfamily: " + GameManager.instance.players[i].family +
                "\nfence: " + GameManager.instance.players[i].fence +
                "\nshed: " + GameManager.instance.players[i].shed +
               "\nroom: " + GameManager.instance.players[i].room);
            
            
        }
    }

    //자원들 get 함수
    public int getResourceOfPlayer( int Playernumber, string Resourcename )
    {
        int result = 0;
        switch (Resourcename)
        {

            case "pig":
                result = GameManager.instance.players[Playernumber].pig;
                break;

            case "cow":
                result = GameManager.instance.players[Playernumber].cow;
                break;

            case "sheep":
                result = GameManager.instance.players[Playernumber].sheep;
                break;

            case "wheat":
                result = GameManager.instance.players[Playernumber].wheat;
                break;

            case "vegetable":
                result = GameManager.instance.players[Playernumber].vegetable;
                break;

            case "wood":
                result = GameManager.instance.players[Playernumber].wood;
                break;

            case "rock":
                result = GameManager.instance.players[Playernumber].rock;
                break;

            case "reed":
                result = GameManager.instance.players[Playernumber].reed;
                break;

            case "dirt":
                result = GameManager.instance.players[Playernumber].dirt;
                break;

            case "food":
                result = GameManager.instance.players[Playernumber].food;
                break;

            case "begging":
                result = GameManager.instance.players[Playernumber].begging;
                break;

            case "family":
                result = GameManager.instance.players[Playernumber].family;
                break;

            case "fence":
                result = GameManager.instance.players[Playernumber].fence;
                break;

            case "shed":
                result = GameManager.instance.players[Playernumber].shed;
                break;

            case "room":
                result = GameManager.instance.players[Playernumber].room;
                break;
        }
        return result;
    }

    //increment functions
    //don't touch this code.
    void pigIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].pig = GameManager.instance.players[Playernumber].pig + 1;
    }

    void cowIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].cow = GameManager.instance.players[Playernumber].cow + 1;
    }

    void sheepIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].sheep = GameManager.instance.players[Playernumber].sheep + 1;
    }

    void wheatIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].wheat = GameManager.instance.players[Playernumber].wheat + 1;
    }

    void vegetableIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].vegetable = GameManager.instance.players[Playernumber].vegetable + 1;
    }

    void woodIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].wood = GameManager.instance.players[Playernumber].wood + 1;
    }

    void rockIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].rock = GameManager.instance.players[Playernumber].rock + 1;
    }

    void reedIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].reed = GameManager.instance.players[Playernumber].reed + 1;
    }

    void dirtIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].dirt = GameManager.instance.players[Playernumber].dirt + 1;
    }

    void foodIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].food = GameManager.instance.players[Playernumber].food + 1;
    }

    void beggingIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].begging = GameManager.instance.players[Playernumber].begging + 1;
    }

    void familyIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].family = GameManager.instance.players[Playernumber].family + 1;
    }

    void fenceIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].fence = GameManager.instance.players[Playernumber].fence + 1;
    }

    void shedIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].shed = GameManager.instance.players[Playernumber].shed + 1;
    }

    void roomIncrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].room = GameManager.instance.players[Playernumber].room + 1;
    }


    //Decrement functions
    void pigDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].pig = GameManager.instance.players[Playernumber].pig - 1;
    }

    void cowDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].cow = GameManager.instance.players[Playernumber].cow - 1;
    }

    void sheepDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].sheep = GameManager.instance.players[Playernumber].sheep - 1;
    }

    void wheatDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].wheat = GameManager.instance.players[Playernumber].wheat - 1;
    }

    void vegetableDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].vegetable = GameManager.instance.players[Playernumber].vegetable - 1;
    }

    void woodDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].wood = GameManager.instance.players[Playernumber].wood - 1;
    }

    void rockDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].rock = GameManager.instance.players[Playernumber].rock - 1;
    }

    void reedDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].reed = GameManager.instance.players[Playernumber].reed - 1;
    }

    void dirtDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].dirt = GameManager.instance.players[Playernumber].dirt - 1;
    }

    void foodDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].food = GameManager.instance.players[Playernumber].food - 1;
    }

    void beggingDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].begging = GameManager.instance.players[Playernumber].begging - 1;
    }

    void familyDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].family = GameManager.instance.players[Playernumber].family - 1;
    }

    void fenceDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].fence = GameManager.instance.players[Playernumber].fence - 1;
    }

    void shedDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].shed = GameManager.instance.players[Playernumber].shed - 1;
    }

    void roomDecrement( int Playernumber )
    {
        GameManager.instance.players[Playernumber].room = GameManager.instance.players[Playernumber].room - 1;
    }
}

