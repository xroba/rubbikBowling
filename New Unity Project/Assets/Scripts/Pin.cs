using UnityEngine;
using System.Collections;


public class Pin : MonoBehaviour {
	private Vector3 euler;
	bool currentStanding = true;

	public float angleLimitThreshold = 3f;
	float distanceToRaise = 45f;
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

	public void Raise(){
		Vector3 upPosition = new Vector3 (0, distanceToRaise, 0);
		GetComponent<Rigidbody>().useGravity = false;
		transform.Translate(upPosition);
	}

	public void Lower(){
		Vector3 downPosition = new Vector3 (0, -distanceToRaise, 0);
		GetComponent<Rigidbody>().useGravity = true;
		transform.Translate(downPosition);
	}

	void OnTriggerExit(Collider other){
		if(other.GetComponent<PinSetter>()){

	//		Debug.Log("Destoy Pin on trigger Exit" + other.transform.position);

			Destroy(this.gameObject);
		}
	}
}
