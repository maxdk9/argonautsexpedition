using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;


public class DeckGameControlPanel : MonoBehaviour {

	public static DeckGameControlPanel instance;
	
	public Canvas canvas;
	public Button EndTurnButton;

	

	private void Awake()
	{
		
		instance = this;
		Hide();
	}

	private void Update()
	{
		
	}

	public void Show()
	{
		canvas.enabled = true;
		SetButtonsVisibility();
	}

	private void SetButtonsVisibility()
	{
		
		
		EndTurnButton.gameObject.SetActive(GameLogic.CurrentEncounterResolved());
		
	}

	public void Hide()
	{
		canvas.enabled = false;
	}


	public void EndTurnButtonClick()
	{
		new 	 GoToNextGamePhase(GamePhase.EndTurn).AddToQueue();
	}
}
