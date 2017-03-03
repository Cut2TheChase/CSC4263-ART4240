using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwap : MonoBehaviour {


	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public GameObject player;
	public bool change1 = false;
	public bool change2 = true;
	public bool change3 = false;

	void Start()
	{
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
	}




	void OnTriggerEnter2D(Collider2D other)
	{
		
		cam1.enabled = false;
		cam2.enabled = true;
		cam3.enabled = false;

	}

}
