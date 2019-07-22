using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class DeckGameControlPanel : MonoBehaviour {

	public static DeckGameControlPanel instance;
	
	
	public Button EndTurnButton;
	public Button buttonToBatte;
	public Button buttonBackFromRollDice;

	

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

		
		
		EndTurnButton.gameObject.SetActive(Game.instance.CurrentState == GamePhase.BattleView && GameLogic.CurrentEncounterResolved());	
		
		
		buttonToBatte.gameObject.SetActive(Game.instance.CurrentState==GamePhase.CrewAssignment);
		buttonBackFromRollDice.gameObject.SetActive(Game.instance.CurrentState==GamePhase.BattleEnd);
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
	
	
	
	public void ToBattelButtonClick()
	{
		new GoToNextGamePhase(GamePhase.BattleView).AddToQueue();
	}
	
	
	public void buttonBackFromRollDiceClick()
	{
		new GoToNextGamePhase(GamePhase.BattleView).AddToQueue();
	}
}
