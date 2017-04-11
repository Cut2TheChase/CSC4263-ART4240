///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that handles the functionality of GUI buttons that transition
///from the Main Menu Scene to the play scene and exit the game.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnState : MonoBehaviour {

	private GameObject[] minions;

	public int numbOfEnemies;

	private GameObject topBounds;
	private GameObject botBounds;
	private GameObject player;

	public GameObject enemy;

	private int aliveCount;

	void OnEnable () {
		topBounds = GameObject.Find("Top Ground Collider");
		botBounds = GameObject.Find ("Bottom Ground Collider");
		player = GameObject.FindGameObjectWithTag("Player");

		minions = new GameObject[numbOfEnemies];
		//Finds the position of the top and bottom ground colliders
		float yTop = topBounds.transform.position.y;
		float yBot = botBounds.transform.position.y;

		//Instantiates the spawned enemies and enables them to attack
		for (int i = 0; i < numbOfEnemies; i++) {
			float xRange = Random.Range (player.transform.position.x - 5f, player.transform.position.x + 5f);
			GameObject spawn = Instantiate (enemy, new Vector3 (xRange, Random.Range(yBot + 2f, yTop), 0), Quaternion.identity) as GameObject;
			spawn.GetComponent<EnemyAttackState> ().enabled = true;
			minions [i] = spawn;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//Checks how many enemies are still alive
		int aliveCount = numbOfEnemies;
		for (var i = 0; i < numbOfEnemies; i++) {
			if (minions [i] == null)
				aliveCount--;
		}

		//If they are all dead, run the next state
		if (aliveCount == 0) {
			GetComponent<TreeBossManager> ().nextState ();
			this.enabled = false;
		}

		
	}
}
