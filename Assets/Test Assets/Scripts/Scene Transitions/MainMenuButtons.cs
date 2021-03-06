﻿///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that handles the functionality of GUI buttons that transition
///from the Main Menu Scene to the play scene and exit the game.
///Author -- Mitchell Aucoin, Chase Bernard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Button playB;
    public Button menuB;
    public Button exitB;
    
    //sees when buttons are activated, calls functions to handle what the button does
    void Start()
    {
        Button ply = playB.GetComponent<Button>();
        ply.onClick.AddListener(TaskOnClick);

        Button men = menuB.GetComponent<Button>();
        men.onClick.AddListener(TaskOnClick1);

        Button ext = exitB.GetComponent<Button>();
        ext.onClick.AddListener(TaskOnClick2);


    }
    //the following three functions determine what happens when the buttons are pressed
    public void TaskOnClick()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single); //loads the first scene
		SceneManager.sceneLoaded += OnSceneLoaded; //Once scene is loaded, do this function
    }
    public void TaskOnClick1()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Single);
    }
    public void TaskOnClick2()
    {
        Application.Quit(); // exits the game
    }
    //cleans up death scene issues
	private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
	{
		GameManager.instance.changeState ("transitionIn");
		SceneManager.sceneLoaded -= OnSceneLoaded; //Keeps the changeState from automatically being transitionIn after you die more than once
		//Still dont quite understand this thing^
	}
}