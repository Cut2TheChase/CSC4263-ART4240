using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour {
	private GameObject player;
	private Vector3 target;

	public int speed;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		if (transform.position == target)
			Destroy (gameObject);
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("AHHHHHHHHH " + other);
		if (other.gameObject.tag == "Player Collider")
			GetComponent<EnemyDamage> ().causeDamage ();
	}
}
