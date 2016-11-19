using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PinCounter : MonoBehaviour {

	public Text standingDisplay;

	private GameManager gameManager;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;
	private Pin[] ArrPins;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();

		if(ballOutOfPlay){
			//update left Panel Text

			UpdateStandingCountAndSettle();
			standingDisplay.color = Color.red;
		} 

	}

	private int CountStanding(){
		//retrieve allPins
		ArrPins = retrieveAllPin();
		int standing = 0;
		foreach(Pin mpin in ArrPins){
			if(mpin.IsStanding()){
				standing++;
			}
		}
		Debug.Log("STANDING " + standing);
		return standing;
	}

	private Pin[] retrieveAllPin(){
		return FindObjectsOfType<Pin>();
	}


	public void UpdateStandingCountAndSettle(){
		
		int currentStanding = CountStanding();

		if(currentStanding != lastStandingCount){
			standingDisplay.color = Color.red;
			lastStandingCount = currentStanding;
			lastChangeTime = Time.time;
			return;
		}

		float limitThresholdInSec = 3f;

		if( (Time.time - lastChangeTime) > limitThresholdInSec){
			PinHaveSettled();
		}
	}


		void PinHaveSettled(){
			int standing = CountStanding();
			int pinFall = lastSettledCount - standing;
			lastSettledCount = standing;

			gameManager.Bowl(pinFall);

			lastStandingCount = -1;
			SetBallLeftBox(false);
			standingDisplay.color = Color.green;
	}

	public void SetBallLeftBox(bool value){
		ballOutOfPlay = value;
	}

	public void Reset(){
		lastSettledCount = 10;
	}


	public void OnTriggerExit(Collider other){
		if(other.GetComponent<Ball>()){
			this.SetBallLeftBox(true);
		}
	}
}
