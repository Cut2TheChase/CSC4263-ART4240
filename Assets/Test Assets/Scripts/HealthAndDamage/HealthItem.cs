using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private GameObject player;
    PlayerHealth playerHealth;
    private float healthUp = 100;
    float disFromPlayer; //distance the player is from the enemy
    public float range; //range at which the enemy will spot the character
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        disFromPlayer = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y),
                                            new Vector2(transform.position.x, transform.position.y));
        if (disFromPlayer < range)
        {
            Healing();
        }
    }

    public void Healing()
    {
        playerHealth.GetHealed(healthUp);
        Destroy(gameObject);
    }
} 