using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDestination : MonoBehaviour {

	public GameObject fishingRod;
	public Transform castpoint;

	void Start () 
	{
		castpoint = this.transform;
		
	}


	void OnMouseDown()
	{
		if (fishingRod.GetComponent<drawLine> ().isCast == false) {
			fishingRod.GetComponent<drawLine> ().destination = castpoint; 
		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		//fishingRod.GetComponent<drawLine> ().destination = castpoint;
		castpoint = this.transform;
	}
}
