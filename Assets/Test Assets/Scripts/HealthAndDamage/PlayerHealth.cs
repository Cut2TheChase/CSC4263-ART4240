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

	bool hurt = false;
	public float hurtTime;
	private float startTime;
	private int hurtCounter;

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

	public void resetSlider(){
		healthSlider.value = currentHealth;
	}
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
		
}
