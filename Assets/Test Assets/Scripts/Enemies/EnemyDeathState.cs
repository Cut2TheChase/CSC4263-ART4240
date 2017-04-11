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

public class EnemyDeathState : MonoBehaviour {
    void Start () {
		
	}
    void OnEnable () {
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
