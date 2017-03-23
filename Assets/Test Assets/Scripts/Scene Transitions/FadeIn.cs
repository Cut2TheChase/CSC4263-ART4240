using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {
	SpriteRenderer fader;
	float t;
	float minimum = 0f;
	float maximum = 1f;
	float durationIn = 1.5f;
	private float startTime;


	void OnEnable () {
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>();
		startTime = Time.time;
	}

	void Update () {
		    //Used to smoothly transition into the scene using time
			t = (Time.time - startTime) / durationIn;
			fader.color = new Color(0f,0f,0f,Mathf.SmoothStep(maximum,minimum,t));
		    //StartCoroutine ("Fading");
	}

	//Says how long to wait until turning off the script
	IEnumerator Fading()
	{
		yield return new WaitForSeconds(5);	
		Debug.Log ("Whoa Nelly");
		this.enabled = false;
	}
}
