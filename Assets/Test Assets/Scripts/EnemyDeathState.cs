using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : MonoBehaviour {






	void Start () {
		
	}



	void OnEnable () {
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
