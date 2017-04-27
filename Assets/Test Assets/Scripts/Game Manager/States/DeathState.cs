///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages when the player is dead.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathState : MonoBehaviour {

	private GameObject player;
	private int prevScene;


	// Use this for initialization
	void OnEnable () {
		player = GameObject.FindGameObjectWithTag ("Player");
		prevScene = SceneManager.GetActiveScene().buildIndex;
		Debug.Log (prevScene);

		player.GetComponent<zAxisPlayerManager> ().enabled = false;
		player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y,-9.5f);
		GetComponent<FadeOut> ().enabled = true;
		GetComponent<FadeOut> ().setTransitionScene (3);

	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 3 ) {
			//Once the death scene is finally loaded
			if (Input.GetKey (KeyCode.R)) {
				SceneLoader.instance.LoadScene (prevScene); //Go to previous scene
				SceneManager.sceneLoaded += OnSceneLoaded; //Once scene is loaded, do this function
			} else if (Input.GetKey (KeyCode.M)) {
				SceneLoader.instance.LoadScene (0); //Go to Main Menu
			}
		}
		
	}

	private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
	{
		GameManager.instance.changeState ("transitionIn");
		SceneManager.sceneLoaded -= OnSceneLoaded; //Keeps the changeState from automatically being transitionIn after you die more than once
		//Still dont quite understand this thing^
	}
}
