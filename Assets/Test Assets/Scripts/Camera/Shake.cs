using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

	public float duration;
	public float magnitude;

	public BoxCollider2D Bounds;
	public EdgeCollider2D Ground;

	public GameObject player;

	private Vector3 
	_min, 
	_max,
	_minY,
	_maxY;

	public bool isShaking;

	//
	//public float Zoom1;
	//public float Zoom2;

//	public float ypos1;
//	public float ypos2;
	//
//	public float duration2 = 1.0f;
//	private float elapsed2 = 0.0f;
//	public bool zoomOut = false;
//	public bool zoomIn = false;
	//


	public void Start()
	{
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		_minY = Ground.bounds.min;
		_maxY = Ground.bounds.max;
	}

	//Starts the shaking
	public void Shaker(){
		//StartCoroutine (zoomCam (4));
		StartCoroutine (Shakey());
	}

	//
	//public IEnumerator zoomCam(float time)
	//{
	//	zoomOut = true;
	//	elapsed2 = 0.0f;
	//	yield return new WaitForSeconds(time);
	//	zoomIn = true;

//	}
	//


	//Does the actual shaking
	public IEnumerator Shakey(){
		float elapsed = 0.0f;

		Vector3 originalCamPos = Camera.main.transform.position;

		while (elapsed < duration) {
			var x_pos = transform.position.x;
			var y_pos = transform.position.y;

			var cameraHalfWidth = Camera.main.GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);





			elapsed += Time.deltaTime;
			float percentComplete = elapsed / duration;

			float damper = 1.0f - Mathf.Clamp (4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			//map value to [-1,1]
			float x = player.transform.position.x + (Random.value * 2.0f - 1.0f);
			float y = player.transform.position.y + (Random.value * 2.0f - 1.0f);



			x *= magnitude * damper;
			y *= magnitude * damper;

			x_pos = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
			y_pos = Mathf.Clamp (y , _minY.y + Camera.main.GetComponent<Camera> ().orthographicSize, _max.y - Camera.main.GetComponent<Camera> ().orthographicSize);

			Camera.main.transform.position = new Vector3 (x_pos, y_pos, transform.position.z);//new Vector3 (x, y, originalCamPos.z);

			yield return null;
		}
		isShaking = false;
		//Camera.main.transform.position = originalCamPos;
	}

	public void Update()
	{
		if (isShaking == true) {
			StartCoroutine (Shakey ());
		}
	

		//
	//	if (zoomOut) 
	//	{
	//		elapsed2 += Time.deltaTime / duration2;
	//		Camera.main.orthographicSize = Mathf.Lerp (Zoom1, Zoom2, elapsed2);
		//

		//	if (elapsed2 > 1.0f) {
		//		zoomOut = false;
		//	}
		//
		//}
		//if (zoomIn == true) 
		//{
		//	elapsed2 += Time.deltaTime / duration2;
		//	Camera.main.orthographicSize = Mathf.Lerp (Zoom2, Zoom1, elapsed2);
		//
		//
		//	if (elapsed2 > 1.0f) {
		//		zoomIn = false;
		//	}

		//}


		//


		//var x_pos = transform.position.x;
		//var y_pos = transform.position.y;

		//var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

		//x_pos = Mathf.Clamp (x_pos, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		//y_pos = Mathf.Clamp (y_pos, _minY.y + GetComponent<Camera> ().orthographicSize, _max.y - GetComponent<Camera> ().orthographicSize);

	}
}
