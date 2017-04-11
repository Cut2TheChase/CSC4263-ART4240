using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamScript2 : MonoBehaviour {

	private Vector3 leftInitalPos = new Vector3(-4.05f,1.73f,-1f); //Holds inital position of hand 
	private Vector3 rightInitalPos = new Vector3(17.33f,1.73f,-1f); //Holds inital position of righthand 
	private GameObject leftHand;
	private GameObject rightHand;
	private GameObject player;

	public int speed;

	public float waitTime; //How long the hands must wait once they slam
	private float startTimeL; //Start time of wait while on the ground, respective to Left
	private float startTimeR; //Start time of wait while on the ground, respective to Right

	private float playerYL; //Player's Y value when the hand goes to slam, respective to Left
	private float playerYR; //Player's Y value when the hand goes to slam, respective to Right

	private int counter = 3; //how many times must the hand swipe?
	private int leftC; //counter for left hand
	private int rightC; // counter for right hand

	private bool setupL = false; //Says if left hand has set up to swipe player
	private bool resetL = false; //says if left hand needs to reset

	private bool setupR = false; //Says if right hand has set up to swipe player
	private bool resetR = false; //says if right hand needs to reset

	public float rightDelay; //How delayed should the right hand be from the left?
	private float startTime;



	void OnEnable () {
		leftHand = GameObject.FindGameObjectWithTag ("Left Hand");
		rightHand = GameObject.FindGameObjectWithTag ("Right Hand");
		player = GameObject.FindGameObjectWithTag ("Player");
		leftHand.GetComponent<zAxisManager> ().enabled = false; //Disables z axis manager so that slam can happen on player's Z axis
		rightHand.GetComponent<zAxisManager> ().enabled = false; //Disables z axis manager so that slam can happen on player's Z axis
		startTime = Time.time;

		leftC = counter;
		rightC = counter;

	}

	void OnDisable(){
		leftHand.GetComponent<zAxisManager> ().enabled = true;
		rightHand.GetComponent<zAxisManager> ().enabled = true;
	}


	void Update () {
		if (leftC == 0) {
			//left hand goes back to initial position
			leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, leftInitalPos, speed * Time.deltaTime); 
			if (rightC == 0) {
				//right hand goes back to initial position
				rightHand.transform.position = Vector3.MoveTowards (rightHand.transform.position, rightInitalPos, speed * Time.deltaTime); 
				//Go to next state if both hands are in position
				if (leftHand.transform.position == leftInitalPos && rightHand.transform.position == rightInitalPos) {
					GameObject.FindGameObjectWithTag ("Boss").GetComponent<TreeBossManager> ().nextState ();
					this.enabled = false;
				}
			}
		} 

		if(rightC != 0){
			//LEFT HAND*********************************************************************************************************
			if (setupL == false && leftC != 0) { //If the hand hasnt set up yet, move it to position

				Vector3 startSlam = new Vector3 (player.transform.position.x, leftInitalPos.y, player.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, startSlam, speed * Time.deltaTime);
				if (leftHand.transform.position == startSlam) {
					setupL = true;
					playerYL = player.transform.position.y;
				}

			} else if (resetL == false && leftC != 0) { //if the hand hasnt finished slamming yet, continue to slam
				Vector3 endSlam = new Vector3 (leftHand.transform.position.x, playerYL, leftHand.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, endSlam, speed * Time.deltaTime * 2);

				if (leftHand.transform.position == endSlam) {
					Camera.main.GetComponent<Shake> ().Shaker ();
					startTimeL = Time.time;
					resetL = true;
				}
			} else if (resetL == true) { //if the hand has slammed, wait
				if (Time.time - startTimeL >= waitTime) { //If the wait time after slamming has passed, try to slam again
					resetL = false;
					setupL = false;
					leftC--;
				}
			}
			//*****************************************************************************************************


			//RIGHT HAND ****************************************************************************************
			if (setupR == false && Time.time > startTime + rightDelay) { //If the hand hasnt set up yet, move it to position
				Vector3 startSlam = new Vector3 (player.transform.position.x, rightInitalPos.y, player.transform.position.z);
				rightHand.transform.position = Vector3.MoveTowards (rightHand.transform.position, startSlam, speed * Time.deltaTime);

				if (rightHand.transform.position == startSlam) {
					setupR = true;
					playerYR = player.transform.position.y;
				}

			} else if (resetR == false && setupR == true) { //if the hand hasnt finished slamming yet, continue to slam
				Vector3 endSlam = new Vector3 (rightHand.transform.position.x, playerYR, rightHand.transform.position.z);
				rightHand.transform.position = Vector3.MoveTowards (rightHand.transform.position, endSlam, speed * Time.deltaTime * 2);

				if (rightHand.transform.position == endSlam) {
					Camera.main.GetComponent<Shake> ().Shaker ();
					startTimeR = Time.time;
					resetR = true;
				}
			} else if (resetR == true) { //if the hand has slammed, wait
				if (Time.time - startTimeR >= waitTime) { //If the wait time after slamming has passed, try to slam again
					resetR = false;
					setupR = false;
					//startTime = Time.time;
					rightC--;
				}
			}
			//*************************************************************************************************************
		}
	}
}
