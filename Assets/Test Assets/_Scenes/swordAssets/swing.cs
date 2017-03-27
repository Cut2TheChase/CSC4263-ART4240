using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour {

	public float swingTime;
	public float swingSpeed;
	HingeJoint2D hinge;
	JointMotor2D jointMotor;
	private bool swung = false;
	public float swingDelay;

	void Start () {
		hinge = gameObject.GetComponent<HingeJoint2D>();	
		jointMotor = hinge.motor;
		jointMotor.motorSpeed = -2000;
		swingDelay = swingTime + 0.2F;


	}
	IEnumerator ExecuteTime(float time)
	{
		yield return new WaitForSeconds(time);
		jointMotor.motorSpeed = -2000; 


	}
	IEnumerator DelayInput(float time)
	{
		yield return new WaitForSeconds(time);
		swung = false; 


	}
	void Update () {
		if (Input.GetKey (KeyCode.Y)) 
		{
			if (swung == false) {	
				jointMotor.motorSpeed = swingSpeed;
				StartCoroutine (ExecuteTime (swingTime));
				swung = true;
				StartCoroutine (DelayInput (swingDelay));
			}



		} 

		hinge.motor = jointMotor;
	}
}
