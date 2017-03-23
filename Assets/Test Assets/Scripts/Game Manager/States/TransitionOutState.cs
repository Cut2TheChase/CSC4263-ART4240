using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionOutState : MonoBehaviour {

	private GameObject player;
	private GameObject mainCamera;

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");

		//Turn off player-controlled movement
		player.GetComponent<playerMovement> ().enabled = false;
		//Begin Fading In
		GetComponent<FadeOut> ().enabled = true;
	}
		
	void Update () {
		//Tells the player to move forward until the script is turned off
		player.GetComponent<Transform> ().Translate (new Vector3(0.06f, 0, 0));
		player.GetComponent<Animator> ().SetInteger ("State", 1);

	}
}
