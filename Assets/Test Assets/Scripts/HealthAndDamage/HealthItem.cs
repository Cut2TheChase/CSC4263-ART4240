///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages health items and how they heal the player.
///Author -- Mitchell Aucoin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private GameObject player; //used to help find player object
    PlayerHealth playerHealth; //accesss PlayerHealth.cs
    private float healthUp = 100; //sets amount health goes up when interacting with item
    float disFromPlayer; //distance the player is from the enemy
    public float range; //range at which the enemy will spot the character

    //finds player object and the player's health component
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    //determines distance between player object and health item and calls the Healing() function whenever the distance between the 2 is short enough
    void Update()
    {
        disFromPlayer = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y),
                                            new Vector2(transform.position.x, transform.position.y));
        if (disFromPlayer < range)
        {
            Healing();
        }
    }
    //calls the PlayerHealth.cs GetHealed function healing the player for the amount specified by healthUp then destroys the health item
    public void Healing()
    {
        playerHealth.GetHealed(healthUp);
        Destroy(gameObject);
    }
} 