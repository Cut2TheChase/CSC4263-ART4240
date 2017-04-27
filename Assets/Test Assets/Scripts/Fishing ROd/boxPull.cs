using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPull : MonoBehaviour {

	public GameObject player;
	[HideInInspector]
	public Transform target;
	public float dirNum;
	[HideInInspector]
	public bool pulled;

	public int thrustSpeed;
	SliderJoint2D slider;
	JointMotor2D sliderMotor;
	//[HideInInspector]
	public bool isHooked;

	private Vector3 prevPos; //holds previous position

	void Start () 
	{
		slider = gameObject.GetComponent<SliderJoint2D>();	
		sliderMotor = slider.motor;
		//isHooked = true;
		target= player.transform;

	}


	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		//wisHooked = true;
		pulled = true;

	}
	void OnMouseDown()
	{
		if (player.GetComponent<itemEquip> ().rod == true) {	
			isHooked = true;
			//StartCoroutine(ExecuteAfterTime(.3f));
			player.GetComponent<Animator> ().SetInteger ("State", 5);
			player.GetComponent<Animator> ().SetBool ("hookDone", false);
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
			if (Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.LeftArrow)) 
			{
				if (dirNum == -1) {	
					sliderMotor.motorSpeed = thrustSpeed;
				}

			}
			if (Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.RightArrow)) 
			{
				if (dirNum == 1) {	
					sliderMotor.motorSpeed = -thrustSpeed;
				}
			}



			//pulled = true;
			//if (Input.GetMouseButtonDown (0) && pulled == true) {
			//	isHooked = false;
			//	player.GetComponent<playerMovement> ().notHooked = true;
			//
			//	player.GetComponent<Animator> ().SetBool ("hookDone", true);
			//
			//	pulled = false;
			//}
			StartCoroutine (ExecuteAfterTime (.4f));


		}

		if (Input.GetKey (KeyCode.Q) || Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.E) && pulled ==true) )
			{
				isHooked = false;
			player.GetComponent<playerMovement> ().notHooked = true;

			pulled = false;
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
