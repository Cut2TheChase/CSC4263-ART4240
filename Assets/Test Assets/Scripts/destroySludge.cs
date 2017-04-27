using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySludge : MonoBehaviour {


	public GameObject sludge;
	public GameObject rangedEnemy;

	private SpriteRenderer fader;
	private float t;
	private float durationOut = 1.5f;
	private bool gotStart = false;
	private float startTime;

	private bool destroyWall = false;

	// Use this for initialization
	void Start () {
		fader = sludge.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (rangedEnemy.GetComponent<RangedEnemyHealth> ().health < 1) {
			Destroy(sludge.GetComponent<SludgeSpawn>());
			if (gotStart == false) {
				startTime = Time.time;
				gotStart = true;
			}
			t = (Time.time - startTime) / durationOut;
			fader.color = new Color(fader.color.r,fader.color.g,fader.color.b,Mathf.SmoothStep(1,0,t));

			if (destroyWall == false) {
				
				Destroy (GameObject.Find("Wall"));
				destroyWall = true;

			}
		}
		
	}

	 


}
