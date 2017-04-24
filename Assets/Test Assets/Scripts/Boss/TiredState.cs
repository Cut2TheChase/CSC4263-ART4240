///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the tired state of the boss.
///Author -- Mitchell Aucoin, Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiredState : MonoBehaviour {
	private float startTime;
	public float tiredDuration;
    public Slider healthSlider;

    //Enables the collider, as this is when the boss is vulnerable
    void OnEnable () {
		GetComponent<CircleCollider2D> ().enabled = true;
		startTime = Time.time;

		GetComponent<Animator> ().SetInteger ("State", 2);
		GetComponent<Animator> ().SetBool ("isOpen", true);
		GetComponent<Animator> ().SetBool ("tired", true);
	}

	void OnDisable(){
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<Animator> ().SetBool ("isOpen", false);
		GetComponent<Animator> ().SetBool ("tired", false);
		GetComponent<Animator> ().SetInteger ("State", 1);
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= tiredDuration) {
			this.enabled = false;
			GetComponent<TreeBossManager>().nextState ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
        //Checks for an attack by the player
        //Sends data for damage to GUI slider
		if (other.tag == "Sword" && GetComponent<TreeBossManager>().health > 0 && other.gameObject.GetComponentInParent<swing>().swung == true) {
			GetComponent<Animator> ().SetBool ("hurt", true);
			GetComponent<TreeBossManager>().health -= other.GetComponentInParent<sword>().damage;
            healthSlider.value -= other.GetComponentInParent<sword>().damage;
		}
    }
}
