using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camF : MonoBehaviour 
{
	public Transform Player;

	public Vector2 
		Margin, 
		Smoothing;

	public BoxCollider2D Bounds;
	public EdgeCollider2D Ground;

	private Vector3 
		_min, 
		_max,
		_minY,
		_maxY;
		

	public bool isFollowing { get; set; }

	public void Start()
	{
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		_minY = Ground.bounds.min;
		_maxY = Ground.bounds.max;
		isFollowing = true;
	}

	public void Update()
	{
		var x = transform.position.x;
		var y = transform.position.y;

		if (isFollowing) 
		{
			if (Mathf.Abs (x - Player.position.x) > Margin.x)
				x = Mathf.Lerp (x, Player.position.x, Smoothing.x * Time.deltaTime);

			if (Mathf.Abs (y - Player.position.y) > Margin.y)
				y = Mathf.Lerp (y, Player.position.y, Smoothing.y * Time.deltaTime);
		}

		var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _minY.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);


		transform.position = new Vector3 (x, y, transform.position.z);
	}

}
