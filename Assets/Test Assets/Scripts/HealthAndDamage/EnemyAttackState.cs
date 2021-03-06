﻿///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages when an ememy is in range of a player to attack.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : MonoBehaviour {

	GameObject player;
	float disFromPlayer; //distance the player is from the enemy
	public float range; //range at which the enemy will spot the character
	public float speed;
	public float attackDis; //attack distance

	private float nextAttack = 0; //time next attack can happen
	public float attackRate; //Rate the enemy can attack, in seconds

	int dirFacing = -1; //Direction enemy is facing, 1 = right, -1 = left

	private Animator anim;

	[HideInInspector]
	public float waitTime;


	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");

		anim = GetComponent<Animator> ();
	}

	void Update () {
		
		disFromPlayer = Vector2.Distance (new Vector2 (player.transform.position.x, player.transform.position.y),
			                                new Vector2 (transform.position.x, transform.position.y));

		//if player is within seeable range
		if (disFromPlayer < range) {
			Attack ();
			//anim.SetInteger ("State", 2); //Enemy Move animation
		} else
			anim.SetInteger ("State", 1); //Enemy Idle Animation

		//Direction facing calculation
		if (dirFacing == -1)
			GetComponent<Transform> ().localScale = new Vector3(Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value negative
		else
			GetComponent<Transform> ().localScale = new Vector3(-Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value positive
		
	}
		
	void Attack(){
		if (GetComponent<enemyHealth> ().hurt != true) {
			if (player.transform.position.x < transform.position.x) //if player is on a certain side of enemy, face that side
			dirFacing = -1;
			else
				dirFacing = 1; 
			//If the enemy is not close enough to attack
			if (disFromPlayer > attackDis) {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed);
				anim.SetInteger ("State", 2); //Enemy Attack animation
				nextAttack = Time.time + (attackRate);
			} else if (Time.time > nextAttack) { //If enough time has passed for the next attack to happen and the enemy is close enough to the player
				nextAttack = Time.time + attackRate;
				anim.SetInteger ("State", 3); //Enemy Attack animation
				GetComponent<EnemyDamage> ().causeDamage ();
			}
		} else if (Time.time > waitTime) {
			GetComponent<SpriteRenderer> ().enabled = true;
			GetComponent<enemyHealth> ().hurt = false;
		}
	}
		
}
