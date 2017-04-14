///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the GUI element that represents the collection of memory items.
///Author -- Mitchell Aucoin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCounterGUI : MonoBehaviour {

    private GameObject player; //finds the player game object
    PlayerHealth playerHealth; //used to call playerHealth.cs
    float disFromPlayer; //distance the player is from the enemy
    public float range; //range at which the enemy will spot the character
    
    //finds player object and player health
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    //calculates distance from memory item to player object and calls countMem if the two are close enough
    void Update()
    {
        disFromPlayer = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y),
                                            new Vector2(transform.position.x, transform.position.y));
        if (disFromPlayer < range)
        {
            countMem();
        }
    }
    //used to access the PlayerHealth.cs function memCount() and destroys memory item on contact
    public void countMem()
    {
        playerHealth.memCount();
        Destroy(gameObject);
    }
}
