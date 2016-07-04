using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject ball;
	Camera myCamera;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		myCamera = Camera.main;
		offset = myCamera.transform.position - ball.transform.position;
		//Debug.Log(offset);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (ball && ball.transform.position.z < 1800) {

			myCamera.transform.position = ball.transform.position + offset;

		} else {
			//myCamera.transform.position = ball.transform.position + offset;
		}


	}
}
