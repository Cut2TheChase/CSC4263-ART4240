using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeState2 : MonoBehaviour {
	
	private Vector3 leftInitalPos = new Vector3(-4.05f,1.73f,-1f); //Holds inital position of left hand 
	private Vector3 rightInitalPos = new Vector3(17.33f,1.73f,-1f); //Holds inital position of righthand 
	private GameObject leftHand;
	private GameObject rightHand;
	private GameObject player;

	public int speed;

	private int counter; //how many times must the hand swipe?
	private int leftC; //counter for left hand
	private int rightC; // counter for right hand

	private bool setupL = false; //Says if left hand has set up to swipe player
	private bool resetL = false; //says if left hand needs to reset

	private bool setupR = false; //Says if left hand has set up to swipe player
	private bool resetR = false; //says if left hand needs to reset

	private float leftBound = -6f; //Furthest hand will go to swipe on left
	private float rightBound = 20f; //Furthest hand will go to swipe on right

	public float rightDelay; //How delayed should the right hand be from the left?
	private float startTime;

	void OnEnable () {
		counter = 3;
		leftHand = GameObject.FindGameObjectWithTag ("Left Hand");
		rightHand = GameObject.FindGameObjectWithTag ("Right Hand");
		player = GameObject.FindGameObjectWithTag ("Player");
		leftC = counter;
		rightC = counter;
		startTime = Time.time;
	}

	void Update () {
		if (leftC == 0 && rightC == 0) {
			GameObject.FindGameObjectWithTag ("Boss").GetComponent<TreeBossManager> ().nextState ();
			this.enabled = false;
		} 

		else {
			//LEFT HAND************************************************************
			if (leftC != 0) {
				if (setupL == false) { //If the hand hasnt set up yet, move it to position
					Vector3 startSwipe = new Vector3 (leftBound, player.transform.position.y, leftHand.transform.position.z);
					leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, startSwipe, speed * Time.deltaTime);

					if (leftHand.transform.position == startSwipe)
						setupL = true;

				} else if (resetL == false) { //if the hand hasnt finished swiping yet, continue to swipe
					Vector3 endSwipe = new Vector3 (rightBound, leftHand.transform.position.y, leftHand.transform.position.z);
					leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, endSwipe, speed * Time.deltaTime);

					if (leftHand.transform.position == endSwipe) {
						resetL = true;
					}
				} else if (resetL == true) { //if the hand hasn't reset after swiping yet, continue to reset
					leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, leftInitalPos, speed * Time.deltaTime);

					if (leftHand.transform.position == leftInitalPos) {
						resetL = false;
						setupL = false;
						leftC--;
					}
				}
			}
			//*******************************************************************************

			//RIGHT HAND*********************************************************************
			if (rightC != 0 && Time.time > startTime + rightDelay) {
				if (setupR == false) { //If the hand hasnt set up yet, move it to position
					Vector3 startSwipe = new Vector3 (rightBound, player.transform.position.y, rightHand.transform.position.z);
					rightHand.transform.position = Vector3.MoveTowards (rightHand.transform.position, startSwipe, speed * Time.deltaTime);

					if (rightHand.transform.position == startSwipe)
						setupR = true;

				} else if (resetR == false) { //if the hand hasnt finished swiping yet, continue to swipe
					Vector3 endSwipe = new Vector3 (leftBound, rightHand.transform.position.y, rightHand.transform.position.z);
					rightHand.transform.position = Vector3.MoveTowards (rightHand.transform.position, endSwipe, speed * Time.deltaTime);

					if (rightHand.transform.position == endSwipe) {
						resetR = true;
					}
				} else if (resetR == true) { //if the hand hasn't reset after swiping yet, continue to reset
					rightHand.transform.position = Vector3.MoveTowards (rightHand.transform.position, rightInitalPos, speed * Time.deltaTime);

					if (rightHand.transform.position == rightInitalPos) {
						resetR = false;
						setupR = false;
						rightC--;
					}
				}
			}
			//*********************************************************************************
		}
	}

}
