using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {


	public GameObject nightBackground;



	public float Zoom1;
	public float Zoom2;

	public float ypos1;
	public float ypos2;

	public float duration = 1.0f;
	private float elapsed = 0.0f;
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

			//Camera.main.GetComponent<CameraMovement>().ypos = Mathf.Lerp(ypos1, ypos2, elapsed);

			if (elapsed > 1.0f) {
				zoomOut = false;
			}
			nightBackground.transform.localScale += new Vector3(0.1f, 0.1f, 0);


		}
		if (zoomIn == true) 
		{
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.Lerp (Zoom2, Zoom1, elapsed);

			//Camera.main.GetComponent<CameraMovement>().ypos = Mathf.Lerp(ypos1, ypos2, elapsed);

			if (elapsed > 1.0f) {
				zoomIn = false;
			}
			nightBackground.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
		}

	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Feet Collider"){
			zoomOut = true;
			elapsed = 0.0f;
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Feet Collider"){
			zoomIn = true;
			elapsed = 0.0f;
		}
	}
}
