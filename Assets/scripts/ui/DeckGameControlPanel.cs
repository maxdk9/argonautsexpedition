using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;


public class DeckGameControlPanel : MonoBehaviour {

	public static DeckGameControlPanel instance;
	
	
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
		this.gameObject.SetActive(true);
		SetButtonsVisibility();
	}

	private void SetButtonsVisibility()
	{
		
		
		EndTurnButton.gameObject.SetActive(GameLogic.CurrentEncounterResolved());
		
	}

	public void Hide()
	{
		this.gameObject.SetActive(false);
		//canvas.enabled = false;
	}


	public void EndTurnButtonClick()
	{
		new 	 GoToNextGamePhase(GamePhase.EndTurn).AddToQueue();
	}
}
