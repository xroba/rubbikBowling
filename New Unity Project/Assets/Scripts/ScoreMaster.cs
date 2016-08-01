using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {
	
	List<int> scoreFrameList = new List<int>();
	int tmpValue = 0;
	int i = 0;

	public List<int> RetrieveScoreFromScoreMasterByList (List<int> pinFallList)
	{

		//still do not have a min of 2 balls
		if (pinFallList.Count / 2 < 1) {
			return null;
		}

		foreach(int pinFall in pinFallList){


				Debug.Log("ici I " + i);
				//allways work by pair
				tmpValue += pinFall;
				i++;

				if(i > 1){ //second ball of the frame
					scoreFrameList.Add(tmpValue);
					i = 0;
					tmpValue = 0;
				}
		}



		return scoreFrameList;

	}

}
