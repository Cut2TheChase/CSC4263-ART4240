using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {

	public float depth = 10.0F;
	bool showFishCursor;

	void Start () 
	{
		showFishCursor = false;
		gameObject.GetComponent<Renderer> ().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			gameObject .GetComponent<Renderer>().enabled = !gameObject .GetComponent<Renderer>().enabled;
			showFishCursor = !showFishCursor;
		}
		Vector3 temp = Input.mousePosition;
		temp.z = depth;
		this.transform.position = Camera.main.ScreenToWorldPoint (temp);
	}


	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		this.gameObject.GetComponent<SpriteRenderer>().color = Color.black; 


	}

	void OnMouseDown()
	{   
		if (showFishCursor = true) 
		{
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow; 
			StartCoroutine (ExecuteAfterTime (1));
		}
	}
}
