using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamScript : MonoBehaviour {

	private Vector3 initalPos = new Vector3(-4.05f,1.73f,-1f); //Holds inital position of hand 
	private GameObject leftHand;
	private GameObject player;

	public int speed;

	public float waitTime;
	private float startTime;

	private float playerY; //Player's Y value when the hand goes to slam

	private int counter; //how many times must the hand swipe?

	private bool setup = false; //Says if hand has set up to swipe player
	private bool reset = false; //says if hand needs to reset

	void OnEnable () {
		counter = 3;
		leftHand = GameObject.FindGameObjectWithTag ("Left Hand");
		player = GameObject.FindGameObjectWithTag ("Player");
		leftHand.GetComponent<zAxisManager> ().enabled = false; //Disables z axis manager so that slam can happen on player's Z axis
	}

	void OnDisable(){
		leftHand.GetComponent<zAxisManager> ().enabled = true;
	}

	
	void Update () {
		if (counter == 0) {
			//goes back to initial position
			leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, initalPos, speed * Time.deltaTime); 
			//Go to next state if hand is in position
			if (leftHand.transform.position == initalPos) {
				GameObject.FindGameObjectWithTag ("Boss").GetComponent<TreeBossManager> ().nextState ();
				this.enabled = false;
			}
		} 

		else {
			if (setup == false) { //If the hand hasnt set up yet, move it to position
				
				Vector3 startSlam = new Vector3 (player.transform.position.x, initalPos.y, player.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, startSlam, speed * Time.deltaTime);

				if (leftHand.transform.position == startSlam) {
					Debug.Log ("AH");
					setup = true;
					playerY = player.transform.position.y;
				}

			} else if (reset == false) { //if the hand hasnt finished slamming yet, continue to slam
				Vector3 endSlam = new Vector3 (leftHand.transform.position.x, playerY, leftHand.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, endSlam, speed * Time.deltaTime);

				if (leftHand.transform.position == endSlam) {
					startTime = Time.time;
					reset = true;
				}
			} else if (reset == true) { //if the hand has slammed, wait
				if (Time.time - startTime >= waitTime) { //If the wait time after slamming has passed, try to slam again
						reset = false;
						setup = false;
						counter--;
					}
				}
			}
		}
	}

