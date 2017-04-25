using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDrowning : MonoBehaviour {
	GameObject player;
	public float moveTo;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(){
		player.transform.position = new Vector2(moveTo, player.transform.position.y);
	}
}
