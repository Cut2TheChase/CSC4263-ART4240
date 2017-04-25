using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeTrigger : MonoBehaviour {


	public GameObject sludge;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other)
	{
		sludge.GetComponent<SludgeSpawn> ().enabled = true;
	}
}
