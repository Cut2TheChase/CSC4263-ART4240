///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that handles the functionality of GUI buttons that transition
///from the Main Menu Scene to the play scene and exit the game.
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float parallaxSpeed;
	private float lastCameraX;

	// Use this for initialization
	void Start () {
		lastCameraX = Camera.main.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Camera.main.transform.position.x - lastCameraX;
		lastCameraX = Camera.main.transform.position.x;

		transform.position += Vector3.right * (deltaX * parallaxSpeed);
	}
}
