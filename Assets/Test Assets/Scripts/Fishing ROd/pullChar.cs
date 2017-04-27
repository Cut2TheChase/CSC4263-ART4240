using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullChar : MonoBehaviour {

	public GameObject player;
	public float pullForce = 1;
	private GameObject footCollider;

	[HideInInspector]
	public Transform target;
	public float dirNum;
	public float fall = 2;

	public int thrustSpeed;
	SliderJoint2D slider;
	JointMotor2D sliderMotor;
	[HideInInspector]
	public bool isHooked;
	public bool reached_destination;
	//[HideInInspector]
	public bool grapple_click;

	void Start () 
	{
		slider = gameObject.GetComponent<SliderJoint2D>();	
		sliderMotor = slider.motor;
		//isHooked = true;
		target= player.transform;
		reached_destination = false;
		grapple_click = false;

		footCollider = GameObject.FindGameObjectWithTag ("Feet Collider");


	}


	IEnumerator ExecuteForTime(float time)
	{
		reached_destination = true;
		yield return new WaitForSeconds (time);
		player.GetComponent<playerMovement> ().notHooked = true;
		isHooked = false;

	   
//		Vector3 forceDirection = player.transform.position - this.transform.position;
//		float elapsedTime = 0;
	//
//		if (elapsedTime > time) {
//			player.GetComponent<CharacterController> ().Move (forceDirection.normalized * pullForce * Time.fixedDeltaTime);
//		}
	//
//		elapsedTime = Time.deltaTime;
//		yield return new WaitForSeconds(1.0f);
	}


	void OnMouseDown()
	{
		if (player.GetComponent<itemEquip> ().rod == true) {	
			isHooked = true;

			player.GetComponent<Animator> ().SetInteger ("State", 5);
			player.GetComponent<Animator> ().SetBool ("hookDone", false);
			player.GetComponent<playerMovement> ().notHooked = false;

			player.GetComponent<playerMovement> ().notHooked = false;
			reached_destination = false;
		}

	}
	

	void Update () 
	{

		//reached_destination = false;
		Vector3 forceDirection = player.transform.position - this.transform.position;


	
		if (isHooked == true) {
			if (Input.GetKey (KeyCode.E)) {
				
				grapple_click = true;
			}
			if (grapple_click == true) {
				player.GetComponent<CharacterController> ().Move (forceDirection.normalized * pullForce * Time.fixedDeltaTime);
			}

		}
		if (reached_destination == true) {
			footCollider.transform.position = new Vector3 (transform.position.x, transform.position.y - fall, footCollider.transform.position.z);
			player.GetComponent<playerMovement> ().jumpState = true;
			reached_destination = false;
			player.GetComponent<Animator> ().SetBool ("hookDone", true);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//if (other.gameObject.tag == "Player Collider") {
		//Debug.Log("THIS WILL DISPLAY");
		//Debug.Log(other.name);
			grapple_click = false;
		StartCoroutine (ExecuteForTime (0.25f));
		//}
	}


}
