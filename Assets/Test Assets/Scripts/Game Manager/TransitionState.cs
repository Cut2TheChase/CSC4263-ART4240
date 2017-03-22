using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionState : MonoBehaviour {

	private GameObject player;
	private GameObject camera;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		player.GetComponent<playerMovement> ().enabled = false;
		camera.GetComponent<Fade> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		player.GetComponent<Transform> ().Translate (new Vector3(0.06f, 0, 0));
		player.GetComponent<Animator> ().SetInteger ("State", 1);

	}
}
