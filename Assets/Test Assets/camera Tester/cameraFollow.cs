using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public GameObject player;

	Vector3 offset;  // create this object to edit the generic offset of the camera

	void Start () 
	{
		offset = transform.position - player.transform.position;
	}


	void LateUpdate ()   // Late update function is another update function that happens after every other update function has been called
	{
		transform.position = player.transform.position + offset;
	}
}

