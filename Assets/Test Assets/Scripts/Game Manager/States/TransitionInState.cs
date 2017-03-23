using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionInState : MonoBehaviour {

	private GameObject player;
	private GameObject mainCamera;

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	    //Turn off player-controlled movement
		player.GetComponent<playerMovement> ().enabled = false;
		//Begin Fading In
		mainCamera.GetComponent<FadeIn> ().enabled = true;
		Debug.Log (mainCamera.GetComponent<FadeIn> ().enabled);
	}
		
	void Update () {
		//Tells the player to move forward until the script is turned off
		player = GameObject.FindGameObjectWithTag ("Player"); //this needs to be here because otherwise in scene changes it thinks it the old player, why? *shrugs*
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera"); //this too =.=

		player.GetComponent<Transform> ().Translate (new Vector3(0.06f, 0, 0));
		player.GetComponent<Animator> ().SetInteger ("State", 1);

	}
}
