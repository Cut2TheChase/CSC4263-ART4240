using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour {
	private GameObject player;
	private Vector2 target;

	public int speed;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player Collider");
		target = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		if (transform.position.x == target.x && transform.position.y == target.y)
			Destroy (gameObject);
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player Collider")
			GetComponent<EnemyDamage> ().causeDamage ();
	}
}
