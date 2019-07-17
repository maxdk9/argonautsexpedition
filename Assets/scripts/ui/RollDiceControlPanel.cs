using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class RollDiceControlPanel : MonoBehaviour
{
	
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
		this.gameObject.SetActive(true);
	}

	public void Hide()
	{
		this.gameObject.SetActive(false);
	}


	public void BackButtonClick()
	{
		new 	 GoToNextGamePhase(GamePhase.BattleView).AddToQueue();
	}
	
}
