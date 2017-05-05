using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	public Button back;

	// Use this for initialization
	void Start () {
		Button ply = back.GetComponent<Button>();
		ply.onClick.AddListener(TaskOnClick);
	}
	
	public void TaskOnClick()
	{
		SceneManager.LoadScene(0, LoadSceneMode.Single); //loads the Main Menu
	}
}
