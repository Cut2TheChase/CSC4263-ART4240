using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBossManager : MonoBehaviour {

	private MonoBehaviour[] bossAttackLoop; //The active loop the boss follows
	private int numbOfComp = 1; //number of States

	private int currentState; //The state to be enabled next

	private bool startFight = false;
	void Start () {
		currentState = -1;

		//We start by putting the Boss attack States (components) within the loop in the order we want
		bossAttackLoop = new MonoBehaviour[numbOfComp];
		bossAttackLoop [0] = GetComponent<EnemySpawnState> ();
	}
	
	//Determines which States are able to be played in the active loop
	void Update () {
		
	}

	//Begins the next State
	public void nextState(){
		if (currentState == -1) {
			GetComponent<SleepState> ().enabled = false;
			currentState = 0;
		}

		bossAttackLoop [currentState].enabled = true;
		currentState++;
	}
}
