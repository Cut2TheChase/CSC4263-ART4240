using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throttle : MonoBehaviour {

	WheelJoint2D[] wheelJoints;
	JointMotor2D jointMotor;
	public int power;

	void Start () 
	{
		wheelJoints = gameObject.GetComponents<WheelJoint2D> ();
		jointMotor = wheelJoints[0].motor;

	}
	

	void Update () 
	{
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			jointMotor.motorSpeed = -power;

				
		} 
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			jointMotor.motorSpeed = power;
		
		}
		else 
		{
			jointMotor.motorSpeed = 0;

		}
		wheelJoints[0].motor = jointMotor;
	}
}
