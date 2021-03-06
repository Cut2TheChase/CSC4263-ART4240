﻿///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that handles the functionality of GUI buttons that transition
///from the Main Menu Scene to the play scene and exit the game.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour 
{
	public int health;
	private int hurtCounter = 0; 

	[HideInInspector]
	public bool hurt = false;

	void Start () 
	{
		health = 100;
	}
    void Update () 
	{
		if (health <= 0) 
		{
			this.GetComponent<EnemyAttackState> ().enabled = false;
			this.GetComponent<EnemyDeathState> ().enabled = true;
		}	

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Sword" && other.gameObject.GetComponentInParent<swing>().swung == true) {
			this.health -= other.GetComponentInParent<sword>().damage;
			if (this.health != 0) {
				GetComponent<Animator> ().SetInteger ("State", 5);
				hurt = true;
				GetComponent<EnemyAttackState> ().waitTime = Time.time + 0.3f;
			}
		}
	}
}


