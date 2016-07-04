using UnityEngine;
using System.Collections;


public class Pin : MonoBehaviour {
	private Vector3 euler;
	bool currentStanding = true;

	public float angleLimitThreshold = 3f;
	public bool isImmune = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isStanding();
	}

	public bool isStanding(){

		if(currentStanding == true){

			float tiltx = Mathf.Abs(transform.eulerAngles.x);
			float tilty = Mathf.Abs(transform.eulerAngles.y);

			if( (tiltx > angleLimitThreshold) && (tilty > angleLimitThreshold)){
				currentStanding = false;
				return false;
			}

			return true;
		}
			
		return false;
	}

	void OnTriggerExit(Collider other){
		if(other.GetComponent<PinSetter>() && !isImmune){

			Debug.Log("Destoy Pin on trigger Exit" + other.transform.position);

			Destroy(this.gameObject);
		}
	}
}
