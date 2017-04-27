using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCameraBounds : MonoBehaviour {



	public bool change;
	public BoxCollider2D oldBounds;
	public EdgeCollider2D oldGround;
	public BoxCollider2D newBounds;
	public EdgeCollider2D newGround;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(change ==true)
		{
			Camera.main.GetComponent<camF> ().Bounds = newBounds;
			Camera.main.GetComponent<camF> ().Ground = newGround;

		}
		if(change ==false)
		{
			Camera.main.GetComponent<camF> ().Bounds = oldBounds;
			Camera.main.GetComponent<camF> ().Ground = oldGround;

		}
			
		
	}



	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Feet Collider"){
			change = true;
			//elapsed = 0.0f;
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Feet Collider"){
			change = false;
			//elapsed = 0.0f;
		}
	}

}
