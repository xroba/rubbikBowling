using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	Pin[] ArrPins;
	Text standingDisplay;
	float lastChangeTime;
	Ball ball;
	List<Pin> listUpPins;
	float speedPinRaiseAndDown = 5f;
	int PinHaveFold;
	ScoreMaster scoreMAster;

	public int lastStandingCount = -1;
	public GameObject UILeftPanelCount;
	public bool ballEnteredBox;
	public GameObject defaultPins;


	// Use this for initialization
	void Start () {
		
		standingDisplay = UILeftPanelCount.GetComponent<Text>();
		ball = FindObjectOfType<Ball>();
		scoreMAster = FindObjectOfType<ScoreMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		//allways count pin standing
		standingDisplay.text = CountStanding().ToString();

		if(ballEnteredBox){
			//update left Panel Text
			UpdateStandingCountAndSettle();
		} 


	}


	void UpdateStandingCountAndSettle(){
		
		int currentStanding = CountStanding();

		if(currentStanding != lastStandingCount){
			standingDisplay.color = Color.red;
			PinHaveFold = lastStandingCount - currentStanding;
			lastStandingCount = currentStanding;
			lastChangeTime = Time.time;
			return;
		}



		float limitThresholdInSec = 3f;

		if( (Time.time - lastChangeTime) > limitThresholdInSec){
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled(){
		ball.Reset();
		ballEnteredBox = false;
		lastStandingCount = -1;
		standingDisplay.color = Color.green;
		scoreMAster.Bowl(PinHaveFold);
	}

	private int CountStanding(){

		listUpPins = new List<Pin>();
		//retrieve allPins
		ArrPins = retrieveAllPin();

		int standing = 0;
		foreach(Pin mpin in ArrPins){
			if(mpin.isStanding()){
				listUpPins.Add(mpin);
				standing++;
			}

		}

		return standing;
	}

	private Pin[] retrieveAllPin(){
		return FindObjectsOfType<Pin>();
	}

	void OnTriggerEnter(Collider other){

		if(other.GetComponent<Ball>()){
			standingDisplay.color = Color.red;
			ballEnteredBox = true;
		}

	}

	public void RaisePins ()
	{
		if (listUpPins.Count > 0) {
			foreach (Pin upPin in listUpPins) {
				upPin.Raise();
			}	
		}
	}

	public void LowerPins ()
	{
		if (listUpPins.Count > 0) {
			foreach (Pin upPin in listUpPins) {
				upPin.Lower();
			}		 
		}
	}

	public void Renew(){
		//first of all delete the pins
		GameObject goPins = GameObject.Find("Pins");

		foreach(Transform child in goPins.transform){
			Destroy(child.gameObject);
		}

		 Instantiate(defaultPins, new Vector3(0,20,1829), Quaternion.identity);
	}


}
