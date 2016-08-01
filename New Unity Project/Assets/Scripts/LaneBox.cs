using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class LaneBox : MonoBehaviour {

	Ball ball;
	Pin[] ArrPins;

	Text standingDisplay;
	float lastChangeTime;
	float speedPinRaiseAndDown = 5f;
	int pinFall;
	int lastStandingCount = -1;
	bool ballLeftBox;
	GameManager gameManager;


	public GameObject UILeftPanelCount;
	public int lastSettledCount = 10;
	public List<Pin> listUpPins;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball>();
		standingDisplay = UILeftPanelCount.GetComponent<Text>();
		gameManager = FindObjectOfType<GameManager>();

	}

	void Update(){

		//allways count pin standing
		standingDisplay.text = CountStanding().ToString();

		if(ballLeftBox){
			//update left Panel Text
			standingDisplay.color = Color.red;
			UpdateStandingCountAndSettle();
		} 
	}

	public void SetBallLeftBox(bool value){
		ballLeftBox = value;
	}



	public void OnTriggerExit(Collider other){
		if(other.GetComponent<Ball>()){
			this.SetBallLeftBox(true);
		}
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

	void UpdateStandingCountAndSettle(){
		
		int currentStanding = CountStanding();

		if(currentStanding != lastStandingCount){
			standingDisplay.color = Color.red;
			lastStandingCount = currentStanding;
			lastChangeTime = Time.time;
			return;
		}

		float limitThresholdInSec = 3f;

		if( (Time.time - lastChangeTime) > limitThresholdInSec){
			SendFallingPinsToGameManager();
		}
	}


	void SendFallingPinsToGameManager(){
			int standing = CountStanding();
			pinFall = lastSettledCount - standing;
			lastSettledCount = standing;

			gameManager.PinFall(pinFall);

			lastStandingCount = -1;
			SetBallLeftBox(false);
			standingDisplay.color = Color.green;
	}

}
