///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code for managing the behaviour of game state changes.
///Author -- Chase Bernard?
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeBehaviour : MonoBehaviour {

	public string state; //The state that the trigger is activating to change to
	public int sceneChange = -1; //if there is a scene change, say what scene should be changed to
	public bool destroyOnTrigger; //Should this be destroyed when triggered?

	void OnTriggerEnter2D(){
		GameManager.instance.changeState (state);

		if (sceneChange != -1) {
			GameManager.instance.GetComponent<FadeOut> ().setTransitionScene (sceneChange);
		}

		if (destroyOnTrigger == true)
			DestroyObject (gameObject);
	}
}
