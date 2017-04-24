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

	private float destroyTime;
	private float animTime = 0.8f;
    void Start () {
		
	}
    void OnEnable () {
		GetComponent<Animator>().SetInteger("State", 4); //Enemy Death Animation
		destroyTime = Time.time + animTime;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > destroyTime)
			Destroy (gameObject);
		}

		
	}

