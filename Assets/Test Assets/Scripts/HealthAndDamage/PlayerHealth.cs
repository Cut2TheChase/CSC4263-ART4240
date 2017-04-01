///Uptown Pigeon Gaming
///Project Fuge
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the players health bar.
///Author -- Mitchell Aucoin, Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    
    bool damaged;

	void Awake ()
    {

        currentHealth = startHealth;
	}
	
    public void TakeDamage (float amount)
    {
        damaged = true;
        healthSlider.value -= amount;
        currentHealth -= amount;

		if (currentHealth == 0) {
			GameManager.instance.changeState ("death");
		}
    }
}
