using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPull : MonoBehaviour {

	public GameObject player;
	[HideInInspector]
	public Transform target;
	public float dirNum;

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
		target= player.transform;

	}



	void OnMouseDown()
	{
		if (player.GetComponent<itemEquip> ().rod == true) {	
			isHooked = true;
			player.GetComponent<playerMovement> ().notHooked = false;
		}

	}

	void Update () 
	{
		target= player.transform;
		Vector3 heading = target.position - transform.position;
		dirNum = AngleDir(transform.forward, heading, transform.up);



		if (isHooked == true) 
		{
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
			{
				if (dirNum == -1) {	
					sliderMotor.motorSpeed = thrustSpeed;
				}
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
			{
				if (dirNum == 1) {	
					sliderMotor.motorSpeed = -thrustSpeed;
				}
			}
		}

		if (Input.GetKey (KeyCode.Q) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Y))
			{
				isHooked = false;
			player.GetComponent<playerMovement> ().notHooked = true;
			}

		slider.motor = sliderMotor;
	}



	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);

		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}


}
