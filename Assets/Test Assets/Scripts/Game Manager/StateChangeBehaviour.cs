using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeBehaviour : MonoBehaviour {

	public string state; //The state that the trigger is activating to change to
	public bool destroyOnTrigger; //Should this be destroyed when triggered?

	void OnTriggerEnter2D(){
		GameManager.instance.changeState (state);

		if (destroyOnTrigger == true)
			DestroyObject (this);
	}
}
