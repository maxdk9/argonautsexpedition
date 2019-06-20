using System.Collections;
using System.Collections.Generic;
using screen;
using tools;
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
		ScreenManager.instance.Show(ScreenManager.ScreenType.Deckgame);
		GameManager.instance.StartNewGame();
	}

	public void ResumeGame()
	{
		
	}

	public void TestGame()
	{
		ScreenManager.instance.Show(ScreenManager.ScreenType.Testscreen);
		TestTools.TestFillDeck();
	}
	
	
}
