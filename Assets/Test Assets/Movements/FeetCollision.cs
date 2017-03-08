using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollision : MonoBehaviour {


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	} 

	/*This function will be called by the playerMovement script when a player
	wants to go vertical or horizontal, the collider will move first and if it
	collides with something will return to its previous position and tell the
	playerMovement script they cant move, otherwise it will give the script an
	ok to move */

	public bool canMove(Vector3 speed){
		gameObject.GetComponent<Transform> ().Translate (speed);
		//If collider is touching any collider in the layer 'Ground Collision', will return false
		if (gameObject.GetComponent<CircleCollider2D>().IsTouchingLayers (LayerMask.GetMask ("GroundCollision"))) {
			
			return false;
		} else {
			return true;
		}

	}
		
		

}
