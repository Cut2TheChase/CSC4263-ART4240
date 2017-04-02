using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {

	public bool Left;
	public bool Right;
	public swing2 hilt;
	public swing blade;


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			if (Right == true) {
				blade.active = true;
				hilt.active = true;
			}
			else if (Left == true) 
			{
				blade.active = false;
				hilt.active = false;
			}

		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			if (Right == true) {
				blade.active = true;
				hilt.active = true;
			}
			else if (Left == true) 
			{
				blade.active = false;
				hilt.active = false;
			}

		} 
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			if (Left == true) {
				blade.active = true;
				hilt.active = true;
			} 
			else if (Right == true) 
			{
				blade.active = false;
				hilt.active = false;
			}
		}
		else if (Input.GetKey (KeyCode.A)) 
		{
			if (Left == true) {
				blade.active = true;
				hilt.active = true;
			}
			else if (Right == true) 
			{
				blade.active = false;
				hilt.active = false;
			}

		} 

	}
    
}