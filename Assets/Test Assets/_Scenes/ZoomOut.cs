using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

	public float Zoom1;
	public float Zoom2;

	public float ypos1;
	public float ypos2;

	public float duration = 1.0f;
	private float elapsed = 0.0f;
	private bool zoomOut = false;

	void Start () {
		Camera.main.orthographic = true;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomOut) 
		{
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.Lerp (Zoom1, Zoom2, elapsed);

			//Camera.main.GetComponent<CameraMovement>().ypos = Mathf.Lerp(ypos1, ypos2, elapsed);

			if (elapsed > 1.0f) {
				zoomOut = false;
			}

		}

	
	}
	void OnTriggerStay2D(Collider2D other) {
		if(other.name == "Player"){
			zoomOut = true;
			elapsed = 0.0f;
		}
	}
}
