using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInit : MonoBehaviour {

	private GameObject boss;
	// Use this for initialization
	void Start () {
		boss = GameObject.FindGameObjectWithTag ("Boss");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D()
	{
		boss.GetComponent<TreeBossManager> ().nextState ();
		Destroy (gameObject);
	}
}
