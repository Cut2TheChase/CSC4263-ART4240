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

	//Places enemies will spawn
	Vector3 spawn1;
	Vector3 spawn2;
	Vector3 spawn3;
	Vector3 spawn4;
	Vector3 spawn5;
	Vector3 spawn6;
	bool[] spawnsUsed;
	int whichSpawn = 0;
	Vector3 spawnAt;

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

		//Sets up spawn areas
		spawnsUsed = new bool[] { false, false, false, false, false, false };
		spawn1 = new Vector3 (transform.position.x - 10.5f, transform.position.y + 1f, transform.position.z);
		spawn2 = new Vector3 (transform.position.x - 12, transform.position.y + 2f, transform.position.z);
		spawn3 = new Vector3 (transform.position.x - 10.5f, transform.position.y + 3f, transform.position.z);
		spawn4 = new Vector3 (transform.position.x + 10.5f, transform.position.y + 1f, transform.position.z);
		spawn5 = new Vector3 (transform.position.x + 12, transform.position.y + 2f, transform.position.z);
		spawn6 = new Vector3 (transform.position.x + 10.5f, transform.position.y + 3f, transform.position.z);

		//Instantiates the spawned enemies and enables them to attack
		for (int i = 0; i < numbOfEnemies; i++) {
			do {
				whichSpawn = Random.Range (0, 5);
			} while(spawnsUsed [whichSpawn] == true);
			spawnsUsed [whichSpawn] = true;

			if (whichSpawn == 0)
				spawnAt = spawn1;
			else if (whichSpawn == 1)
				spawnAt = spawn2;
			else if (whichSpawn == 2)
				spawnAt = spawn3;
			else if (whichSpawn == 3)
				spawnAt = spawn4;
			else if (whichSpawn == 4)
				spawnAt = spawn5;
			else if (whichSpawn == 5)
				spawnAt = spawn6;
			
			GameObject spawn = Instantiate (enemy, spawnAt , Quaternion.identity) as GameObject;
			spawn.GetComponent<EnemyAttackState> ().enabled = true;
			minions [i] = spawn;
			minions [i].GetComponent<EnemyAttackState> ().range = 20; //increase these boss minions' range
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
