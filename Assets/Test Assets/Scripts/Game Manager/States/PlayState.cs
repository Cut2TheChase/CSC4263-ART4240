using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour {

	private GameObject player;
	private GameObject feetColl;
	private GameObject[] enemies;

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");
		feetColl = GameObject.FindGameObjectWithTag ("Feet Collider");
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		//Put the feet collider underneath the player
		feetColl.transform.position = player.transform.position + new Vector3 (0, -0.6f, 0);

		//Turn player-controlled movement on
		player.GetComponent<playerMovement> ().enabled = true;

		//Turn enemy AI on
		foreach (GameObject go in enemies) {
			go.GetComponent<EnemyAttackState> ().enabled = true;
		}

	}

	void OnDisable(){
		Debug.Log ("Hey Pal");
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject go in enemies) {
			go.GetComponent<EnemyAttackState> ().enabled = false;
		}
	}

}
