using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	List<int> pinsList;
	List<int> scoreList;
	ActionMaster _actionMaster = new ActionMaster();
	PinSetter pinSetter;
	Ball ball;


	// Use this for initialization
	void Start () {
	 	pinsList = new List<int>();
		pinSetter = FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PinFall(int pinFall){
		if(pinFall < 0 || pinFall > 10){
			throw new UnityException("Invalid Pins Value");
		}
			pinsList.Add(pinFall);
			ActionMaster.Action mAction = RetrieveActionFromActionMasterByList(pinsList);

			//send this Action to the the PinSetter/animator
			pinSetter.PinsHaveSettled(mAction);

			//Ball Reset
			ball.Reset();
	}

	public ActionMaster.Action RetrieveActionFromActionMasterByList(List<int> pinsList){
		return _actionMaster.PinFalls(pinsList); 	
	}
}
