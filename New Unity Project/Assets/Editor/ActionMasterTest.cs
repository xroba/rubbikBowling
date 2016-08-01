using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ActionMasterTest {

	ActionMaster _actionMaster;
	ActionMaster.Action endTurn;
	ActionMaster.Action tidy;
	ActionMaster.Action reset;
	ActionMaster.Action endGame;

	public ActionMasterTest(){
		endTurn = ActionMaster.Action.EndTurn;
		tidy = ActionMaster.Action.Tidy;
		reset = ActionMaster.Action.Reset;
		endGame = ActionMaster.Action.EndGame;
	}

	//
	//Action endturn = _scoreMaster. 
	//ScoreMaster.Action endturn = ScoreMaster.Action.EndTurn;
	[SetUp]
	public void Setup(){
		_actionMaster = new ActionMaster();
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
		List<int> pinFalls =  new List<int>(){10};
		Assert.AreEqual(endTurn,_actionMaster.PinFalls(pinFalls));
	}

	[Test]
	public void T02Bow8ReturnsTidy(){
		List<int> pinFalls =  new List<int>(){8};
		Assert.AreEqual(tidy,_actionMaster.PinFalls(pinFalls));
	}

	[Test]
	public void T03Bowl2_8Spare_ReturnEndTurn(){
		List<int> pinFalls =  new List<int>(){8,2};
		Assert.AreEqual(endTurn,_actionMaster.PinFalls(pinFalls));
	}

		[Test]
		public void T09FirstBall_ReturnIsFirstRollonTurnTrue(){
			List<int> pinFalls =  new List<int>(){1};
			_actionMaster.PinFalls(pinFalls);
			Assert.AreEqual(true,_actionMaster.isFirstRollFromCurrentTurn());
		}

		[Test]
		public void T10SecondBall5_ReturnIsFirstRollonTurnShouldBeFalse(){
			List<int> pinFalls =  new List<int>(){5,3};
			_actionMaster.PinFalls(pinFalls);
			Assert.AreEqual(false,_actionMaster.isFirstRollFromCurrentTurn());
		}

		[Test]
		public void T11ThirdBall5_ReturnIsFirstRollonTurnShouldBeTrue(){
			List<int> pinFalls =  new List<int>(){5,5,5};
			_actionMaster.PinFalls(pinFalls);
			Assert.AreEqual(true,_actionMaster.isFirstRollFromCurrentTurn());
		}

		[Test]
		public void T12SecondBallStrike_ReturnIsFirstRollonTurnShouldBeFalse(){
			List<int> pinFalls =  new List<int>(){0,10};
			_actionMaster.PinFalls(pinFalls);
			Assert.AreEqual(false,_actionMaster.isFirstRollFromCurrentTurn());
		}

		[Test]
		public void T13CheckResetAtStrikeInLastFrame(){
			
			List<int> pinFalls =  new List<int>(){1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10};

		Assert.AreEqual(reset,_actionMaster.PinFalls(pinFalls));

		}

		[Test]
		public void T14Checkball21ReturnEndGame(){
			List<int> pinFalls =  new List<int>(){8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2,9};
			Assert.AreEqual(endGame,_actionMaster.PinFalls(pinFalls));
		}

		[Test]
		public void T15Checkball20ReturnEndGameifnoReward21(){
			List<int> pinFalls =  new List<int>(){8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,1};
			Assert.AreEqual(endGame,_actionMaster.PinFalls(pinFalls));
		}

		[Test]
		public void T16Checkball19AtStrikeAndNotHitAllTheBallOn20ReturnTidy(){
			List<int> pinFalls =  new List<int>(){8,2, 7,3, 3,4, 1,1, 2,8, 1,1, 1,1, 1,1, 1,1, 10,5};
			Assert.AreEqual(tidy,_actionMaster.PinFalls(pinFalls));
		}


		[Test]
		public void T18TwoStrikelastFrameReturnReset(){
			List<int> pinFalls =  new List<int>(){8,2, 7,3, 3,4, 1,1, 2,8, 1,1, 1,1, 1,1, 1,1, 10,10};
			Assert.AreEqual(reset,_actionMaster.PinFalls(pinFalls));
		}


		[Test]
		public void T19Last3ballsAreStrike(){
			List<int> pinFalls =  new List<int>(){1,1, 1,1, 1,1, 1,1, 2,8, 1,1, 1,1, 1,1, 1,1,10,10,10};
			Assert.AreEqual(endGame,_actionMaster.PinFalls(pinFalls));
		}

}
