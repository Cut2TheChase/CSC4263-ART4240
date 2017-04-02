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
