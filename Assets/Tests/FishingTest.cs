using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class MainActFishingTests
{
    [Test]
    public void FishingAddResourceTest()    // Fishing 행동을 통해 '음식' 자원을 얻는 테스트 메서드
    {
        // 새로운 GameObject를 생성
        GameObject getObject = new GameObject();

        // GameObject에 ResourceManager 및 GameManager 컴포넌트를 추가
        getObject.AddComponent<ResourceManager>();
        getObject.AddComponent<GameManager>();

        // GameObject에서 GameManager와 ResourceManager 컴포넌트를 가져와서 각각의 변수에 할당
        GameManager gameManager = getObject.GetComponent<GameManager>();
        ResourceManager resourceManager = getObject.GetComponent<ResourceManager>();
        
        // ResourceManager과 GameManager의 초기화 메서드를 호출
        resourceManager.Awake();
        gameManager.Start();

        // 1번 플레이어의 초기 음식 개수를 가져오기
        int playerInitFoodCounts = resourceManager.getResourceOfPlayer(1, "food");

        // 1번 플레이어에게 음식 3개를 추가
        resourceManager.addResource(1, "food", 3);

        // 음식을 얻어 갱신된 플레리어의 음식 개수를 가져오기
        int playerResultFoodCounts = resourceManager.getResourceOfPlayer(1, "food");

        // 초기 음식 개수에 3을 더한 값과 테스트 이후의 음식 개수가 일치하는지 확인
        Assert.AreEqual(playerInitFoodCounts + 3, playerResultFoodCounts);
    }

    [Test]
    public void FoodMinusResourceTest()     // '음식' 자원의 개수가 감소하는 테스트 메서드
    {
        // 새로운 GameObject를 생성
        GameObject getObject = new GameObject();

        // GameObject에 ResourceManager 및 GameManager 컴포넌트를 추가
        getObject.AddComponent<ResourceManager>();
        getObject.AddComponent<GameManager>();

        // GameObject에서 GameManager와 ResourceManager 컴포넌트를 가져와서 각각의 변수에 할당
        GameManager gameManager = getObject.GetComponent<GameManager>();
        ResourceManager resourceManager = getObject.GetComponent<ResourceManager>();
        
        // ResourceManager과 GameManager의 초기화 메서드를 호출
        resourceManager.Awake();
        gameManager.Start();

        // 1번 플레이어의 초기 음식 개수를 가져오기
        int playerInitFoodCounts = resourceManager.getResourceOfPlayer(1, "food");

        // 1번 플레이어의 음식 1개를 감소
        resourceManager.minusResource(1, "food", 1);

        // 음식의 감소로 갱신된 플레이어의 음식 개수를 가져오기
        int playerResultFoodCounts = resourceManager.getResourceOfPlayer(1, "food");

        // 초기 음식 개수에 1을 뺀 값과 테스트 이후의 음식 개수가 일치하는지 확인
        Assert.AreEqual(playerInitFoodCounts - 1, playerResultFoodCounts);
    }
}
