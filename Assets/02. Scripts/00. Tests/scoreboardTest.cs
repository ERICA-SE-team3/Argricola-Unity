using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class scoreboardTest
{
    [Test]
    public void InitUpdate()
    {
        GameManager gameManager = new GameManager();
        ScoreBoard scoreBoard = new ScoreBoard();
        Player player1 = new Player();
        gameManager.players.Add(player1);
        PlayerBoard playerBoard = GameManager.instance.playerBoards[0];
        scoreBoard.UpdateScore();

        // gameManager.players[0].maincard_owns.Add(22);
        // Assert.IsTrue(gameManager.players[0].HasMainCard("joinery"));
        
        // gameManager.players[0].wood = 7;
        // scoreBoard.UpdateScore();
        // Assert.AreEqual(0, scoreBoard.highstPlayerIndex);
        // Assert.AreEqual(-5, scoreBoard.highstPlayerScore);
    }

    [Test]
    public void MainCardAdd()
    {
        GameManager gameManager = new GameManager();
        ScoreBoard scoreBoard = new ScoreBoard();
        Player player1 = new Player();

        gameManager.players.Add(player1);
        gameManager.players[0].maincard_owns.Add(22);
        Assert.IsTrue(gameManager.players[0].HasMainCard("joinery"));
    }
    [UnityTest]
    public IEnumerator scoreboardWithEnumeratorPasses()
    {
        yield return null;
    }
}
