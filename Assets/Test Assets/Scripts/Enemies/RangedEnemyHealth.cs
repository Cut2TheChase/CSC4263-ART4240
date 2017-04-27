using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyHealth : MonoBehaviour {
	public int maxHealth;
	private int hurtCounter = 0; 

	[HideInInspector]
	public bool hurt = false;

	[HideInInspector]
	public int health;

	void Start () 
	{
		health = maxHealth;
	}
	void Update () 
	{
		if (health <= 0) 
		{
			this.GetComponent<RangedEnemyAttackState> ().enabled = false;
			this.GetComponent<EnemyDeathState> ().enabled = true;
		}	

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Sword" && other.gameObject.GetComponentInParent<swing>().swung == true) {
			this.health -= other.GetComponentInParent<sword>().damage;
			if (this.health != 0) {
				GetComponent<Animator> ().SetInteger ("State", 5);
				hurt = true;
				GetComponent<EnemyAttackState> ().waitTime = Time.time + 0.3f;
			}
		}
	}
}



