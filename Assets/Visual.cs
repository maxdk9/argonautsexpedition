using System.Collections;
using System.Collections.Generic;
using Model;
using Model.States;
using screen;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Visual : MonoBehaviour
{

	public static Visual instance;
	
	
	public GameObject CardPoint;
	public GameObject CardPointOutside;
	
	public GameObject CardDeckFrame;
	public GameObject CrewCounter;
	public GameObject CurrentEncounter;
	public Button buttonToBattle;
	
	public GameObject currentDiceEncounter;
	public GameObject mainDice;
	public Image RollDiceImage;
	
	

	public Sprite ThumbsUp;
	public Sprite ThumbsDown;


	private void Awake()
	{
		instance = this;
	
		
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void DisableVisualElementsOnStateEnter()
	{
		buttonToBattle.gameObject.SetActive(false);
		CardDeckFrame.gameObject.SetActive(false);
		ResultPanel.instance.panelCanvas.gameObject.SetActive(false);
		
		if (CrewAssigner.instance != null)
		{
			CrewAssigner.instance.Hide();	
		}
		
	}
	
	
	
	public void UpdateCrewCounter()
	{
		TextMeshProUGUI t = CrewCounter.GetComponentInChildren<TextMeshProUGUI>();
		int c = Game.instance.CrewNumber - Game.instance.DeployedCrew;
		t.text = c.ToString();
	}


	public void ToBattelButtonClick()
	{
		new GoToNextGamePhase(GamePhase.BattleView).AddToQueue();
	}


	public  List <OneCardManager> GetCurrentEncounter()
	{
		OneCardManager[] cards = Visual.instance.CurrentEncounter.GetComponentsInChildren<OneCardManager>();
		List<OneCardManager>  result=new List<OneCardManager>();
		foreach (OneCardManager card in cards)
		{
			HoverPreview preview = card.GetComponent<HoverPreview>();
			if (preview == null)
			{
				continue;    
			}
			result.Add(card);
		}
		return result;
	}
	
	
	

	public void UpdateOneCardManagerVisibility()
	{
		List<OneCardManager> encList = GetCurrentEncounter();
		foreach (OneCardManager enc in encList)
		{
			enc.SetVisibility();
		}
	}

	public CardManager.Card GetCardByNumberFromCurrentEncounter()
	{
		List<OneCardManager> encList = GetCurrentEncounter();
		foreach (OneCardManager cm in encList)
		{
			if (cm.cardAsset.cardnumber == Game.instance.nu)
			{
				return cm.cardAsset;
			}
		}

		return null;
	}
}
