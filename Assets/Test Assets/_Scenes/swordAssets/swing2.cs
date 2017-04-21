using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing2 : MonoBehaviour {


	public float thrustTime;
	public int thrustSpeed;
	public int retSpeed;
	SliderJoint2D slider;
	JointMotor2D sliderMotor;
	public bool swung = false;
	public float thrustDelay;
	public swing sword;
	public bool active;

	private GameObject player;

	void Start () {
		

		slider = gameObject.GetComponent<SliderJoint2D>();	
		sliderMotor = slider.motor;
		sliderMotor.motorSpeed = retSpeed;
		thrustDelay = sword.swingDelay;

		player = GameObject.FindGameObjectWithTag ("Player");
	}

	IEnumerator ExecuteTime(float time)
	{
		yield return new WaitForSeconds(time);
		sliderMotor.motorSpeed = retSpeed; 


	}
	IEnumerator DelayInput(float time)
	{
		yield return new WaitForSeconds(time);
		swung = false; 

	}
	void Update () {
		thrustDelay = sword.swingDelay;

		if (Input.GetKey (KeyCode.Y) && active == true) 
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
