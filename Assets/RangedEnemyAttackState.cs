using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttackState : MonoBehaviour {

	GameObject player;
	float disFromPlayer; //distance the player is from the enemy
	public float range; //range at which the enemy will spot the character
	public float speed;
	public float attackDis; //attack distance

	private float nextAttack = 0; //time next attack can happen
	public float attackRate; //Rate the enemy can attack, in seconds

	private bool foundChar = false; //Keeps track of when the enemy first spots the character
	private Animator anim;

	public GameObject projectile; //projectile enemy will throw

	[HideInInspector]
	public int dirFacing = -1; //Direction enemy is facing, 1 = right, -1 = left


	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}

	void Update () {

		disFromPlayer = Vector2.Distance (new Vector2 (player.transform.position.x, player.transform.position.y),
			new Vector2 (transform.position.x, transform.position.y));

		//if player is within seeable range
		if (disFromPlayer < range && foundChar == true) {
			anim.SetInteger ("State", 2);
			Attack ();

		}

		if (disFromPlayer < range / 2) {
			anim.SetInteger ("State", 1);
			foundChar = true;
		}

		//Direction facing calculation
		if (dirFacing == -1)
			GetComponent<Transform> ().localScale = new Vector3(Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value negative
		else
			GetComponent<Transform> ().localScale = new Vector3(-Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value positive

	}

	void Attack(){
		if (player.transform.position.x < transform.position.x) //if player is on a certain side of enemy, face that side
			dirFacing = -1;
		else
			dirFacing = 1; 

		//If the enemy is not close enough to attack
		if (disFromPlayer > attackDis) {
			nextAttack = Time.time + attackRate;
		} else if(Time.time > nextAttack) { //If enough time has passed for the next attack to happen and the enemy is close enough to the player
			nextAttack = Time.time + attackRate;
			anim.SetInteger ("State", 3);
		}
	}

}
