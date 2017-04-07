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

	}

	public void LoadScene(int scene){
		SceneManager.LoadScene (scene, LoadSceneMode.Single);

	}
}
