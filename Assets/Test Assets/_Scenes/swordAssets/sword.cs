using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {

	WheelJoint2D wheelJoints;
	JointMotor2D jointMotor;
	// Use this for initialization
	void Start () {
		wheelJoints = gameObject.GetComponent<WheelJoint2D>();	
		jointMotor = wheelJoints.motor;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			jointMotor.motorSpeed = -500;


		} 
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			jointMotor.motorSpeed = 1000;

		}
		else 
		{
			jointMotor.motorSpeed = 0;

		}
		wheelJoints.motor = jointMotor;
	}
    
}