﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : MonoBehaviour {

	private float startTime;
	public float tauntDuration;

	//Enables the collider, as this is when the boss is vulnerable
	void OnEnable () {
		GetComponent<CircleCollider2D> ().enabled = true;
		startTime = Time.time;
	}

	void OnDisable(){
		GetComponent<CircleCollider2D> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= tauntDuration) {
			this.enabled = false;
			GetComponent<TreeBossManager>().nextState ();
		}
	}
		
		void OnTriggerEnter2D (Collider2D other)
		{
		//Checks for an attack by the player
		if (other.tag == "Sword" && GetComponent<TreeBossManager>().health > 0) {
			GetComponent<TreeBossManager>().health -= other.GetComponentInParent<sword>().damage;
			}


		}
}