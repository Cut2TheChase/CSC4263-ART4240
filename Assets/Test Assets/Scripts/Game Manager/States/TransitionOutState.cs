﻿///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code for handling transitioning out of a scene.
///Author -- Chase Bernard
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
		//Begin Fading Out
		GetComponent<FadeOut> ().enabled = true;
	}
		
	void Update () {
		//Tells the player to move forward until the script is turned off
		player.GetComponent<Transform> ().Translate (new Vector3(0.06f, 0, 0));
		player.GetComponent<Animator> ().SetInteger ("State", 1);

	}
}
