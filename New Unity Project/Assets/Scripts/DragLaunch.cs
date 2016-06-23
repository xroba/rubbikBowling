using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	Ball ball;
	Vector3 mouseStartPos;
	Vector3 mouseEndPos;
	float mStartTime;
	float mEndTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void DragStart(){
		mouseStartPos = Input.mousePosition;
		mStartTime = Time.time; 



	}	

	public void DragEnd(){
		mouseEndPos = Input.mousePosition;
		mEndTime = Time.time;

		//Vector3 Resultante = mouseStartPos + mouseEndPos;
		Vector3 Resultante = mouseEndPos - mouseStartPos;
		float TimeToLaunch = mEndTime - mStartTime;

		Debug.Log("Time = " + TimeToLaunch);

		Vector3 nVelocity = new Vector3(Resultante.x,0,Resultante.y/TimeToLaunch);

		Debug.Log("Vel =" + nVelocity);

		//so y Axe will correspond to the Z in 3D 
		ball.Launch(nVelocity);

	}

	public void MoveStar(float xNudge){
		//move the Ball 
		if(!ball.isLaunch){

			Vector3 currentPos = ball.transform.position;

			float xValueNew = currentPos.x + xNudge;
			float clampValueX = Mathf.Clamp(xValueNew,-50,50);

			ball.transform.Translate(new Vector3 (clampValueX,0,0));



		//	float clampValueX = Mathf.Clamp(xValueNew,-50,50);
			//Vector3 newPosition = new Vector3(clampValueX,0,0);

		//	Vector3 newPosition = new Vector3(clampValueX,currentPos.y,currentPos.z);

		//	ball.transform.position = currentPos + newPosition;
		}

	}
}
