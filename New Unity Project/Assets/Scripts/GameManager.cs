using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	List<int> bowls;
	List<int> scoreList;
	PinSetter pinSetter;
	Ball ball;




	// Use this for initialization
	void Start () {
	 	bowls = new List<int>();
		pinSetter = FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<Ball>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bowl(int pinFall){
		if(pinFall < 0 || pinFall > 10){
			throw new UnityException("Invalid Pins Value");
		}
			bowls.Add(pinFall);
			//ActionMaster.Action mAction = RetrieveActionFromActionMasterByList(pinsList);
			ActionMaster.Action mAction = ActionMaster.NextAction(bowls);

			//send this Action to the the PinSetter/animator
			pinSetter.PerformAction(mAction);

			//Ball Reset
			ball.Reset();
	}

}
