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


	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>();
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		t = (Time.time - startTime) / durationOut;
		fader.color = new Color(0f,0f,0f,Mathf.SmoothStep(minimum,maximum,t));
		StartCoroutine ("Fading");

	}

	IEnumerator Fading()
	{
		yield return new WaitForSeconds(5);	

		this.enabled = false;
	}
}
