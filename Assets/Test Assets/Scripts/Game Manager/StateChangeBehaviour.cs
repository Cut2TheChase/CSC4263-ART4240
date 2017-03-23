using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeBehaviour : MonoBehaviour {

	public string state; //The state that the trigger is activating to change to
	public bool destroyOnTrigger;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(){
		GameManager.instance.changeState (state);
		if (destroyOnTrigger == true)
			DestroyObject (this);
	}
}
