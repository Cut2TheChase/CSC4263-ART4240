using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickState : MonoBehaviour {

	private Vector3 initalPos = new Vector3(-4.05f,1.73f,-1f); //Holds inital position of hand 
	private GameObject leftHand;
	private GameObject player;
	private GameObject playerCol;

	public int speed;
	public int force;
	public int damage;

	public float waitTime;
	private float startTime;


	private bool setup = false; //Says if hand has set up to swipe player
	private bool reset = false; //says if hand needs to reset
	[HideInInspector]
	public bool playerFlicked = false; //says if player was flicked

	private Vector3 impact = Vector3.zero;

	void OnEnable () {
		leftHand = GameObject.FindGameObjectWithTag ("Left Hand");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerCol = GameObject.FindGameObjectWithTag ("Player Collider");
		impact = Vector3.zero;
		playerFlicked = false;
		leftHand.GetComponent<Animator> ().SetInteger ("State", 3);
	}

	void Update () {

			if (setup == false) { //If the hand hasnt set up yet, move it to position
				Vector3 startFlick = new Vector3 (playerCol.transform.position.x - 1, playerCol.transform.position.y, leftHand.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, startFlick, speed * Time.deltaTime);

				if (leftHand.transform.position == startFlick)
					setup = true;
				else
					startTime = Time.time; //resets the start time until the hand makes it to the player

			}
		else if (reset == false) { //this is when the flick is ready to strike
			
			if (Time.time - startTime >= waitTime) { //If the wait time before the flick has passed, try to flick player
				leftHand.GetComponent<Animator> ().SetBool("flickIt", true);
					//If player is in the correct spot in front of hand, flick the player
					if(playerCol.transform.position.x <= leftHand.transform.position.x + 1.5f && playerCol.transform.position.x >= leftHand.transform.position.x - 0.5f && playerCol.transform.position.y <= leftHand.transform.position.y + 2f && playerCol.transform.position.y >= leftHand.transform.position.y - 2f){
					    player.GetComponent<PlayerHealth> ().TakeDamage (damage);
						AddImpact (new Vector3 (30, 30, 0), force);
						player.GetComponent<playerMovement> ().jumpState = true; //Make the jumpstate true because the player is now falling
						playerFlicked = true;
					}
				reset = true; //The hand has tried to flick
				}
				
			} else if (reset == true) { //Hand is reseting, also if the flick happened then letting the force die down
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, initalPos, speed * Time.deltaTime);
			    leftHand.GetComponent<Animator> ().SetBool("flickIt", false);
			leftHand.GetComponent<Animator> ().SetInteger ("State", 0);
			impact = Vector3.Lerp (impact, Vector3.zero, 5 * Time.deltaTime); //impact vector is going towards 0
			if (leftHand.transform.position == initalPos) {
				//if the hand is in the initial position and the player either wasnt flick or the flick is done, go to next scene
					if (playerFlicked == false) { 
						setup = false;
						reset = false;
						GameObject.FindGameObjectWithTag ("Boss").GetComponent<TreeBossManager> ().nextState ();
						this.enabled = false;
					  }
				}
			}

		//If the player was flicked, add the force to the player
		if (playerFlicked == true) {
			player.GetComponent<CharacterController> ().Move (impact * Time.deltaTime);

			//if the player has stopped falling after flick, reset playerFlicked to false
			if (player.GetComponent<playerMovement> ().jumpState == false ) {
				impact = Vector3.zero;
				playerFlicked = false;
				}
			}
		}

	//Adds the force to the impact vector
	public void AddImpact(Vector3 dir, float force){
		dir.Normalize ();
		if (dir.y < 0)
			dir.y = -dir.y; //reflect down force on the ground
		impact += dir.normalized * force / 3.0f;

	}
}
