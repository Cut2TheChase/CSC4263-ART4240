using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	MonoBehaviour[] comps;

	// Use this for initialization
	string state = "transition";
	void Awake () {

		//if there is no other instance, this is the instance
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);


		DontDestroyOnLoad(gameObject);

		comps = GetComponents<MonoBehaviour> ();
	}

	void changeState(string newState)
	{
		state = newState;

		foreach (MonoBehaviour c in comps) {
			if (c != this && c != GetComponent<LoadScene>())
				c.enabled = false;
		}

		if (state == "transition") {
			GetComponent<TransitionState>().enabled = true;

		} else if (state == "play") {
			
		}

	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
