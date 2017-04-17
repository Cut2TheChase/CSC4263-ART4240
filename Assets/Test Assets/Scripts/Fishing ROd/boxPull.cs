using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPull : MonoBehaviour {

	public GameObject player;


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
		player.GetComponent<playerMovement> ().notHooked = false;

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

		if (Input.GetKey (KeyCode.Q) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Y))
			{
				isHooked = false;
			player.GetComponent<playerMovement> ().notHooked = true;
			}

		slider.motor = sliderMotor;
	}
}
