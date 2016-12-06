using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	Rigidbody rigidbody;
	AudioSource audiosource;
	Vector3 startBallPosition;

	public Vector3 launchVelocity;
	public bool isLaunch;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		audiosource = GetComponent<AudioSource>();
		rigidbody.useGravity = false;
		startBallPosition = transform.position;
	}

	
	// Update is called once per frame
	void Update () {

		
	}

	public void Launch(Vector3 mvelocity){
		if(!isLaunch){
			isLaunch = true;
			rigidbody.useGravity = true;
			rigidbody.velocity = mvelocity;
		}

	}


	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.tag == "Floor"){
			audiosource.Play();
		}
	}

	public void Reset(){
		this.transform.position = startBallPosition;
		rigidbody.useGravity = false;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.Sleep();
		transform.rotation = Quaternion.identity;
		isLaunch = false;
	}

}



