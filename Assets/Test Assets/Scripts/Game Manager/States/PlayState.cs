using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour {

	private GameObject player;
	private GameObject feetColl;

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");
		feetColl = GameObject.FindGameObjectWithTag ("Feet Collider");

		//Put the feet collider underneath the player
		feetColl.transform.position = player.transform.position + new Vector3 (0, -0.6f, 0);

		//Turn player-controlled movement on
		player.GetComponent<playerMovement> ().enabled = true;

	}

}
