﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 5;
    GameObject player;
    PlayerHealth playerHealth;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
	}

	void OnTriggerEnter2D (Collider2D other)

    {
        if(other.gameObject == player)
        {
            if(playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}