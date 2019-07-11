using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class DeckGameControlPanel : MonoBehaviour {

	public Canvas canvas;
	public static DeckGameControlPanel instance;


	private void Awake()
	{
		instance = this;
		Hide();
	}

	private void Update()
	{
		Debug.Log("UpdateDeckgameControl");
	}

	public void Show()
	{
		canvas.enabled = true;
	}

	public void Hide()
	{
		canvas.enabled = false;
	}


	public void EndTurn()
	{
		new 	 GoToNextGamePhase(GamePhase.EndTurn).StartCommandExecution();
	}
}
