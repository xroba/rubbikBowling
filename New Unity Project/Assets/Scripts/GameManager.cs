using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	List<int> bowls;
	List<int> scoreList;
	PinSetter pinSetter;
	Ball ball;
    ScoreDisplay scoreDislay;


	// Use this for initialization
	void Start () {
	 	bowls = new List<int>();
		pinSetter = FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<Ball>();
        scoreDislay = FindObjectOfType<ScoreDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bowl(int pinFall){
		if(pinFall < 0 || pinFall > 10){
			throw new UnityException("Invalid Pins Value");
		}
        try
        {
            //Ball Reset
            ball.Reset();
            bowls.Add(pinFall);
            //send this Action to the the PinSetter/animator
            pinSetter.PerformAction(ActionMaster.NextAction(bowls));
        } catch
        {
            Debug.Log("ERROR ON TRY ");
        }
           

            List<int> scoreFrame = ScoreMaster.ScoreFrames(bowls);
            List<int> scoreCumulative = ScoreMaster.ScoreCumulative(bowls);

        try
        {
            //updateScore
            scoreDislay.FillRolls(bowls);
            scoreDislay.FillFrames(scoreCumulative);
        } catch
        {
            Debug.Log("erreur");
        }
        


	}

}
