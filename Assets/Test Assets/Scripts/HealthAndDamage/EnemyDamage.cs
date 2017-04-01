///Uptown Pigeon Gaming
///Project Fuge
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that handles damage dealt by an enemy.
///Author -- Mitchell Aucoin, Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 5;
    GameObject player;
    PlayerHealth playerHealth;
	GameObject pCollider;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		pCollider = GameObject.FindGameObjectWithTag("Player Collider");
        playerHealth = player.GetComponent<PlayerHealth>();
	}

	public void causeDamage(){
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage(damage);
		}
	}
}
