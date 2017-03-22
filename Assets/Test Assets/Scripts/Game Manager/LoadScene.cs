using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;
		
	// Use this for initialization
	void Awake () {
		myLoadedAssetBundle = AssetBundle.LoadFromFile ("Assets/Test Assets/_Scenes");
		scenePaths = myLoadedAssetBundle.GetAllScenePaths ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Load(string name){
		SceneManager.LoadScene (name, LoadSceneMode.Single);
		GameManager.instance.changeState ("TransitionInState");
	}
}
