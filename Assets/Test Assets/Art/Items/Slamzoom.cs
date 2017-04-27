using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slamzoom : MonoBehaviour {

	public float Zoom1;
	public float Zoom2;

	public float ypos1;
	public float ypos2;

	public float duration = 1.0f;
	[HideInInspector]
	public float elapsed = 0.0f;
	public bool zoomOut = false;
	public bool zoomIn = false;

	void Start () {
		Camera.main.orthographic = true;


	}

	// Update is called once per frame
	void Update () {
		if (zoomOut) 
		{
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.Lerp (Zoom1, Zoom2, elapsed);


			if (elapsed > 1.0f) {
				zoomOut = false;
			}

		}
		if (zoomIn == true) 
		{
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.Lerp (Zoom2, Zoom1, elapsed);


			if (elapsed > 1.0f) {
				zoomIn = false;
			}

		}

	}

}