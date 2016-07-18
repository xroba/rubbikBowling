using UnityEngine;
using System.Collections;

public class ScoreMaster : MonoBehaviour {

	public enum Action {Tidy, Reset, EndTurn, EndGame};
	// Use this for initialization

	private int bowl = 1;
	private int[] bowls = new int[21];
	private int[] ScoreByTurn = new int[9];
	private int currentTurn = 1;
	private int currentFrame = 1;
	private int score = 0;
	private bool LastShotIsStrike = false;

	public Action Bowl(int pins){

		if(pins < 0 || pins > 10){
			throw new UnityException("Invalid Pins Value");
		}
	
		bowls[bowl - 1] = pins;



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


		//strike
/*		if(pins == 10 && isFirstRollFromCurrentTurn()){
			bowl += 2;
			currentTurn++;
			LastShotIsStrike = true;
			return Action.EndTurn;
		}
*/
		if(bowl % 2 != 0){ //First bowl of frame
			if(pins == 10){ //first bowl of frame is a strike
				bowl += 2;
				currentTurn++;
				return Action.EndTurn;
			} else { //not a strike
				bowl += 1;
				score += pins;
				return Action.Tidy;
			}


		} else if (bowl % 2 == 0){ //Second bowl of frame
			bowl += 1;
			score += pins;
			currentTurn++;
			return Action.EndTurn;
		}

		throw new UnityException("I do not know the action to Return");
	}

	private bool bowl21Awarded(){
		int total = bowls[19-1] + bowls[20-1];

		return total >= 10;
	}

	public int GetCurrentScore(){
		return score;
	}

	public int GetCurrentFrame (){
		return currentFrame;
	}

	public int GetTurn(){
		return currentTurn;
	}

	public bool isFirstRollFromCurrentTurn(){
		
		return GetCurrentFrame() % 2 != 0;
	}

}
