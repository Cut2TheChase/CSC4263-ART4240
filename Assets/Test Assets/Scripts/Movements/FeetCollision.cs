using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollision : MonoBehaviour {

	//Distances of the ray cast by the foot collider when going a certain direction
	 float rayDistUp = 0.5f; 
	 float rayDistDown = 0.2f;
	 float rayDistHorz = 0.3f;

	/*This function will be called by the playerMovement script when a player
	wants to go vertical or horizontal, the collider will move first and if it
	collides with something will return to its previous position and tell the
	playerMovement script they cant move, otherwise it will give the script an
	ok to move */
	public bool canMove(Vector3 speed, Vector2 rayDir){
		
		float usedRayDist;
		if (rayDir == Vector2.up)
			usedRayDist = rayDistUp;
		else if (rayDir == Vector2.down)
			usedRayDist = rayDistDown;
		else 
			usedRayDist = rayDistHorz;
		
		//If collider is touching any collider in the layer 'Ground Collision', will return false
		RaycastHit2D hit = Physics2D.Raycast (transform.position, rayDir, usedRayDist, LayerMask.GetMask ("GroundCollision"));
		//Debug.Log (hit.collider);
		if(hit.collider != null)
			return false;
		 else { 
		    gameObject.GetComponent<Transform> ().Translate (speed);
			return true;
		}


	}

    public bool canMove(float speed, Vector2 rayDir)
    {

        float usedRayDist;
        if (rayDir == Vector2.up)
            usedRayDist = rayDistUp;
        else if (rayDir == Vector2.down)
            usedRayDist = rayDistDown;
        else
            usedRayDist = rayDistHorz;

        //If collider is touching any collider in the layer 'Ground Collision', will return false
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir, usedRayDist, LayerMask.GetMask("GroundCollision"));
        if (hit.collider != null)
            return false;
        else
        {
			if(usedRayDist == rayDistUp || usedRayDist == rayDistDown)
				gameObject.GetComponent<Transform>().Translate(0,speed*Time.deltaTime,0);
			else
				gameObject.GetComponent<Transform>().Translate(speed*Time.deltaTime,0,0);
            return true;
        }


    }



}
