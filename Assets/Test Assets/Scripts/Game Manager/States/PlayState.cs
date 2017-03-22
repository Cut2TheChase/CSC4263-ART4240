using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour {

	private GameObject player;
	private GameObject feetColl;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		feetColl = GameObject.FindGameObjectWithTag ("Feet Collider");
		feetColl.transform.position = player.transform.position + new Vector3 (0, -0.6f, 0);
		player.GetComponent<playerMovement> ().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
