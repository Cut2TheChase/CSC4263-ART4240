using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeSpawn : MonoBehaviour {


	private GameObject topBounds;
	private GameObject botBounds;
	private GameObject player;

	private bool enemiesKilled =false;
	public bool deadRangedEnemy = false;

	private GameObject e1;
	private GameObject e2;
	private GameObject e3;
	private GameObject e4;
	private GameObject e5;

	public GameObject enemy;



	void OnEnable () 
	{



	}


	public IEnumerator respawn (float time)
	{
		//yield return new WaitForSeconds (time);
		//enemiesKilled = true;
		e1 = Instantiate (enemy, new Vector3 (189, -2.32f, 0f), Quaternion.identity);
		e1.GetComponent<EnemyAttackState> ().range = 10;
		e2 = Instantiate (enemy, new Vector3 (188, -2f, 0f), Quaternion.identity);
		e2.GetComponent<EnemyAttackState> ().range = 10;
		e3 = Instantiate (enemy, new Vector3 (184.6f, -2f, 0f), Quaternion.identity);
		e3.GetComponent<EnemyAttackState> ().range = 10;
		e4 = Instantiate (enemy, new Vector3 (186, -3f, 0f), Quaternion.identity);
		e4.GetComponent<EnemyAttackState> ().range = 10;
		e5 = Instantiate (enemy, new Vector3 (191.1f, -2.6f, 0f), Quaternion.identity);
		e5.GetComponent<EnemyAttackState> ().range = 10;
		yield return new WaitForSeconds (time);
		enemiesKilled = false;

		
	}
	void Update(){
	
	//	if (enemiesKilled == true && deadRangedEnemy == false) {
	//		enemiesKilled = false;
	//		e1 = Instantiate (enemy, new Vector3 (50, -2.32f, 0f), Quaternion.identity);
	//		e1.GetComponent<EnemyAttackState> ().range = 10;
	//		e2 = Instantiate (enemy, new Vector3 (51, -2f, 0f), Quaternion.identity);
	//		e2.GetComponent<EnemyAttackState> ().range = 10;
	//		e3 = Instantiate (enemy, new Vector3 (50.6f, -2f, 0f), Quaternion.identity);
	//		e3.GetComponent<EnemyAttackState> ().range = 10;
	//		e4 = Instantiate (enemy, new Vector3 (49, -3f, 0f), Quaternion.identity);
	//		e4.GetComponent<EnemyAttackState> ().range = 10;
	//		e5 = Instantiate (enemy, new Vector3 (48.1f, -2.6f, 0f), Quaternion.identity);
	//		e5.GetComponent<EnemyAttackState> ().range = 10;
	//
	//	}
	
	//if (e1 == null & e2 == null && e3 == null && e4 == null && e5 == null)
	//	{
		if (enemiesKilled == false) {
			StartCoroutine (respawn (9));
			enemiesKilled = true;
		}

	//}
	}
	
}