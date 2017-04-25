using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getOnGround : MonoBehaviour {
	public GameObject player;
	public GameObject footCol;
	public GameObject wall;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(){
		footCol.transform.position = new Vector2 (player.transform.position.x, -5.35f);
		Instantiate (wall, new Vector3 (transform.position.x - 0.2f, transform.position.y), Quaternion.identity);
		Destroy (gameObject);
	}
}
