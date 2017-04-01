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

	private int sceneIndex;

	bool canDeactivate;

	void OnEnable () {
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>();
		startTime = Time.time;
		canDeactivate = true;
	}
		
	void Update () {
		//Used to smoothly transition out of the scene using time
		fader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer>(); //Gotta put this here because when I change levels...ugh
		t = (Time.time - startTime) / durationOut;
		fader.color = new Color(0f,0f,0f,Mathf.SmoothStep(minimum,maximum,t));

		if (fader.color == new Color (0f, 0f, 0f, maximum) && canDeactivate == true) {
			canDeactivate = false;
			StartCoroutine ("Fading");
		}

	}

	//Sets the scene to transition to once the fade is over
	public void setTransitionScene(int scene){
		sceneIndex = scene;

	}

	//Says how long to wait until turning off the script
	IEnumerator Fading()
	{
		yield return new WaitForSeconds(3);	
		SceneLoader.instance.LoadScene (sceneIndex);
		if (sceneIndex != 3) {
			GameManager.instance.changeState ("transitionIn");
		}
		this.enabled = false;
	}
}
