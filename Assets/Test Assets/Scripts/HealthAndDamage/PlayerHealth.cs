///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the players health bar, actual health, when player is healed or damaged, and the memory counter GUI object.
///Author -- Mitchell Aucoin, Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startHealth; //initialize starting health of the player
    public float maxHealth = 100; //sets max health of the player
    public float currentHealth; //initializes current health of the player.
    public Slider healthSlider; //accesses the player's GUI health bar element
    public float damage; //initialize total damage player has sustained
    bool damaged; //is player damaged

	bool hurt = false; //determines wheter or not the player is hurt
	public float hurtTime; //determines how long the player has been hurt
	private float startTime; //start timer for hurtTime
	private int hurtCounter; 

    private int memoryCount; //initialize current count of memories collected
    public int totalMemory = 5; //sets total number of memories that need to be found

    //helps determine starting health from scene to scene
    void Awake ()
    {
        currentHealth = maxHealth;
        if (damaged == false)
        {
            startHealth = maxHealth;
        }
        else if(damaged == true)
        {
            startHealth = currentHealth -= damage;
        }
    }
    //function for dealing with the player taking damage and dying
	public void TakeDamage (float amount)
    {
		if (hurt == false) {
			damaged = true;
			hurt = true;
			startTime = Time.time;
			healthSlider.value -= amount;
			currentHealth -= amount;
			damage += amount;
			if (currentHealth == 0) {
				GameManager.instance.changeState ("death");
			} 
		}
    }
    //function to set slider to current health value
	public void resetSlider(){
		healthSlider.value = currentHealth;
	}
    //function for dealing with the player getting healed, won't go over max health
    public void GetHealed (float amount)
    {
        healthSlider.value += amount;
        currentHealth += amount;
        damage -= amount;
        if(currentHealth > maxHealth)
        {
            healthSlider.value = maxHealth;
            currentHealth = maxHealth;
            damage = 0;
        }
    }
    //function to deal with sprite flashing when player gets damaged
	void Update(){
		if(hurt == true){
			if (Time.time < startTime + hurtTime) {
				if (hurtCounter < 10)
					GetComponent<SpriteRenderer> ().enabled = false;
				else
					GetComponent<SpriteRenderer> ().enabled = true;
			} else {
				GetComponent<SpriteRenderer> ().enabled = true;
				hurt = false;
			}
			hurtCounter++;
			if (hurtCounter > 20)
				hurtCounter = 0;
		}
			
	}
    //function to add to current number of collected memories
    public void memCount()
    {
        memoryCount += 1;
    }
    //Creates GUI element to keep track of total number of memories collected
    public void OnGUI()
    {
        GUI.Label(new Rect(1, 1, 200, 30), "Memories: " + memoryCount + "/" + totalMemory);
    }

}
