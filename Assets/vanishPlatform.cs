using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanishPlatform : MonoBehaviour {
	SpriteRenderer fader;
	GameObject player;
	GameObject footCol;
	float t;
	float minimum = 0f;
	float maximum = 1f;
	float durationIn = 2f;
	private float startTime;
	private bool fall = false;

	public float playerFallTarget;
	public GameObject enemy;

	private GameObject e1;
	private GameObject e2;
	private GameObject e3;
	private GameObject e4;
	private GameObject e5;

	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;
	public GameObject platform5;
	public GameObject platform6;
	public GameObject platform7;
	public GameObject platform8;

	// Use this for initialization
	void OnEnable () {
		fader = GetComponent<SpriteRenderer> ();
		startTime = Time.time;
		player = GameObject.FindGameObjectWithTag ("Player");
		footCol = GameObject.FindGameObjectWithTag ("Feet Collider");

	}
	
	// Update is called once per frame
	void Update () {
		t = (Time.time - startTime) / durationIn;
		fader.color = new Color(fader.color.r, fader.color.g, fader.color.b,Mathf.SmoothStep(maximum,minimum,t));
		if (fader.color != new Color (fader.color.r, fader.color.g, fader.color.b, minimum)) {
			fader.color = new Color (fader.color.r, fader.color.g, fader.color.b, Mathf.SmoothStep (maximum, minimum, t));
		} else if(fall == false){
			if (player.transform.position.y < playerFallTarget + 1) {
				fall = true;
				e1 = Instantiate (enemy, new Vector3 (114.16f, -21.32f, 0f), Quaternion.identity);
					e1.GetComponent<EnemyAttackState>().range = 10;
				e2 = Instantiate (enemy, new Vector3 (114.16f, -23f, 0f), Quaternion.identity);
				e2.GetComponent<EnemyAttackState>().range = 10;
				e3 = Instantiate (enemy, new Vector3 (126.6f, -21.32f, 0f), Quaternion.identity);
				e3.GetComponent<EnemyAttackState>().range = 10;
				e4 = Instantiate (enemy, new Vector3 (126.6f, -23f, 0f), Quaternion.identity);
				e4.GetComponent<EnemyAttackState>().range = 10;
				e5 = Instantiate (enemy, new Vector3 (118.1f, -24.6f, 0f), Quaternion.identity);
				e5.GetComponent<EnemyAttackState>().range = 10;
			}
			footCol.transform.position = new Vector2 (footCol.transform.position.x, playerFallTarget);
			player.GetComponent<playerMovement> ().enabled = true;
			player.GetComponent<playerMovement> ().jumpState = true;
		}

		if (e1 == null & e2 == null && e3 == null && e4 == null && e5 == null && fall == true)
		{
			platform1.SetActive (true);
			platform2.SetActive (true);
			platform3.SetActive (true);
			platform4.SetActive (true);
			platform5.SetActive (true);
			platform6.SetActive (true);
			platform7.SetActive (true);
			platform8.SetActive (true);

		}


	}
}
