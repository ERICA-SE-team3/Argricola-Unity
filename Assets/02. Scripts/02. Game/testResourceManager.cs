using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testResourceManager : MonoBehaviour
{

    private ResourceManager resourceManager;

    private void Awake()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    public void printResources()
    {
        resourceManager.addResource( 0, "wood", 1 );
    }
}
