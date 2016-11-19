using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour {

	Animator animator;
	public GameObject defaultPins;
	PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		pinCounter = FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PerformAction(ActionMaster.Action mAction){
		if(mAction == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		}
		else if(mAction == ActionMaster.Action.Reset) {
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} 
		else if(mAction == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		}
		else if(mAction == ActionMaster.Action.EndGame) {
			throw new UnityException("sqoi END GAME");
		}   
	}

	public void RaisePins ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding();
		}
	}

	public void LowerPins ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower();
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
