using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	GameObject fader;
	int fade = 0;
	float alpha;
	Color tmp;

	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		fader = GameObject.FindGameObjectWithTag ("Fader");
		alpha = fader.GetComponent<SpriteRenderer> ().color.a;
		//if Fader is 100% seeable
		if (fader.GetComponent<SpriteRenderer> ().color.a == 255) {
			fade = 1; //Fade In
		} else {
			fade = -1; //Fade Out
		}


		coroutine = Fading ();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (coroutine);
		if (fade == 1) {
			
			if (fader.GetComponent<SpriteRenderer> ().color.a > 0) {
				tmp = fader.GetComponent<SpriteRenderer> ().color;
				tmp.a = tmp.a - 5f;
				fader.GetComponent<SpriteRenderer> ().color = tmp;
			}
			
			else
				this.enabled = false;

		} else if (fade == -1) {

			if (fader.GetComponent<SpriteRenderer> ().color.a < 255) {
				tmp = fader.GetComponent<SpriteRenderer> ().color;
				tmp.a = tmp.a + 5f;
				fader.GetComponent<SpriteRenderer> ().color = tmp;
			} else
				GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<LoadScene> ().Load ("SecondTestLevel");
		}

	}

	IEnumerator Fading()
	{
		yield return new WaitForSeconds(0.2f);	
	}
}
