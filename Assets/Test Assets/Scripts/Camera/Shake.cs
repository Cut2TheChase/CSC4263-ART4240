using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

	public float duration;
	public float magnitude;

	public BoxCollider2D Bounds;
	public EdgeCollider2D Ground;

	private Vector3 
	_min, 
	_max,
	_minY,
	_maxY;

	public void Start()
	{
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		_minY = Ground.bounds.min;
		_maxY = Ground.bounds.max;
	}

	//Starts the shaking
	public void Shaker(){
		StartCoroutine (Shakey());
	}

	//Does the actual shaking
	public IEnumerator Shakey(){
		float elapsed = 0.0f;

		Vector3 originalCamPos = Camera.main.transform.position;

		while (elapsed < duration) {
			var x_pos = transform.position.x;
			var y_pos = transform.position.y;

			var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);





			elapsed += Time.deltaTime;
			float percentComplete = elapsed / duration;

			float damper = 1.0f - Mathf.Clamp (4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			//map value to [-1,1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;



			x *= magnitude * damper;
			y *= magnitude * damper;

			x_pos = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
			y_pos = Mathf.Clamp (y, _minY.y + GetComponent<Camera> ().orthographicSize, _max.y - GetComponent<Camera> ().orthographicSize);

			Camera.main.transform.position = new Vector3 (x_pos, y_pos, transform.position.z);//new Vector3 (x, y, originalCamPos.z);

			yield return null;
		}

		Camera.main.transform.position = originalCamPos;
	}

	public void Update()
	{

		var x_pos = transform.position.x;
		var y_pos = transform.position.y;

		var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

		x_pos = Mathf.Clamp (x_pos, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y_pos = Mathf.Clamp (y_pos, _minY.y + GetComponent<Camera> ().orthographicSize, _max.y - GetComponent<Camera> ().orthographicSize);

	}
}
