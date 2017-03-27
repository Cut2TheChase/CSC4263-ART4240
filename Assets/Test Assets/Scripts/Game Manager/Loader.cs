﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public GameObject gameManager;
	public GameObject sceneLoader;

	void Awake () {
		//if there is no GameManager object, make one
		if (GameManager.instance == null)
			Instantiate (gameManager);

		//if there is no SceneLoader object, make one
		if (SceneLoader.instance == null)
			Instantiate (sceneLoader);
		
	}

}