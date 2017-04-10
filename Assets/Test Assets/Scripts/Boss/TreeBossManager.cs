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

public class TreeBossManager : MonoBehaviour {

	private MonoBehaviour[] bossAttackLoop; //The active loop the boss follows
	private int numbOfComp = 5; //number of States

	private int currentState; //The state to be enabled next

	public int health;

	private bool[] canUse;
	void Start () {
		currentState = -1; //currentState starts at -1, because boss isnt fighting yet

		//We start by putting the Boss attack States (components) within the loop in the order we want
		bossAttackLoop = new MonoBehaviour[numbOfComp];
		bossAttackLoop [0] = GetComponent<EnemySpawnState> ();
		bossAttackLoop [1] = GetComponent<SwipeState> ();
		bossAttackLoop [2] = GetComponent<FlickState> ();
		bossAttackLoop [3] = GetComponent<SlamScript> ();
		bossAttackLoop [4] = GetComponent<TauntState> ();

		//Now we specify which ones can be used in the very beginning of the fight
		canUse = new bool[] {false,true,false,true,false};
	}
	
	//Determines which States are able to be played in the active loop based on boss' HP
	void Update () {
		if (health <= 0) {
			Debug.Log ("IM DED X_X");

			//Turn off every other script except this one
			foreach (MonoBehaviour c in bossAttackLoop) {
				if (c != this)
					c.enabled = false;
			}
			//Go into death state
			GetComponent<BossDeathState> ().enabled = true;
		}
	}

	//Begins the next State
	public void nextState(){
		//If Fight hasnt started yet, take out of sleep state and begin fight
		if (currentState == -1)
			GetComponent<SleepState> ().enabled = false;
		
			//Change States only if the tree is alive 
			//(Makes sure this function doesnt change states when boss transitions to death state)
			if (health > 0) {
				currentState++;	
			Debug.Log (currentState);
				if (currentState == numbOfComp) //If currentState is over the array bounds, go back to 0
				currentState = 0;

				if (canUse [currentState] == true) {
				    
					bossAttackLoop [currentState].enabled = true;
				} else //Go to the next state if this one cant be used yet
				nextState ();
			}
	}
}
