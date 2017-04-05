using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : MonoBehaviour {

	private bool canUse = true; //This State can be used at the boss' current health

	private float startTime;
	public float tauntDuration;

	// Use this for initialization
	void OnEnable () {
		GetComponent<CircleCollider2D> ().enabled = true;
		startTime = Time.time;
	}

	void OnDisable(){
		GetComponent<CircleCollider2D> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= tauntDuration) {
			this.enabled = false;
			GetComponent<TreeBossManager>().nextState ();
		}
	}

	public bool getCanUse(){
		return canUse;
	}
}
