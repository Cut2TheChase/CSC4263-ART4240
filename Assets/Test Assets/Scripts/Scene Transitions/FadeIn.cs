﻿///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that fades in from black as the game transitions to another scene.
///Author -- Chase Bernard, Michael Marchese
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

	bool canDeactivate;

	void OnEnable () {
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>();
		startTime = Time.time;
		canDeactivate = true;
	}

	void Update () {
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>(); //Gotta put this here because when I change levels...ugh
		    //Used to smoothly transition into the scene using time
			t = (Time.time - startTime) / durationIn;
			fader.color = new Color(0f,0f,0f,Mathf.SmoothStep(maximum,minimum,t));
		if (fader.color == new Color (0f, 0f, 0f, minimum) /*&& canDeactivate == true*/) {
			//canDeactivate = false;
			//StartCoroutine ("Fading");
			this.enabled = false;
		}
	}

	//Says how long to wait until turning off the script
	IEnumerator Fading()
	{
		yield return new WaitForSeconds(5);	
		this.enabled = false;
	}
}
