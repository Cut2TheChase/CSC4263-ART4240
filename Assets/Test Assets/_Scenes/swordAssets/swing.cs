using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour {

	public float swingTime;
	public float swingSpeed;
	public float retSpeed;
	HingeJoint2D hinge;
	JointMotor2D jointMotor;
	public bool swung = false;
	public float swingDelay;
	public bool active;

	private GameObject player;

	void Start () {
		hinge = gameObject.GetComponent<HingeJoint2D>();	
		jointMotor = hinge.motor;
		jointMotor.motorSpeed = retSpeed;
		swingDelay = swingTime + 0.2F;

		player = GameObject.FindGameObjectWithTag ("Player");

	}
	IEnumerator ExecuteTime(float time)
	{
		yield return new WaitForSeconds(time);
		jointMotor.motorSpeed = retSpeed; 


	}
	IEnumerator DelayInput(float time)
	{
		yield return new WaitForSeconds(time);
		swung = false; 

	}
	void Update () {
		if (Input.GetKey (KeyCode.Y)&& active == true) 
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
