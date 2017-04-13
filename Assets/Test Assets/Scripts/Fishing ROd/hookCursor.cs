using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookCursor : MonoBehaviour {

	public int width,
		height;
	public Texture2D cursorTexture;
	private Texture2D oldCursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot;
	public itemEquip item_equiped;
	[HideInInspector]
	public bool entered;

	void Start()
	{
		oldCursorTexture = item_equiped.currentCursorTexture;
	}

	void OnMouseOver()
	{
		//entered = true;
		oldCursorTexture = item_equiped.currentCursorTexture;
		if (item_equiped.currentCursorTexture != null) 
		{	
			
			Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
		}
	}

	void OnMouseExit()
	{
		Cursor.SetCursor(oldCursorTexture, hotSpot, cursorMode);
		//entered = false;
	}

	void Update()
	{
		if (entered == true) 
		{
			
		}
	}

}
