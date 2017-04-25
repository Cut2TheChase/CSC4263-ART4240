using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSection : MonoBehaviour {
	GameObject player;
	public GameObject platform;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(){
		player.GetComponent<playerMovement> ().enabled = false;
		player.GetComponent<Animator> ().SetInteger ("State", 0);
		platform.GetComponent<vanishPlatform> ().enabled = true;
		Destroy (gameObject);
	}
}
