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
    }
}
