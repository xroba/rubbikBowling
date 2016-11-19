using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {
	
	List<int> scoreFrameList = new List<int>();
	public int ballNumber = 1;
	int tmpScore = 0;
	int TotalScore = 0;
	int ballNotArray0 = 0;


	public List<int> RetrieveScoreFromScoreMasterByList (List<int> pinFallList)
	{

		Debug.Log ("bn " + ballNumber + " for " + pinFallList.Count);
		//still do not have a min of 2 balls OR be sure that the ball number that is the array position can be found on the array of pinFallList
		if (pinFallList.Count / 2 < 1 || (ballNumber > pinFallList.Count)) {
			Debug.Log ("NOT HAVE MIN 2 BALL");
			return null;
		}

		foreach (int pinFall in pinFallList) {

			//allways work by pair
			//ballonframe
			Debug.Log ("bn " + ballNumber + " = " + pinFall);

			if (ballNumber % 2 > 0) { //first ball of the frame
				if (pinFall == 10) { //strike
					Debug.Log ("Strike");
					//TotalScore += 10;
					//when strike need to have the 2 next ball in order to be able to 
					if (pinFallList.Count >= ballNumber + 2) {

						TotalScore += Strike (ballNumber, pinFallList);
						//check if second strike
						Debug.Log ("first strike");
						Debug.Log (pinFallList [ballNumber+1]);
						//SECOND STRIKE
						if (pinFallList.Count > ballNumber+1  && pinFallList [ballNumber+1] == 10) {
							Debug.Log ("second strike");
							TotalScore += Strike(ballNumber+1, pinFallList);

							if (pinFallList.Count > ballNumber+2  && pinFallList [ballNumber+2] == 10) {
							Debug.Log ("Third strike");
							TotalScore += Strike(ballNumber+1, pinFallList);

							}

						}



						ballNumber += 2;





					} else {
						TotalScore = 10;
					}

					Debug.Log("TotalScore = " + TotalScore);


					Debug.Log ("A");
					Debug.Log ("PinFallCount = " + pinFallList.Count);
					Debug.Log ("my pinfallList[ballnumber]" + pinFallList [ballNumber-1]);

					//check score of the next frame 
					//1 check that we have at least 2 balls after the strike in order to count it
					//


					//check if have the next ball and if next ball is a strike 
		/*			if (pinFallList.Count > ballNumber  && pinFallList [ballNumber] == 10) {
						Debug.Log ("B");


						//Debug.Log("BallNumber Str= " + ballNumber);
					 	TotalScore += 10;
						Debug.Log("TotalScore 2nd Str = " + TotalScore);
					 	//let's check if we have a Third Strike and of course if next ball is available
						if (pinFallList.Count > ballNumber-2 && pinFallList [ballNumber-2] == 10) {
							Debug.Log ("C");
							ballNumber += 2;
					 		TotalScore += 10;
							}
						} 
		*/
						
						scoreFrameList.Add(TotalScore);


/*					if ( (pinFallList.Count > ballNumber) && (pinFallList.Count > ballNumber + 1) && pinFallList [ballNumber] < 10) {
						Debug.Log("count = " + pinFallList.Count);
						Debug.Log("B = " + pinFallList[ballNumber]);
						TotalScore =  pinFallList[ballNumber] + pinFallList[ballNumber + 1] + pinFall;
						scoreFrameList.Add(TotalScore);
						ballNumber++;
					} else if (pinFallList [ballNumber] == 10 && pinFallList.Count > ballNumber + 2 && pinFallList [ballNumber + 1] < 10 && pinFallList [ballNumber+2] < 10) { //second strike 
						TotalScore =  pinFallList[ballNumber+1] + pinFallList[ballNumber + 2] + pinFall;
						scoreFrameList.Add(TotalScore);
						ballNumber++;
					} else if (pinFallList [ballNumber+1] == 10 && pinFallList.Count > ballNumber + 3 && pinFallList [ballNumber + 2] < 10) { //third strike 
						TotalScore =  pinFallList[ballNumber+2] + pinFallList[ballNumber + 3] + pinFall;
						scoreFrameList.Add(TotalScore);
						ballNumber++;
		
					} else {
						Debug.Log("C");
						ballNumber = ballNumber + 1;
					}
					*/
					//Debug.Log("nononono = " + ballNumber);

				} else { //not strike
					Debug.Log("D");
					Debug.Log(pinFall);
					tmpScore = pinFall;
					ballNumber++;
				}


			} else { //second ball of the frame
				ballNumber++;
				tmpScore = tmpScore + pinFall;
				Debug.Log("E");
				if (tmpScore == 10) { //par

				} else {
					TotalScore = tmpScore + TotalScore;
					scoreFrameList.Add (TotalScore);
					//tmpScore = 0;
				}



			}



		}



		return scoreFrameList;

	}

	public int Strike (int ballNumber, List<int> pinfallList )
	{
			TotalScore = 10 + pinfallList[ballNumber] + pinfallList[ballNumber + 1];
			return TotalScore;
	}

}
