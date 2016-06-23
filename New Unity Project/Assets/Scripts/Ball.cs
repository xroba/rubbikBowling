using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	Rigidbody rigidbody;
	AudioSource audiosource;
	public Vector3 launchVelocity;
	public bool isLaunch;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		audiosource = GetComponent<AudioSource>();
		rigidbody.useGravity = false;
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


}



