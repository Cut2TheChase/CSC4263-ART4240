///Uptown Pigeon Gaming
///Project Fugue
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
    public float startHealth;
    public float maxHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    public float damage;
    bool damaged;

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
	public void TakeDamage (float amount)
    {
        damaged = true;
        healthSlider.value -= amount;
        currentHealth -= amount;
        damage += amount;
		if (currentHealth == 0) {
			GameManager.instance.changeState ("death");
		}
    }

	public void resetSlider(){
		healthSlider.value = currentHealth;
	}
}
