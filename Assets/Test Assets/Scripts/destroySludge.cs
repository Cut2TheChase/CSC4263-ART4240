using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySludge : MonoBehaviour {


	public GameObject sludge;
	public GameObject rangedEnemy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (rangedEnemy.GetComponent<RangedEnemyHealth> ().health < 1) {
			Destroy(sludge.GetComponent<SludgeSpawn>());
		}
		
	}

	 


}
