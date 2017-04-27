using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformFadeIn : MonoBehaviour {
	SpriteRenderer fader;
	float t;
	float minimum = 0f;
	float maximum = 1f;
	float durationIn = 1.5f;
	private float startTime;

	// Use this for initialization
	void Start () {
		fader = GetComponent<SpriteRenderer>();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		t = (Time.time - startTime) / durationIn;
		if (fader.color != new Color (fader.color.r,fader.color.g,fader.color.b, maximum)) {
			fader.color = new Color(fader.color.r,fader.color.g,fader.color.b,Mathf.SmoothStep(minimum,maximum,t));	
		}
	}
}
