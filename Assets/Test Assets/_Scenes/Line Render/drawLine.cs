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
	public GameObject destination2;

	public float lineDrawSpeed = 6f;
	public GameObject player;

	void Start () 
	{
		lineRenderer = GetComponent<LineRenderer> ();                       //cache line renderer
		lineRenderer.SetWidth (.1f, .1f);                                   //set line width

		dist = Vector3.Distance (origin.position, destination.position);    //calculate initial distance
		isCast = false;                                                     //line should not be cast on start
		
	}

	// waits for a given amount of time and then resets the line 
	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds (time);
		isCast = false;
		destination = null;
		lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetPosition (1, origin.position);
		counter = 0;
	}

	// Update is called once per frame
	void Update () 
	{

		//sets distance in the direction from origin point to destination of line
		dist = Vector3.Distance (origin.position, destination.position);

		//if player has rod equiped then determine if the fishing rod will be cast or retracted
		if (player.GetComponent<itemEquip> ().rod == true) 
		{	
			if (Input.GetMouseButtonDown (0)) // left mouse click
			{
				lineRenderer.SetPosition (0, origin.position); //the first element of the line = origin object position

				//if line is not cast then it should be cast and vice versa
				if (isCast == false) 
				{
					isCast = true;
				} 
				else
				{
					isCast = false;
					destination = null; 
					destination2.GetComponent<boxPull>().isHooked = false;
					player.GetComponent<playerMovement> ().notHooked = true;

					player.GetComponent<Animator> ().SetBool ("hookDone", true);

					destination2.GetComponent<boxPull>().pulled = false;

				}
				
			}

			if (Input.GetKey(KeyCode.E))
			{
				StartCoroutine (ExecuteAfterTime (1));
			}

			//if line is to be cast then draw line from origin to destinatino over time
			if (isCast == true) {
				if (counter < dist) {

					counter += .1f / lineDrawSpeed;   

					float x = Mathf.Lerp (0, dist, counter);

					Vector3 pointA = origin.position;
					Vector3 pointB = destination.position;


					Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA; 


					lineRenderer.SetPosition (1, pointAlongLine);
					lineRenderer.SetPosition (0, origin.position);
				}
			}

			//if line should not be cast line is rendered from origin to origin (ie not rendered)
			if (isCast == false) 
			{
				lineRenderer.SetPosition (0, origin.position);
				lineRenderer.SetPosition (1, origin.position);
				counter = 0;                                    // reset line draw timer
			}
		}
	}
}
