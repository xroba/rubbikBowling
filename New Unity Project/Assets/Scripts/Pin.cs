using UnityEngine;
using System.Collections;


public class Pin : MonoBehaviour {
	private Vector3 euler;
	bool currentStanding = true;
	private Rigidbody rigidBody;

	public float angleLimitThreshold = 3f;
	float distanceToRaise = 45f;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsStanding(){
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



	public void RaiseIfStanding(){
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distanceToRaise, 0), Space.World);
			transform.rotation = Quaternion.Euler (270f, 0, 0);
		}
	}

	public void Lower(){
		Vector3 downPosition = new Vector3 (0, -distanceToRaise, 0);
		GetComponent<Rigidbody>().useGravity = true;
		transform.Translate(downPosition);
	}

	public void Reset(){
		transform.rotation = Quaternion.identity;
	}

	void OnTriggerExit(Collider other){
		if(other.GetComponent<PinSetter>()){

	//		Debug.Log("Destoy Pin on trigger Exit" + other.transform.position);

			Destroy(this.gameObject);
		}
	}
}
