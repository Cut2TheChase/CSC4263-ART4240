using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPull : MonoBehaviour {

	public int thrustSpeed;
	SliderJoint2D slider;
	JointMotor2D sliderMotor;
	[HideInInspector]
	public bool isHooked;

	void Start () 
	{
		slider = gameObject.GetComponent<SliderJoint2D>();	
		sliderMotor = slider.motor;
		//isHooked = true;

	}



	void OnMouseDown()
	{
		isHooked = true;
	}

	void Update () 
	{

		if (isHooked == true) 
		{
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
			{
				sliderMotor.motorSpeed = thrustSpeed;
			}
		}

		slider.motor = sliderMotor;
	}
}
