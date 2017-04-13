///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the pause menu's functionality.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : MonoBehaviour {


	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
	   }
	}

	public void Pause()
	{
		if (gameObject.transform.GetChild (0).gameObject.activeInHierarchy == false) {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
			Time.timeScale = 0;
		} else {
			gameObject.transform.GetChild (0).gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}
}


