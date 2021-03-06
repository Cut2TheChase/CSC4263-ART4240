﻿///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages transitions in game state.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	MonoBehaviour[] comps;
	MonoBehaviour FadeIn;
	MonoBehaviour FadeOut;

	string state = "transitionIn";

	void Awake () {

		//if there is no other instance, this is the instance
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);


		DontDestroyOnLoad(gameObject);

		//Grabs all the scripts associated with this object
		comps = GetComponents<MonoBehaviour> ();
		FadeIn = GetComponent<FadeIn>();
		FadeOut = GetComponent<FadeOut>();
	}

	//Called in order to change the state
	public void changeState(string newState)
	{
		state = newState;

		//Turn off every other script except this one
		foreach (MonoBehaviour c in comps) {
			if (c != this)
				c.enabled = false;
		}
			
			
		Camera.main.GetComponent<PauseMenu> ().enabled = false;
		if (state == "transitionIn") {
			GetComponent<TransitionInState> ().enabled = true;

		} else if (state == "transitionOut") {
			GetComponent<TransitionOutState> ().enabled = true;
			
		} else if (state == "play") {
			GetComponent<PlayState> ().enabled = true;
			Camera.main.GetComponent<PauseMenu> ().enabled = true;

		} else if (state == "death") {
			GetComponent<DeathState> ().enabled = true;
		}

	}
		
}
