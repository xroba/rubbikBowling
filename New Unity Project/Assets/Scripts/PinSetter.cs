using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {


	Animator animator;
	public GameObject defaultPins;
	LaneBox laneBox;


	List<Pin> listUpPins;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		laneBox = FindObjectOfType<LaneBox>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PinsHaveSettled(ActionMaster.Action mAction){
		listUpPins = laneBox.listUpPins;
		Debug.Log("mAction: " + mAction);

		if(mAction == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		}
		else if(mAction == ActionMaster.Action.Reset) {
			animator.SetTrigger("resetTrigger");
			laneBox.lastSettledCount = 10;
		} 
		else if(mAction == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			laneBox.lastSettledCount = 10;
		}
		else if(mAction == ActionMaster.Action.EndGame) {
			throw new UnityException("sqoi END GAME");
		} 



//		ball.Reset();
//		SetBallLeftBox(false);

      

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
