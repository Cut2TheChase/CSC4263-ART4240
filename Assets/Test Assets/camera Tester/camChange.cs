using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public GameObject player;
	void OnTriggerEnter2D(Collider2D other)
	{
		cam1.enabled = false;
		cam2.enabled = true;
		cam3.enabled = false;
	}

}
