///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that loads a scene when a transition needs to be made.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public static SceneLoader instance = null;

	private GameObject player;
	private float health;

	void Awake () {

		//if there is no other instance, this is the instance
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad(gameObject);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (SceneManager.GetActiveScene ().buildIndex != 5) {
				Debug.Log ("GONNA BOSS IT UP");
				GameManager.instance.changeState ("transitionIn");
				SceneManager.LoadScene (5, LoadSceneMode.Single);
			}
		}
	}

	public void LoadScene(int scene){
		player = GameObject.FindGameObjectWithTag ("Player");
		//If player exists in scene, grab health
		if (player != null) {
			health = player.GetComponent<PlayerHealth> ().currentHealth;
			SceneManager.activeSceneChanged += grabHealth;
		}
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	void grabHealth(Scene previousScene, Scene newScene)
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		Debug.Log ("HI");
		//if new scene has player, give them the prev scene's player health
		if (player != null) {
			player.GetComponent<PlayerHealth> ().currentHealth = health;
			player.GetComponent<PlayerHealth> ().resetSlider ();
		}
		SceneManager.activeSceneChanged -= grabHealth;
	}
}
