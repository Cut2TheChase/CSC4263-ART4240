using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBossManager : MonoBehaviour {

	private MonoBehaviour[] bossAttackLoop; //The active loop the boss follows
	private int numbOfComp = 2; //number of States

	private int currentState; //The state to be enabled next

	public int health;

	private bool[] canUse;
	void Start () {
		currentState = -1;

		//We start by putting the Boss attack States (components) within the loop in the order we want
		bossAttackLoop = new MonoBehaviour[numbOfComp];
		bossAttackLoop [0] = GetComponent<EnemySpawnState> ();
		bossAttackLoop [1] = GetComponent<TauntState> ();

		//Now we specify which ones can be used in the very beginning of the fight
		canUse = new bool[] {true,true};
	}
	
	//Determines which States are able to be played in the active loop based on boss' HP
	void Update () {
		if (health <= 0) {
			Debug.Log ("IM DED X_X");
		}
	}

	//Begins the next State
	public void nextState(){
		//If the fight has not begun yet, let it begin
		if (currentState == -1) {
			GetComponent<SleepState> ().enabled = false;
			currentState = 0;
			bossAttackLoop [currentState].enabled = true;
		}
		//If the fight has begun, cycle to the next usable state
		else {
			currentState++;	

			if (currentState == numbOfComp) //If currentState is over the array bounds, go back to 0
				currentState = 0;

			if (canUse [currentState] == true) {

				bossAttackLoop [currentState].enabled = true;
			} else //Go to the next state if this one cant be used yet
				nextState ();
		}
	}
}
