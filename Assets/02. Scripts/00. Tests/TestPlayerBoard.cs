using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestPlayerBoard
{
    public class _TestSetFence
    {
        // A Test behaves as an ordinary method
        [Test]
        public void FenceInstallVoid()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[1,3].type, BlockType.FENCE);
        }

        [Test]
        public void FenceInstallShed()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);
            
            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallShed();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.EndInstallShed();

            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[1,3].hasShed, true);
            Assert.AreEqual(playerBoard.blocks[1,3].type, BlockType.FENCE);
        }

        [Test]
        public void FenceInstallFarm()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);
            
            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallFarm();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.EndInstallFarm();

            // LogAssert.Expect(LogType.Error, "설치할 수 없습니다. 다시 선택해주세요.");
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);

            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[1,3].type, BlockType.FARM);
        }

        [Test]
        public void FenceInstallHouse()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();
            
            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);
            
            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallHouse();
            playerBoard.OnClick(playerBoard.blocks[0,0]);
            playerBoard.EndInstallHouse();

            // LogAssert.Expect(LogType.Error, "설치할 수 없습니다. 다시 선택해주세요.");

            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[0,0]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[0,0].type, BlockType.HOUSE);
        }


        [Test]
        public void FenceInstallNoNeighbor()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();
            
            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();
            
            Assert.AreEqual(playerBoard.blocks[1,3].fence[0], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[1], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[2], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[3], true);
        }

        [Test]
        public void FenceInstallNeighbor1()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[2,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[2,3].fence[0], false);
            Assert.AreEqual(playerBoard.blocks[2,3].fence[1], true);
            Assert.AreEqual(playerBoard.blocks[2,3].fence[2], true);
            Assert.AreEqual(playerBoard.blocks[2,3].fence[3], true);
        }

        [Test]
        public void FenceInstallNeighbor2()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();
            
            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            // 상,우 
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[0,3]);
            playerBoard.OnClick(playerBoard.blocks[0,4]);
            playerBoard.OnClick(playerBoard.blocks[1,4]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();


            // 테스팅 블럭
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[1,3].fence[0], false);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[1], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[2], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[3], false);
        }

        [Test]
        public void FenceInstallNeighbor3()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            // 상, 하, 우
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[0,3]);
            playerBoard.OnClick(playerBoard.blocks[0,4]);
            playerBoard.OnClick(playerBoard.blocks[1,4]);
            playerBoard.OnClick(playerBoard.blocks[2,4]);
            playerBoard.OnClick(playerBoard.blocks[2,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            // 테스팅 블럭
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[1,3].fence[0], false);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[1], false);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[2], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[3], false);
        }

        
        [Test]
        public void FenceInstallNeighbor4()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            // 상, 하, 좌, 우
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[0,3]);
            playerBoard.OnClick(playerBoard.blocks[0,4]);
            playerBoard.OnClick(playerBoard.blocks[1,4]);
            playerBoard.OnClick(playerBoard.blocks[2,4]);
            playerBoard.OnClick(playerBoard.blocks[2,3]);
            playerBoard.OnClick(playerBoard.blocks[2,2]);
            playerBoard.OnClick(playerBoard.blocks[1,2]);
            playerBoard.OnClick(playerBoard.blocks[0,2]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            // 테스팅 블럭 - 자동으로 울타리 처리가 되어있어야 함.
            Assert.AreEqual(playerBoard.blocks[1,3].fence[0], false);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[1], false);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[2], false);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[3], false);
            Assert.AreEqual(playerBoard.blocks[1,3].type, BlockType.FENCE);
        }

        [Test]
        public void FenceInstallAlreadyFence()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            ResourceManager.instance.addResource(gm.players[0].id, "wood", 1000);

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            // 3개 설치
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[0,3]);
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.OnClick(playerBoard.blocks[2,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            // 테스팅 블럭
            playerBoard.StartInstallFence();
            playerBoard.OnClick(playerBoard.blocks[1,3]);
            playerBoard.GetInstallButton().GetComponent<Button>().onClick.Invoke();
            playerBoard.EndInstallFence();

            Assert.AreEqual(playerBoard.blocks[1,3].fence[0], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[1], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[2], true);
            Assert.AreEqual(playerBoard.blocks[1,3].fence[3], true);
        }

        public GameObject InitGameResource()
        {
            GameObject obj = new GameObject();
            obj.AddComponent<GameManager>();
            obj.AddComponent<ResourceManager>();    

            GameManager gm = obj.GetComponent<GameManager>();
            ResourceManager rm = obj.GetComponent<ResourceManager>();

            rm.Awake();
            gm.roundList = Object.Instantiate(Resources.Load<GameObject>("01. Prefabs/RoundList"));

            obj.GetComponent<ResourceManager>().Awake();
            obj.GetComponent<GameManager>().Start();

            return obj;    
        }

        public PlayerBoard InitPlayerBoard()
        {
            GameObject obj = Object.Instantiate(Resources.Load<GameObject>("01. Prefabs/PlayerBoard"));

            GameObject confirmButton = new GameObject();
            confirmButton.AddComponent<Button>();
            obj.GetComponent<PlayerBoard>().confirmButton = confirmButton;

            GameObject blockPrefab = Object.Instantiate(Resources.Load<GameObject>("01. Prefabs/Block"));
            blockPrefab.AddComponent<Block>();
            obj.GetComponent<PlayerBoard>().blockPrefab = blockPrefab;

            PlayerBoard playerBoard = obj.GetComponent<PlayerBoard>();
            playerBoard.SetPlayer(GameManager.instance.players[0]);
            return playerBoard;
        }
    }

    public class _TestSetHouse
    {
        [Test]
        public void 집이_하나_잘_지어지는가()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallHouse();
            playerBoard.OnClick(playerBoard.blocks[0,0]);
            playerBoard.EndInstallHouse();

            Assert.AreEqual(playerBoard.blocks[0,0].type, BlockType.HOUSE);
        }

        [Test]
        public void 집이_두개_잘_지어지는가()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallHouse();
            playerBoard.OnClick(playerBoard.blocks[0,0]);
            playerBoard.OnClick(playerBoard.blocks[1,1]);
            playerBoard.EndInstallHouse();

            Assert.AreEqual(playerBoard.blocks[0,0].type, BlockType.HOUSE);
            Assert.AreEqual(playerBoard.blocks[1,1].type, BlockType.HOUSE);
        }

        [Test]
        public void 집_설치제한영역이_잘_판단되는가()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            playerBoard.StartInstallFarm();
            playerBoard.OnClick(playerBoard.blocks[2,4]);
            playerBoard.EndInstallFarm();

            playerBoard.StartInstallHouse();
            playerBoard.OnClick(playerBoard.blocks[1,0]); // 집 위에 추가 집 짓기 불가
            playerBoard.OnClick(playerBoard.blocks[2,4]); // 밭 위에 추가 집 짓기 불가
            playerBoard.OnClick(playerBoard.blocks[2,3]); // 집과 연결되지 않은 영역에 집 짓기 불가
            playerBoard.OnClick(playerBoard.blocks[0,0]); // 정상
            playerBoard.EndInstallHouse();

            Assert.AreEqual(playerBoard.blocks[1,0].type, BlockType.HOUSE);
            Assert.AreEqual(playerBoard.blocks[2,4].type, BlockType.FARM);
            Assert.AreEqual(playerBoard.blocks[2,3].type, BlockType.EMPTY);
            Assert.AreEqual(playerBoard.blocks[0,0].type, BlockType.HOUSE);
        }

        [Test]
        public void 집_생산_자원제한이_잘_판단되는가()
        {
            GameObject manager = InitGameResource();
            GameManager gm = manager.GetComponent<GameManager>();

            PlayerBoard playerBoard = InitPlayerBoard();
            playerBoard.player = gm.players[0];
            playerBoard.Start();

            gm.players[0].wood = 5;
            gm.players[0].reed = 1;

            LogAssert.Expect(LogType.Warning, "갈대가 부족합니다.");
            playerBoard.StartInstallHouse();

            gm.players[0].wood = 4;
            gm.players[0].reed = 2;

            LogAssert.Expect(LogType.Warning, "목재가 부족합니다.");
            playerBoard.StartInstallHouse();

            gm.players[0].wood = 5;
            gm.players[0].reed = 2;
            playerBoard.StartInstallHouse();
            playerBoard.OnClick(playerBoard.blocks[0,0]);
            playerBoard.EndInstallHouse();

            Assert.AreEqual(playerBoard.blocks[0,0].type, BlockType.HOUSE);
        }

        [Test]
        public void 집_생산_자원이_잘_소모되는가()
        {

        }

        [Test]
        public void 집_업그레이드가_잘_진행되는가()
        {

        }

        [Test]
        public void 집_업그레이드_자원이_잘_소모되는가()
        {

        }

        [Test]
        public void 집_업그레이드_자원제한이_잘_판단되는가()
        {

        }

        [Test]
        public void 집이_돌집일때_업그레이드가_안되는가()
        {

        }

        [Test]
        public void 집을_안짓고_동작을_끝낼수_없는가()
        {

        }


        public GameObject InitGameResource()
        {
            GameObject obj = new GameObject();
            obj.AddComponent<GameManager>();
            obj.AddComponent<ResourceManager>();    

            GameManager gm = obj.GetComponent<GameManager>();
            ResourceManager rm = obj.GetComponent<ResourceManager>();

            rm.Awake();
            gm.roundList = Object.Instantiate(Resources.Load<GameObject>("01. Prefabs/RoundList"));

            obj.GetComponent<ResourceManager>().Awake();
            obj.GetComponent<GameManager>().Start();

            rm.addResource(gm.players[0].id, "wood", 1000);
            rm.addResource(gm.players[0].id, "stone", 1000);
            rm.addResource(gm.players[0].id, "iron", 1000);
            rm.addResource(gm.players[0].id, "reed", 1000);

            return obj;    
        }

        public PlayerBoard InitPlayerBoard()
        {
            GameObject obj = Object.Instantiate(Resources.Load<GameObject>("01. Prefabs/PlayerBoard"));

            GameObject confirmButton = new GameObject();
            confirmButton.AddComponent<Button>();
            obj.GetComponent<PlayerBoard>().confirmButton = confirmButton;

            GameObject blockPrefab = Object.Instantiate(Resources.Load<GameObject>("01. Prefabs/Block"));
            blockPrefab.AddComponent<Block>();
            obj.GetComponent<PlayerBoard>().blockPrefab = blockPrefab;

            PlayerBoard playerBoard = obj.GetComponent<PlayerBoard>();
            playerBoard.SetPlayer(GameManager.instance.players[0]);
            return playerBoard;
        }
    }

  
}
