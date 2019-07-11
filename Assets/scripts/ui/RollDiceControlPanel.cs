using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class RollDiceControlPanel : MonoBehaviour
{
	public Canvas canvas;
	public Button buttonBack;
	public static RollDiceControlPanel instance;


	private void Awake()
	{
		instance = this;
		Hide();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Show()
	{
		canvas.enabled = true;
	}

	public void Hide()
	{
		canvas.enabled = false;
	}


	public void BackButtonClick()
	{
		new 	 GoToNextGamePhase(GamePhase.BattleView).StartCommandExecution();
	}
	
}
