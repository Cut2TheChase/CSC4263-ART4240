using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamScript : MonoBehaviour {

	private Vector3 initalPos = new Vector3(-4.05f,1.73f,-1f); //Holds inital position of hand 
	private GameObject leftHand;
	private GameObject player;
	private GameObject playerCol;

	public int speed;
	public int damage;

	public float waitTime;
	private float startTime;

	private float playerY; //Player's Y value when the hand goes to slam

	private int counter; //how many times must the hand swipe?

	private bool setup = false; //Says if hand has set up to swipe player
	private bool reset = false; //says if hand needs to reset


	//public IEnumerator zoomCam(float time)
	//{
	//	Camera.main.GetComponent<Slamzoom>().zoomOut = true;
	//	Camera.main.GetComponent<Slamzoom>().elapsed = 0.0f;
	//	yield return new WaitForSeconds (time);
	//	Camera.main.GetComponent<Slamzoom>().zoomIn = true;
	//}





	void OnEnable () {
		counter = 3;
		leftHand = GameObject.FindGameObjectWithTag ("Left Hand");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerCol = GameObject.FindGameObjectWithTag ("Player Collider");
		leftHand.GetComponent<zAxisManager> ().enabled = false; //Disables z axis manager so that slam can happen on player's Z axis

		//StartCoroutine (zoomCam (5));

		leftHand.GetComponent<Animator> ().SetInteger ("State", 2);

	}

	void OnDisable(){
		leftHand.GetComponent<zAxisManager> ().enabled = true;
		leftHand.GetComponent<Animator> ().SetInteger ("State", 0);
	}

	
	void Update () {
		if (counter == 0) {
			//goes back to initial position
			leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, initalPos, speed * Time.deltaTime); 
			//Go to next state if hand is in position
			if (leftHand.transform.position == initalPos) {
				GameObject.FindGameObjectWithTag ("Boss").GetComponent<TreeBossManager> ().nextState ();
				this.enabled = false;
				counter = 3;
			}
		} 

		else {
			if (setup == false) { //If the hand hasnt set up yet, move it to position
				
				Vector3 startSlam = new Vector3 (playerCol.transform.position.x, initalPos.y, playerCol.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, startSlam, speed * Time.deltaTime);

				if (leftHand.transform.position == startSlam) {
					setup = true;
					playerY = playerCol.transform.position.y;
				}

			} else if (reset == false) { //if the hand hasnt finished slamming yet, continue to slam
				Vector3 endSlam = new Vector3 (leftHand.transform.position.x, playerY, leftHand.transform.position.z);
				leftHand.transform.position = Vector3.MoveTowards (leftHand.transform.position, endSlam, speed * Time.deltaTime * 2);

				if (leftHand.transform.position == endSlam) {
					if (playerCol.transform.position.x > leftHand.transform.position.x - 1.5f && playerCol.transform.position.x < leftHand.transform.position.x + 1.5f && playerCol.transform.position.y < leftHand.transform.position.y + 1f && playerCol.transform.position.y > leftHand.transform.position.y - 1f)
						player.GetComponent<PlayerHealth> ().TakeDamage (damage);
					//Camera.main.GetComponent<Shake> ().Shaker ();
					//player.GetComponent<ClampScript>().callShake();
					//GameObject.FindGameObjectWithTag("Feet Collider").GetComponent<Shake> ().isShaking =true;
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

