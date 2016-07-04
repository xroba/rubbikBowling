using UnityEngine;
using System.Collections;

public class RightPanel : MonoBehaviour {

	PinSetter pinSetter;
	Animator pinSetterAnim;


	// Use this for initialization
	void Start () {
		pinSetter = FindObjectOfType<PinSetter>();
		pinSetterAnim = pinSetter.GetComponent<Animator>();
	}
	

	public void TidyBtn(){
		//pinSetter.RaisePins();
		pinSetterAnim.SetTrigger("tidyTrigger");
	}

	public void ResetBtn(){
		pinSetterAnim.SetTrigger("resetTrigger");
	}

}
