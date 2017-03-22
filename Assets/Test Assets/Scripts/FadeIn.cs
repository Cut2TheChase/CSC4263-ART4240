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


	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
			t = (Time.time - startTime) / durationIn;
			fader.color = new Color(0f,0f,0f,Mathf.SmoothStep(maximum,minimum,t));
			StartCoroutine ("Fading");

	}

	IEnumerator Fading()
	{
		yield return new WaitForSeconds(5);	
		this.enabled = false;
	}
}
