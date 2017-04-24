///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that handles the functionality of GUI buttons that transition
///from the Main Menu Scene to the play scene and exit the game.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		GetComponent<Animator> ().SetInteger ("State", 8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
