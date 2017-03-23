using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
	SpriteRenderer fader;
	float t;
	float minimum = 0f;
	float maximum = 1f;
	float durationOut = 1f;
	private float startTime;


	void OnEnable () {
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>();
		startTime = Time.time;
	}
		
	void Update () {
		//Used to smoothly transition out of the scene using time
		t = (Time.time - startTime) / durationOut;
		fader.color = new Color(0f,0f,0f,Mathf.SmoothStep(minimum,maximum,t));
		StartCoroutine ("Fading");

	}

	//Says how long to wait until turning off the script
	IEnumerator Fading()
	{
		yield return new WaitForSeconds(3);	
		SceneLoader.instance.LoadScene (2);
		this.enabled = false;
		GameManager.instance.changeState ("transitionIn");
	}
}
