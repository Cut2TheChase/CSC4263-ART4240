using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float counter;
	private float dist;
	public bool isCast;

	public Transform origin;
	public Transform destination;

	public float lineDrawSpeed = 6f;


	void Start () 
	{
		lineRenderer = GetComponent<LineRenderer> ();
		//lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetWidth (.45f, .45f);

		dist = Vector3.Distance (origin.position, destination.position);
		isCast = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//lineRenderer.SetPosition (0, origin.position);
		//destination = 
		dist = Vector3.Distance (origin.position, destination.position);

		if (Input.GetKeyDown(KeyCode.E))
		{
			lineRenderer.SetPosition (0, origin.position);
			if (isCast == false) {
				isCast = true;
			} else {
				isCast = false;
				destination = null;
			}
				
		}
		if (isCast == true) 
		{
			if (counter < dist) {

				counter += .1f / lineDrawSpeed;

				float x = Mathf.Lerp (0, dist, counter);

				Vector3 pointA = origin.position;
				Vector3 pointB = destination.position;


				Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;


				lineRenderer.SetPosition (1, pointAlongLine);

			
			}


		}
		if (isCast== false) 
		{

			lineRenderer.SetPosition (0, origin.position);
			lineRenderer.SetPosition (1, origin.position);
			counter = 0;
			//destination = null;

		}
	}
}
