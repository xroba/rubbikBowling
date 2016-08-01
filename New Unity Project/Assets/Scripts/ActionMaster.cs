using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};
	// Use this for initialization

	private int bowl;
	private int[] bowls;

	private Action actionToReturn;
	private int currentTurn;
	private int currentFrame;



	public Action PinFalls( List<int> pinFallList){

		bowl = 1;
		bowls = new int[21];
		currentTurn = 1;
		currentFrame = 1;


		foreach(int pinFall in pinFallList){
			actionToReturn = Bowl(pinFall);
		}
		 return actionToReturn;
	}

	public Action Bowl(int pins){

		if(pins < 0 || pins > 10){
			throw new UnityException("Invalid Pins Value");
		}
	
		bowls[bowl - 1] = pins;
		Debug.Log("bowl" + bowl);


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

	public int GetCurrentFrame (){
		return currentFrame;
	}


	public bool isFirstRollFromCurrentTurn(){
		
		return GetCurrentFrame() % 2 != 0;
	}

}
