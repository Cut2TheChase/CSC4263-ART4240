using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}






	// Update is called once per frame
	void Update () {

	}



	public IEnumerator callShake()
	{
		Camera.main.GetComponent<Shake> ().Shaker ();

		yield return null;
	}


}
