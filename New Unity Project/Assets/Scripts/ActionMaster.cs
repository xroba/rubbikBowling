using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};
	// Use this for initialization

	private int bowl =1 ;
	private int[] bowls = new int[21];

	//private Action actionToReturn;
	private int currentTurn;
	public static int currentFrame;

	static public Action NextAction(List<int> pinFallList){

		ActionMaster am = new ActionMaster();
		Action currentAction = new Action();

		Debug.Log("PINFALLLIST = " + pinFallList);

		foreach(int pinFall in pinFallList){
			Debug.Log("PINFALL = " + pinFall);

			currentAction = am.Bowl(pinFall);
		}
		
		return currentAction;
	}


	private Action Bowl(int pins){

		if(pins < 0 || pins > 10){
			throw new UnityException("Invalid Pins Value");
		}
	
		bowls[bowl - 1] = pins;
		//Debug.Log("bowl" + bowl);


		if(bowl == 21 || (bowl == 20 && !bowl21Awarded()) ){
			return Action.EndGame;
		}



		currentFrame = bowl;

		if(bowl >= 19 && bowl21Awarded()){
		bowl++;

			if(pins < 10){
				return Action.Tidy;
			} else {
				return Action.Reset;
			}

		

		}


		//update last Frame if it was a strike or a Spare.

		if(bowl % 2 != 0){ //First bowl of frame
			if(pins == 10){ //first bowl of frame is a strike
				bowl += 2;
				currentTurn++;
				return Action.EndTurn;
			} else { //not a strike
				bowl += 1;
				return Action.Tidy;
			}


		} else if (bowl % 2 == 0){ //Second bowl of frame
			bowl += 1;
			currentTurn++;
			return Action.EndTurn;
		}

		throw new UnityException("I do not know the action to Return");
	}

	private bool bowl21Awarded(){
		int total = bowls[19-1] + bowls[20-1];

		return total >= 10;
	}

	static public int GetCurrentFrame (){
		return currentFrame;
	}


	static public bool isFirstRollFromCurrentTurn(){
		
		return GetCurrentFrame() % 2 != 0;
	}

}
