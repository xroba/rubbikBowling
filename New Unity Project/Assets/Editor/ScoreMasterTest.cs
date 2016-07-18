using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

public class ScoreMasterTest {

	ScoreMaster _scoreMaster;
	ScoreMaster.Action endTurn;
	ScoreMaster.Action tidy;
	ScoreMaster.Action reset;
	ScoreMaster.Action endGame;

	public ScoreMasterTest(){
		endTurn = ScoreMaster.Action.EndTurn;
		tidy = ScoreMaster.Action.Tidy;
		reset = ScoreMaster.Action.Reset;
		endGame = ScoreMaster.Action.EndGame;
	}

	//
	//Action endturn = _scoreMaster. 
	//ScoreMaster.Action endturn = ScoreMaster.Action.EndTurn;
	[SetUp]
	public void Setup(){
		_scoreMaster = new ScoreMaster();
	}

	[Test]
	public void EditorTest()
	{
		//Arrange
		var gameObject = new GameObject();

		//Act
		//Try to rename the GameObject
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;

		//Assert
		//The object has a new name
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}

	[Test]
	public void PassingTest(){
		Assert.AreEqual(1,1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn(){
		Assert.AreEqual(endTurn,_scoreMaster.Bowl(10));
	}

	[Test]
	public void T02Bow8ReturnsTidy(){
		Assert.AreEqual(tidy,_scoreMaster.Bowl(8));
	}

	[Test]
	public void T03Bowl2_8Spare_ReturnEndTurn(){
		_scoreMaster.Bowl(2);
		Assert.AreEqual(endTurn,_scoreMaster.Bowl(8));
	}

	[Test]
	public void T04FirstBowl6_returnScore6(){
		_scoreMaster.Bowl(6);
		Assert.AreEqual(6,_scoreMaster.GetCurrentScore());
	}

	[Test]
	public void T05FirstBowl6AndSecondBowl3_returnScore9(){
		_scoreMaster.Bowl(6);
		_scoreMaster.Bowl(3);
		Assert.AreEqual(9,_scoreMaster.GetCurrentScore());
	}

	[Test]
	public void T06FirstBowl_ReturnTurn1(){
		_scoreMaster.Bowl(4);
		Assert.AreEqual(1,_scoreMaster.GetTurn());
	}

	[Test]
	public void T08StrikeOnFirstBall_ReturnTurn2(){
		_scoreMaster.Bowl(10);
		Assert.AreEqual(2,_scoreMaster.GetTurn());
	}

	[Test]
	public void T09FirstBall_ReturnIsFirstRollonTurnTrue(){
		_scoreMaster.Bowl(5);
		Assert.AreEqual(true,_scoreMaster.isFirstRollFromCurrentTurn());
	}

	[Test]
	public void T10SecondBall5_ReturnIsFirstRollonTurnShouldBeFalse(){
		_scoreMaster.Bowl(5);
		_scoreMaster.Bowl(5);
		Assert.AreEqual(false,_scoreMaster.isFirstRollFromCurrentTurn());
	}

	[Test]
	public void T11ThirdBall5_ReturnIsFirstRollonTurnShouldBeTrue(){
		_scoreMaster.Bowl(5);
		_scoreMaster.Bowl(5);
		_scoreMaster.Bowl(5);
		Assert.AreEqual(true,_scoreMaster.isFirstRollFromCurrentTurn());
	}

	[Test]
	public void T12SecondBallStrike_ReturnIsFirstRollonTurnShouldBeFalse(){
		_scoreMaster.Bowl(0);
		_scoreMaster.Bowl(10);
		Assert.AreEqual(false,_scoreMaster.isFirstRollFromCurrentTurn());
	}

	[Test]
	public void T13CheckResetAtStrikeInLastFrame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};

		foreach(int roll in rolls){
			_scoreMaster.Bowl(roll);
		}
		//_scoreMaster.Bowl(9);
		Assert.AreEqual(reset,_scoreMaster.Bowl(10));

	}

	[Test]
	public void T14Checkball21ReturnEndGame(){
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2 };

		foreach(int roll in rolls){
			_scoreMaster.Bowl(roll);
		}
	
		Assert.AreEqual(endGame,_scoreMaster.Bowl(9));

	}

	[Test]
	public void T15Checkball20ReturnEndGameifnoReward21(){
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8 };
		foreach(int roll in rolls){
			_scoreMaster.Bowl(roll);
		}

		Assert.AreEqual(endGame,_scoreMaster.Bowl(1));
	}

	[Test]
	public void T16Checkball19AtStrikeAndNotHitAllTheBallOn20ReturnTidy(){
		int[] rolls = {8,2, 7,3, 3,4, 1,1, 2,8, 1,1, 1,1, 1,1, 1,1, 10};

		foreach(int roll in rolls){
			_scoreMaster.Bowl(roll);
		}
	
		Assert.AreEqual(tidy,_scoreMaster.Bowl(5));

	}

	[Test]
	public void T17Checkball19AtStrikeAndNotHitAllTheBallOn20ReturnTidy(){
		int[] rolls = {8,2, 7,3, 3,4, 1,1, 2,8, 1,1, 1,1, 1,1, 1,1, 10};

		foreach(int roll in rolls){
			_scoreMaster.Bowl(roll);
		}
	
		Assert.AreEqual(tidy,_scoreMaster.Bowl(0));

	}

	[Test]
	public void T18TwoStrikelastFrameReturnReset(){
		int[] rolls = {8,2, 7,3, 3,4, 1,1, 2,8, 1,1, 1,1, 1,1, 1,1, 10};

		foreach(int roll in rolls){
			_scoreMaster.Bowl(roll);
		}
	
		Assert.AreEqual(reset,_scoreMaster.Bowl(10));

	}

	[Test]
	public void T19Last3ballsAreStrike(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 2,8, 1,1, 1,1, 1,1, 1,1};

		foreach(int roll in rolls){
			_scoreMaster.Bowl(roll);
		}
	
		Assert.AreEqual(reset,_scoreMaster.Bowl(10));
		Assert.AreEqual(reset,_scoreMaster.Bowl(10));
		Assert.AreEqual(endGame,_scoreMaster.Bowl(10));

	}

}
