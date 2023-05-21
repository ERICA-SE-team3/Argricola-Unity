using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    DummyPlayers dummy;
    public static ResourceManager instance;

    public void Awake()
    {
        dummy = new DummyPlayers();
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
                "\npig: " + dummy.players[i].pig +
                "\ncow: " + dummy.players[i].cow +
                "\nsheep: " + dummy.players[i].sheep +
                "\nwheat: " + dummy.players[i].wheat +
                "\nvegetable: " + dummy.players[i].vegetable +
                "\nwood: " + dummy.players[i].wood +
                "\nrock: " + dummy.players[i].rock +
                "\nreed: " + dummy.players[i].reed +
                "\ndirt: " + dummy.players[i].dirt +
                "\nfood: " + dummy.players[i].food +
                "\nbegging: " + dummy.players[i].begging +
                "\nfamily: " + dummy.players[i].family +
                "\nfence: " + dummy.players[i].fence +
                "\nshed: " + dummy.players[i].shed +
               "\nroom: " + dummy.players[i].room);
            
            
        }
    }

    //자원들 get 함수
    public int getResourceOfPlayer( int Playernumber, string Resourcename )
    {
        int result = 0;
        switch (Resourcename)
        {

            case "pig":
                result = dummy.players[Playernumber].pig;
                break;

            case "cow":
                result = dummy.players[Playernumber].cow;
                break;

            case "sheep":
                result = dummy.players[Playernumber].sheep;
                break;

            case "wheat":
                result = dummy.players[Playernumber].wheat;
                break;

            case "vegetable":
                result = dummy.players[Playernumber].vegetable;
                break;

            case "wood":
                result = dummy.players[Playernumber].wood;
                break;

            case "rock":
                result = dummy.players[Playernumber].rock;
                break;

            case "reed":
                result = dummy.players[Playernumber].reed;
                break;

            case "dirt":
                result = dummy.players[Playernumber].dirt;
                break;

            case "food":
                result = dummy.players[Playernumber].food;
                break;

            case "begging":
                result = dummy.players[Playernumber].begging;
                break;

            case "family":
                result = dummy.players[Playernumber].family;
                break;

            case "fence":
                result = dummy.players[Playernumber].fence;
                break;

            case "shed":
                result = dummy.players[Playernumber].shed;
                break;

            case "room":
                result = dummy.players[Playernumber].room;
                break;
        }
        return result;
    }

    //increment functions
    //don't touch this code.
    void pigIncrement( int Playernumber )
    {
        dummy.players[Playernumber].pig = dummy.players[Playernumber].pig + 1;
    }

    void cowIncrement( int Playernumber )
    {
        dummy.players[Playernumber].cow = dummy.players[Playernumber].cow + 1;
    }

    void sheepIncrement( int Playernumber )
    {
        dummy.players[Playernumber].sheep = dummy.players[Playernumber].sheep + 1;
    }

    void wheatIncrement( int Playernumber )
    {
        dummy.players[Playernumber].wheat = dummy.players[Playernumber].wheat + 1;
    }

    void vegetableIncrement( int Playernumber )
    {
        dummy.players[Playernumber].vegetable = dummy.players[Playernumber].vegetable + 1;
    }

    void woodIncrement( int Playernumber )
    {
        dummy.players[Playernumber].wood = dummy.players[Playernumber].wood + 1;
    }

    void rockIncrement( int Playernumber )
    {
        dummy.players[Playernumber].rock = dummy.players[Playernumber].rock + 1;
    }

    void reedIncrement( int Playernumber )
    {
        dummy.players[Playernumber].reed = dummy.players[Playernumber].reed + 1;
    }

    void dirtIncrement( int Playernumber )
    {
        dummy.players[Playernumber].dirt = dummy.players[Playernumber].dirt + 1;
    }

    void foodIncrement( int Playernumber )
    {
        dummy.players[Playernumber].food = dummy.players[Playernumber].food + 1;
    }

    void beggingIncrement( int Playernumber )
    {
        dummy.players[Playernumber].begging = dummy.players[Playernumber].begging + 1;
    }

    void familyIncrement( int Playernumber )
    {
        dummy.players[Playernumber].family = dummy.players[Playernumber].family + 1;
    }

    void fenceIncrement( int Playernumber )
    {
        dummy.players[Playernumber].fence = dummy.players[Playernumber].fence + 1;
    }

    void shedIncrement( int Playernumber )
    {
        dummy.players[Playernumber].shed = dummy.players[Playernumber].shed + 1;
    }

    void roomIncrement( int Playernumber )
    {
        dummy.players[Playernumber].room = dummy.players[Playernumber].room + 1;
    }


    //Decrement functions
    void pigDecrement( int Playernumber )
    {
        dummy.players[Playernumber].pig = dummy.players[Playernumber].pig - 1;
    }

    void cowDecrement( int Playernumber )
    {
        dummy.players[Playernumber].cow = dummy.players[Playernumber].cow - 1;
    }

    void sheepDecrement( int Playernumber )
    {
        dummy.players[Playernumber].sheep = dummy.players[Playernumber].sheep - 1;
    }

    void wheatDecrement( int Playernumber )
    {
        dummy.players[Playernumber].wheat = dummy.players[Playernumber].wheat - 1;
    }

    void vegetableDecrement( int Playernumber )
    {
        dummy.players[Playernumber].vegetable = dummy.players[Playernumber].vegetable - 1;
    }

    void woodDecrement( int Playernumber )
    {
        dummy.players[Playernumber].wood = dummy.players[Playernumber].wood - 1;
    }

    void rockDecrement( int Playernumber )
    {
        dummy.players[Playernumber].rock = dummy.players[Playernumber].rock - 1;
    }

    void reedDecrement( int Playernumber )
    {
        dummy.players[Playernumber].reed = dummy.players[Playernumber].reed - 1;
    }

    void dirtDecrement( int Playernumber )
    {
        dummy.players[Playernumber].dirt = dummy.players[Playernumber].dirt - 1;
    }

    void foodDecrement( int Playernumber )
    {
        dummy.players[Playernumber].food = dummy.players[Playernumber].food - 1;
    }

    void beggingDecrement( int Playernumber )
    {
        dummy.players[Playernumber].begging = dummy.players[Playernumber].begging - 1;
    }

    void familyDecrement( int Playernumber )
    {
        dummy.players[Playernumber].family = dummy.players[Playernumber].family - 1;
    }

    void fenceDecrement( int Playernumber )
    {
        dummy.players[Playernumber].fence = dummy.players[Playernumber].fence - 1;
    }

    void shedDecrement( int Playernumber )
    {
        dummy.players[Playernumber].shed = dummy.players[Playernumber].shed - 1;
    }

    void roomDecrement( int Playernumber )
    {
        dummy.players[Playernumber].room = dummy.players[Playernumber].room - 1;
    }
}

