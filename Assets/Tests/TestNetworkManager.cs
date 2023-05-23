using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestNetworkManager
{
    string url = "ws://15.165.71.224:8080/ws";
    string msgDesination = "/pub/hello";

    public NetworkManager SetNetworkManager()
    {
        var obj = new GameObject();
        obj.AddComponent<NetworkManager>();
        var networkManager = obj.GetComponent<NetworkManager>();
        networkManager.url = url;
        networkManager.msgDesination = msgDesination;
        networkManager.Awake();
        networkManager.Start();
        return networkManager;
    }
    
    [UnityTest]
    public IEnumerator TestNetworkManagerSendMessage()
    {
        var obj = new GameObject();
        obj.AddComponent<NetworkManager>();
        var networkManager = obj.GetComponent<NetworkManager>();
        networkManager.url = url;
        networkManager.msgDesination = msgDesination;
        networkManager.Awake();

        networkManager.Start();

        yield return new WaitForSeconds(1);

        networkManager.SendMessage("Hello World!");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
