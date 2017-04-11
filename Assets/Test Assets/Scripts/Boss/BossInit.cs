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

public class BossInit : MonoBehaviour {

	private GameObject boss;
	// Use this for initialization
	void Start () {
		boss = GameObject.FindGameObjectWithTag ("Boss");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D()
	{
		boss.GetComponent<TreeBossManager> ().nextState ();
		Destroy (gameObject);
	}
}
