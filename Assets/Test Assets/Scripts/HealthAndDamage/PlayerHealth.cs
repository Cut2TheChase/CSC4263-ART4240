using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    bool damaged;

	void Awake ()
    {
        currentHealth = startHealth;
	}
	
    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
    }
}
