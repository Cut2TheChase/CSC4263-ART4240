using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionInState : MonoBehaviour {

	private GameObject player;
	private GameObject feetColl;

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");

	    //Turn off player-controlled movement
		player.GetComponent<playerMovement> ().enabled = false;
		//Begin Fading In
		GetComponent<FadeIn> ().enabled = true;
	}
		
	void Update () {
		//Tells the player to move forward until the script is turned off
		player = GameObject.FindGameObjectWithTag ("Player"); //this needs to be here because otherwise in scene changes it thinks it the old player, why? *shrugs*
		feetColl = GameObject.FindGameObjectWithTag ("Feet Collider");

		player.GetComponent<Transform> ().Translate (new Vector3(0.06f, 0, 0));
		feetColl.GetComponent<Transform> ().position = player.GetComponent<Transform> ().position;
		player.GetComponent<Animator> ().SetInteger ("State", 1);

	}
}
