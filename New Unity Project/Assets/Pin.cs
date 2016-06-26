using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
	private Vector3 euler;
	public float angleLimitThreshold = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isStanding();
	}

	public bool isStanding(){

		float tiltx = Mathf.Abs(transform.eulerAngles.x);
		float tilty = Mathf.Abs(transform.eulerAngles.y);

		if( (tiltx > angleLimitThreshold) && (tilty > angleLimitThreshold)){
			return false;
		}
		return true;
	}
}
