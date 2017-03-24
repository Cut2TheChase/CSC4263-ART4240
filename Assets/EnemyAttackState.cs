using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : MonoBehaviour {

	GameObject player;
	float disFromPlayer; //distance the player is from the enemy
	public float range; //range at which the enemy will spot the character
	public float speed;
	public float attackDis; //attack distance

	int dirFacing = -1; //Direction enemy is facing, 1 = right, -1 = left

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		
		disFromPlayer = Vector2.Distance (new Vector2 (player.transform.position.x, player.transform.position.y),
			                                new Vector2 (transform.position.x, transform.position.y));

		//if player is within seeable range
		if (disFromPlayer < range) {
			Attack ();
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
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed);
		} 
	}
}
