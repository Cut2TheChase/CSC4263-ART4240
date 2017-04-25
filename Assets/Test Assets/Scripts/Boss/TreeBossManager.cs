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
	private int numbOfComp = 8; //number of States

	private int currentState; //The state to be enabled next

	public float health;
	public float maxHealth;
	private float healthPercent; //Says what health percentage the Boss is at

	private bool[] canUse;
	void Start () {
		currentState = -1; //currentState starts at -1, because boss isnt fighting yet

		health = maxHealth;

		//We start by putting the Boss attack States (components) within the loop in the order we want
		bossAttackLoop = new MonoBehaviour[numbOfComp];
		bossAttackLoop [0] = GetComponent<EnemySpawnState> ();
		bossAttackLoop [1] = GetComponent<SwipeState> ();
		bossAttackLoop [2] = GetComponent<SwipeState2> ();
		bossAttackLoop [3] = GetComponent<FlickState> ();
		bossAttackLoop [4] = GetComponent<SlamScript> ();
		bossAttackLoop [5] = GetComponent<SlamScript2> ();
		bossAttackLoop [6] = GetComponent<TauntState> ();
		bossAttackLoop [7] = GetComponent<TiredState> ();

		//Now we specify which ones can be used in the very beginning of the fight
		canUse = new bool[] {true,false,false,false,false,false,true,false};
	}
	
	//Determines which States are able to be played in the active loop based on boss' HP
	void Update () {
		
		healthPercent = health / maxHealth * 100;
		if (health <= 0) {
			GetComponent<Animator> ().SetInteger ("State", 8);
			Debug.Log ("IM DED X_X");

			//Turn off every other script except this one
			foreach (MonoBehaviour c in bossAttackLoop) {
				if (c != this)
					c.enabled = false;
			}
			//Go into death state
			GetComponent<BossDeathState> ().enabled = true;
		}

		else if (healthPercent <= 35) {
			//EnemySpawn, Swipe2, Flick, Slam2, Tired
			canUse = new bool[] {true,false,true,true,false,true,false,true};

		} else if (healthPercent <= 50) {
			//EnemySpawn, Swipe, Flick, Slam, Taunt
			canUse = new bool[] {true,true,false,true,true,false,true,false};

		} else if (healthPercent <= 75) {
			//EnemySpawn, Swipe, Flick, Taunt
			canUse = new bool[] {true,true,false,true,false,false,true,false};

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
