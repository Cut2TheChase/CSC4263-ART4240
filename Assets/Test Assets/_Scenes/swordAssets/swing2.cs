using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing2 : MonoBehaviour {


	public float thrustTime;
	public int thrustSpeed;
	SliderJoint2D slider;
	JointMotor2D sliderMotor;
	private bool swung = false;
	public float thrustDelay;
	public swing sword;

	void Start () {
		

		slider = gameObject.GetComponent<SliderJoint2D>();	
		sliderMotor = slider.motor;
		sliderMotor.motorSpeed = -2000;
		thrustDelay = sword.swingDelay;

	}

	IEnumerator ExecuteTime(float time)
	{
		yield return new WaitForSeconds(time);
		sliderMotor.motorSpeed = -2000; 


	}
	IEnumerator DelayInput(float time)
	{
		yield return new WaitForSeconds(time);
		swung = false; 


	}
	void Update () {
		thrustDelay = sword.swingDelay;

		if (Input.GetKey (KeyCode.Y)) 
		{
			if (swung == false) {
				sliderMotor.motorSpeed = thrustSpeed;
				StartCoroutine (ExecuteTime (thrustTime));
				swung = true;
				StartCoroutine (DelayInput (thrustDelay));
			}
		} 


		slider.motor = sliderMotor;
	}
}
