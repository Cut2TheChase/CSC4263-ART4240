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

public class enemyHealth : MonoBehaviour 
{
	public int health;

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
		if (other.tag == "Sword") {
			this.health -= other.GetComponentInParent<sword>().damage;
		}

		
	}

}
