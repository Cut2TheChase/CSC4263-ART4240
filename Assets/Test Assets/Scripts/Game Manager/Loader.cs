using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public GameObject gameManager;

	void Awake () {
		//if there is no GameManager object, make one
		if (GameManager.instance == null)
			Instantiate (gameManager);
	}

}
