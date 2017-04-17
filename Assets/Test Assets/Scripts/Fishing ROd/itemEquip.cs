using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemEquip : MonoBehaviour {

	public Texture2D rod_cursor;
	[HideInInspector]
	public Texture2D nextCursorTexture;
	[HideInInspector]
	public Texture2D currentCursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	[HideInInspector]
	public bool rod;
	public Vector2 hotSpot;

	void Start () 
	{
		rod = false;
		currentCursorTexture = null;

	}
	
	void Update () 
	{
		if (!rod) {
			nextCursorTexture = rod_cursor;
			hotSpot = new Vector2 (16, 16);

		} else {
			nextCursorTexture = null;
			hotSpot = Vector2.zero;
		}



		if (Input.GetKeyDown(KeyCode.Q))
			{
			Cursor.SetCursor(nextCursorTexture, hotSpot, cursorMode);
			rod = !rod;
			currentCursorTexture = nextCursorTexture;
			}	
	}
}
