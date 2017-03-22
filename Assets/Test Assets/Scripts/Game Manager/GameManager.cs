using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	MonoBehaviour[] comps;

	// Use this for initialization
	string state = "transitionIn";
	void Awake () {

		//if there is no other instance, this is the instance
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);


		DontDestroyOnLoad(gameObject);

		comps = GetComponents<MonoBehaviour> ();
	}

	public void changeState(string newState)
	{
		state = newState;

		foreach (MonoBehaviour c in comps) {
			if (c != this)
				c.enabled = false;
		}

		GetComponent<LoadScene> ().enabled = true;

		if (state == "transitionIn") {
			GetComponent<TransitionInState>().enabled = true;

		} else if (state == "transitionOut") {
			GetComponent<TransitionOutState>().enabled = true;
			
		} else if (state == "play") {
			GetComponent<PlayState>().enabled = true;

		}

	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
