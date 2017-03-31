using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log ("Hey now, you're a rockstar");
		this.GetComponent<Collider2D> ().attachedRigidbody.SendMessage ("OnTriggerEnter2D", other);
	}

}
