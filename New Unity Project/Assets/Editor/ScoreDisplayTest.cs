using UnityEngine;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class ScoreDisplayTest {

  

    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl()
    {
        List<int> scoreList = new List<int>() { 1 };

        Assert.AreEqual("1", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T02Bowl()
    {
        List<int> scoreList = new List<int>() { 4,5 };

        Assert.AreEqual("45", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T03Bowl()
    {
        List<int> scoreList = new List<int>() { 4, 5,2,6,0,1 };

        Assert.AreEqual("452601", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T04Bowl()
    {
        List<int> scoreList = new List<int>() { 8, 2 };

        Assert.AreEqual("8/", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T05Bowl()
    {
        List<int> scoreList = new List<int>() { 8, 2, 4 };

        Assert.AreEqual("8/4", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T06Bowl()
    {
        List<int> scoreList = new List<int>() { 10,2};

        Assert.AreEqual("X 2", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T07Bowl()
    {
        List<int> scoreList = new List<int>() { 10, 10 };

        Assert.AreEqual("X X ", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T08Bowl()
    {
        List<int> scoreList = new List<int>() { 10, 10,4 };

        Assert.AreEqual("X X 4", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T09Bowl()
    {
        List<int> scoreList = new List<int>() { 10, 10, 4,6, 8,1 };

        Assert.AreEqual("X X 4/81", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T10Bowl()
    {
        List<int> scoreList = new List<int>() { 8, 2, 7, 3, 3, 4, 1, 1, 2, 8, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };

        Assert.AreEqual("8/7/34112/11111111X 5", ScoreDisplay.FormatRolls(scoreList));
    }

    [Test]
    public void T11Bowl()
    {
        List<int> scoreList = new List<int>() { 8, 2, 7, 3, 3, 4, 1, 1, 2, 8, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 };

        Assert.AreEqual("8/7/34112/11111111X X ", ScoreDisplay.FormatRolls(scoreList));
    }
}
