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

    //�츮�� �� �Լ��� ����մϴ�,
    public void addResource( int playerId, string Resourcename, int count )
    {
        switch (Resourcename)
        {

            case "pig":
                for(int i=0; i<count; i++) { pigIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "cow":
                for (int i = 0; i < count; i++) { cowIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "sheep":
                for (int i = 0; i < count; i++) { sheepIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "wheat":
                for (int i = 0; i < count; i++) { wheatIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "vegetable":
                for (int i = 0; i < count; i++) { vegetableIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "wood":
                for (int i = 0; i < count; i++) { woodIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "stone":
                for (int i = 0; i < count; i++) { rockIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "reed":
                for (int i = 0; i < count; i++) { reedIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "clay":
                for (int i = 0; i < count; i++) { clayIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "food":
                for (int i = 0; i < count; i++) { foodIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "begging":
                for (int i = 0; i < count; i++) { beggingIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "family":
                for (int i = 0; i < count; i++) { familyIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "fence":
                for (int i = 0; i < count; i++) { fenceIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "shed":
                for (int i = 0; i < count; i++) { shedIncrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "room":
                for (int i = 0; i < count; i++) { roomIncrement( playerId ); PrintResourceOfPlayer(); }
                break;
        }
        SidebarManager.instance.sidebarUpdate(playerId);
    }

    public void minusResource(int playerId, string Resourcename, int count)
    {
        switch (Resourcename)
        {

            case "pig":
                for (int i = 0; i < count; i++) { pigDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "cow":
                for (int i = 0; i < count; i++) { cowDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "sheep":
                for (int i = 0; i < count; i++) { sheepDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "wheat":
                for (int i = 0; i < count; i++) { wheatDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "vegetable":
                for (int i = 0; i < count; i++) { vegetableDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "wood":
                for (int i = 0; i < count; i++) { woodDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "rock":
                for (int i = 0; i < count; i++) { rockDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "reed":
                for (int i = 0; i < count; i++) { reedDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "clay":
                for (int i = 0; i < count; i++) { clayDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "food":
                for (int i = 0; i < count; i++) { foodDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "begging":
                for (int i = 0; i < count; i++) { beggingDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "family":
                for (int i = 0; i < count; i++) { familyDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "fence":
                for (int i = 0; i < count; i++) { fenceDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "shed":
                for (int i = 0; i < count; i++) { shedDecrement( playerId ); PrintResourceOfPlayer(); }
                break;

            case "room":
                for (int i = 0; i < count; i++) { roomDecrement( playerId ); PrintResourceOfPlayer(); }
                break;
        }
        SidebarManager.instance.sidebarUpdate(playerId);
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
                "\nclay: " + GameManager.instance.players[i].clay +
                "\nfood: " + GameManager.instance.players[i].food +
                "\nbegging: " + GameManager.instance.players[i].begging +
                "\nfamily: " + GameManager.instance.players[i].family +
                "\nfence: " + GameManager.instance.players[i].fence +
                "\nshed: " + GameManager.instance.players[i].shed +
               "\nroom: " + GameManager.instance.players[i].room);
            
            
        }
    }

    //�ڿ��� get �Լ�
    public int getResourceOfPlayer( int playerId, string Resourcename )
    {
        int result = 0;
        switch (Resourcename)
        {
            case "pig":
                result = GameManager.instance.players[playerId].pig;
                break;

            case "cow":
                result = GameManager.instance.players[playerId].cow;
                break;

            case "sheep":
                result = GameManager.instance.players[playerId].sheep;
                break;

            case "wheat":
                result = GameManager.instance.players[playerId].wheat;
                break;

            case "vegetable":
                result = GameManager.instance.players[playerId].vegetable;
                break;

            case "wood":
                result = GameManager.instance.players[playerId].wood;
                break;

            case "rock":
                result = GameManager.instance.players[playerId].rock;
                break;

            case "reed":
                result = GameManager.instance.players[playerId].reed;
                break;

            case "clay":
                result = GameManager.instance.players[playerId].clay;
                break;

            case "food":
                result = GameManager.instance.players[playerId].food;
                break;

            case "begging":
                result = GameManager.instance.players[playerId].begging;
                break;

            case "family":
                result = GameManager.instance.players[playerId].family;
                break;

            case "fence":
                result = GameManager.instance.players[playerId].fence;
                break;

            case "shed":
                result = GameManager.instance.players[playerId].shed;
                break;

            case "room":
                result = GameManager.instance.players[playerId].room;
                break;
        }
        return result;
    }



    //increment functions
    //don't touch this code.
    void pigIncrement( int playerId )
    {
        GameManager.instance.players[playerId].pig = GameManager.instance.players[playerId].pig + 1;
    }

    void cowIncrement( int playerId )
    {
        GameManager.instance.players[playerId].cow = GameManager.instance.players[playerId].cow + 1;
    }

    void sheepIncrement( int playerId )
    {
        GameManager.instance.players[playerId].sheep = GameManager.instance.players[playerId].sheep + 1;
    }

    void wheatIncrement( int playerId )
    {
        GameManager.instance.players[playerId].wheat = GameManager.instance.players[playerId].wheat + 1;
    }

    void vegetableIncrement( int playerId )
    {
        GameManager.instance.players[playerId].vegetable = GameManager.instance.players[playerId].vegetable + 1;
    }

    void woodIncrement( int playerId )
    {
        GameManager.instance.players[playerId].wood = GameManager.instance.players[playerId].wood + 1;
    }

    void rockIncrement( int playerId )
    {
        GameManager.instance.players[playerId].rock = GameManager.instance.players[playerId].rock + 1;
    }

    void reedIncrement( int playerId )
    {
        GameManager.instance.players[playerId].reed = GameManager.instance.players[playerId].reed + 1;
    }

    void clayIncrement( int playerId )
    {
        GameManager.instance.players[playerId].clay = GameManager.instance.players[playerId].clay + 1;
    }

    void foodIncrement( int playerId )
    {
        GameManager.instance.players[playerId].food = GameManager.instance.players[playerId].food + 1;
    }

    void beggingIncrement( int playerId )
    {
        GameManager.instance.players[playerId].begging = GameManager.instance.players[playerId].begging + 1;
    }

    void familyIncrement( int playerId )
    {
        GameManager.instance.players[playerId].family = GameManager.instance.players[playerId].family + 1;
    }

    void fenceIncrement( int playerId )
    {
        GameManager.instance.players[playerId].fence = GameManager.instance.players[playerId].fence + 1;
    }

    void shedIncrement( int playerId )
    {
        GameManager.instance.players[playerId].shed = GameManager.instance.players[playerId].shed + 1;
    }

    void roomIncrement( int playerId )
    {
        GameManager.instance.players[playerId].room = GameManager.instance.players[playerId].room + 1;
    }


    //Decrement functions
    void pigDecrement( int playerId )
    {
        GameManager.instance.players[playerId].pig = GameManager.instance.players[playerId].pig - 1;
    }

    void cowDecrement( int playerId )
    {
        GameManager.instance.players[playerId].cow = GameManager.instance.players[playerId].cow - 1;
    }

    void sheepDecrement( int playerId )
    {
        GameManager.instance.players[playerId].sheep = GameManager.instance.players[playerId].sheep - 1;
    }

    void wheatDecrement( int playerId )
    {
        GameManager.instance.players[playerId].wheat = GameManager.instance.players[playerId].wheat - 1;
    }

    void vegetableDecrement( int playerId )
    {
        GameManager.instance.players[playerId].vegetable = GameManager.instance.players[playerId].vegetable - 1;
    }

    void woodDecrement( int playerId )
    {
        GameManager.instance.players[playerId].wood = GameManager.instance.players[playerId].wood - 1;
    }

    void rockDecrement( int playerId )
    {
        GameManager.instance.players[playerId].rock = GameManager.instance.players[playerId].rock - 1;
    }

    void reedDecrement( int playerId )
    {
        GameManager.instance.players[playerId].reed = GameManager.instance.players[playerId].reed - 1;
    }

    void clayDecrement( int playerId )
    {
        GameManager.instance.players[playerId].clay = GameManager.instance.players[playerId].clay - 1;
    }

    void foodDecrement( int playerId )
    {
        GameManager.instance.players[playerId].food = GameManager.instance.players[playerId].food - 1;
    }

    void beggingDecrement( int playerId )
    {
        GameManager.instance.players[playerId].begging = GameManager.instance.players[playerId].begging - 1;
    }

    void familyDecrement( int playerId )
    {
        GameManager.instance.players[playerId].remainFamilyOfCurrentPlayer = GameManager.instance.players[playerId].remainFamilyOfCurrentPlayer - 1;
    }

    void fenceDecrement( int playerId )
    {
        GameManager.instance.players[playerId].fence = GameManager.instance.players[playerId].fence - 1;
    }

    void shedDecrement( int playerId )
    {
        GameManager.instance.players[playerId].shed = GameManager.instance.players[playerId].shed - 1;
    }

    void roomDecrement( int playerId )
    {
        GameManager.instance.players[playerId].room = GameManager.instance.players[playerId].room - 1;
    }
}

