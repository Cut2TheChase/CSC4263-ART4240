///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code to determine the actual play state of the game.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour {

	private GameObject player;
	private GameObject feetColl;
	private GameObject[] enemies;

	public GameObject tree_boss;
	public GameObject player_char;

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");
		feetColl = GameObject.FindGameObjectWithTag ("Feet Collider");
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		//Put the feet collider underneath the player
		feetColl.transform.position = player.transform.position;

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
	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds (time);
	}

	public void Update()
	{

		player_char = GameObject.FindGameObjectWithTag ("Player");
		tree_boss = GameObject.FindGameObjectWithTag ("Boss");

		if (tree_boss != null && tree_boss.GetComponent<FlickState>().playerFlicked == true) 
		{
			player_char.GetComponent<playerMovement>().canMoveY = true;
		}

	}

}
