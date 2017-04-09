using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeState : MonoBehaviour {

	private Vector3 initalPos = new Vector3(-4.05f,1.73f,-1f); //Holds inital position of hand 
	private GameObject leftHand;
	private GameObject player;

	public int speed;

	private int counter; //how many times must the hand swipe?

	private bool setup = false; //Says if hand has set up to swipe player
	private bool reset = false; //says if hand needs to reset

	void OnEnable () {
		counter = 1;
		leftHand = GameObject.FindGameObjectWithTag ("Left Hand");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (counter == 0) {
			GameObject.FindGameObjectWithTag ("Boss").GetComponent<TreeBossManager> ().nextState ();
			this.enabled = false;
		} 

		else {
			if (setup == false) { //If the hand hasnt set up yet, move it to position
				Vector3 startSwipe = new Vector3 (-6f, player.transform.position.y, leftHand.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, startSwipe, speed * Time.deltaTime);

				if (leftHand.transform.position == startSwipe)
					setup = true;

			} else if (reset == false) { //if the hand hasnt finished swiping yet, continue to swipe
				Vector3 endSwipe = new Vector3 (20f, leftHand.transform.position.y, leftHand.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, endSwipe, speed * Time.deltaTime);

				if (leftHand.transform.position == endSwipe) {
					reset = true;
				}
			} else if (reset == true) { //if the hand hasn't reset after swiping yet, continue to reset
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, initalPos, speed * Time.deltaTime);

				if (leftHand.transform.position == initalPos) {
					reset = false;
					setup = false;
					counter--;
				}
			}
		}
	}

}
