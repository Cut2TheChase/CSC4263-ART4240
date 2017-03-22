using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionOutState : MonoBehaviour {

	private GameObject player;
	private GameObject mainCamera;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		player.GetComponent<playerMovement> ().enabled = false;
		mainCamera.GetComponent<FadeOut> ().enabled = true;
	}

	// Update is called once per frame
	void Update () {
		player.GetComponent<Transform> ().Translate (new Vector3(0.06f, 0, 0));
		player.GetComponent<Animator> ().SetInteger ("State", 1);

	}
}
