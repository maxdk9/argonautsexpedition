﻿using System.Collections;
using System.Collections.Generic;
using screen;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void GoToMainMenu()
	{
		ScreenManager.instance.Show(ScreenManager.ScreenType.Mainmenu);
	}


	public void OptionsButton()
	{
		ScreenManager.instance.Show(ScreenManager.ScreenType.Options);
	}


	public void StartNewGame()
	{
		
	}

	public void ResumeGame()
	{
		
	}
	
}
