///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the GUI element that represents the collection of memory items.
///Author -- Mitchell Aucoin, Jonathan Nguyen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCounterGUI : MonoBehaviour {

    private GameObject player; //finds the player game object
    PlayerHealth playerHealth; //used to call playerHealth.cs
    public playerMovement playerMove; //used to pause player controls during memory cutscene
    float disFromPlayer; //distance the player is from the enemy
    public float range; //range at which the enemy will spot the character
    public Canvas memoryUI; //the text overlay that is displayed for a specific memory instance
        // memoryUI prefab needs to be created, concerns about sequential (press-to-proceed) texts in one memoryUI?
    
    //finds player object and its health and movement components
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMove = player.GetComponent<playerMovement>();
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
    //used to access the PlayerHealth.cs function memCount(), plays corresponding cutscene, and destroys memory item on contact
    public void countMem()
    {
        playerHealth.memCount();
        playerMove.enabled = false;
        bool done = false;
        while (done == false)
        {
            memoryUI.GetComponent<Canvas>().enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                memoryUI.GetComponent<Canvas>().enabled = false;
                done = true;
            }
        }
        playerMove.enabled = true;
        Destroy(gameObject);
    }
}
