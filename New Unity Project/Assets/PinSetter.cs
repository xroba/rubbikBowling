using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	Pin[] ArrPins;
	int numberOfPin;
	public GameObject UILeftPanelCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//allways count pin standing

		numberOfPin = CountNumberOfStandingPins();

		//update left Panel Text
		UILeftPanelCount.GetComponent<Text>().text = numberOfPin.ToString();

	}

	private int CountNumberOfStandingPins(){

		//retrieve allPins
		ArrPins = retrieveAllPin();

		numberOfPin = 0;
		foreach(Pin mpin in ArrPins){
			if(mpin.isStanding()){
				numberOfPin++;
			}

		}

		return numberOfPin;
	}

	private Pin[] retrieveAllPin(){
		return FindObjectsOfType<Pin>();
	}


}
