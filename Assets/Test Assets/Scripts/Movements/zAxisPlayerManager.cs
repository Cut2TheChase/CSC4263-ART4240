///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the z axis of game objects in a 2.5d world, this one includes managing the player's jump z value
///Author -- Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zAxisPlayerManager : MonoBehaviour {
	float zValue;

	void Update () {

		//If the player is jumping, do not change the z value
		if (GetComponent<playerMovement> ().jumpState == false) {

			zValue = Mathf.Round (transform.position.y * 1000f) / 1000f; //Rounds the z value based on the entity's y position

			if (zValue > -1.1f) //Checks to make sure entities never go behind the ground
			zValue = -1.1f;

			transform.position = new Vector3 (transform.position.x, transform.position.y, zValue);
		}
	}
}
