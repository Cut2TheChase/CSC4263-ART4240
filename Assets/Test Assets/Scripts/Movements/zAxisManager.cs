///Uptown Pigeon Gaming
///Project Fuge
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the z axis of game objects in a 2.5d world.
///Author -- Chase Bernard? Jonathan Nguyen?
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zAxisManager : MonoBehaviour {

	float zValue;

	void Update () {
		
		zValue = Mathf.Round (transform.position.y * 1000f) / 1000f; //Rounds the z value based on the entity's y position

		if (zValue > -1.1f) //Checks to make sure entities never go behind the ground
			zValue = -1.1f;
		
		transform.position = new Vector3 (transform.position.x, transform.position.y, zValue);
	}
}
