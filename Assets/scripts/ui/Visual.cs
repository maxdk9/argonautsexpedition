using System.Collections;
using System.Collections.Generic;
using Model;
using Model.States;
using screen;
using tools;
using TMPro;
using ui;
using UnityEngine;
using UnityEngine.UI;

public class Visual : MonoBehaviour
{

	public static Visual instance;
	
	
	public GameObject CardPoint;
	public GameObject CardPointOutside;
	public GameObject CardPointDiscard;
	public GameObject CardPointWinning;
	public GameObject CardPointShuffle;
	
	public GameObject CardDeckFrame;
	public GameObject CrewCounter;
	public GameObject LossCounter;
	public GameObject CurrentEncounter;
	public GameObject TreasureHand;
	public GameObject EffectGroup;

	public GameObject transparentModalWindow;
	
	
	public GameObject currentDiceEncounter;
	public GameObject mainDice;
	public Image RollDiceImage;
	
	

	public Sprite ThumbsUp;
	public Sprite ThumbsDown;


	public GameObject particleHeal;
	public GameObject particleHealCrew;
	


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
		
		CardDeckFrame.gameObject.SetActive(false);
		ResultPanel.instance.Hide();
		RollDiceResultBar.instance.Hide();
		DeckGameControlPanel.instance.Hide();
		Tooltip.instance.HideTooltip();
		if (Game.instance.CurrentState == GamePhase.Draw3QuestCards)
		{
			Visual.instance.EffectGroup.SetActive(false);
		}
		else
		{
			Visual.instance.EffectGroup.SetActive(true);
		}
		
		if (CrewAssigner.instance != null)
		{
			CrewAssigner.instance.Hide();	
		}
		DialogActivateSingleUsedTreasure.instance.Hide();
		
	}
	
	
	
	public void UpdateCrewCounter()
	{
		TextMeshProUGUI t = CrewCounter.GetComponentInChildren<TextMeshProUGUI>();
		int c = Game.instance.CrewNumber - Game.instance.DeployedCrew;
		t.text = c.ToString();
	}

	public void UpdateLossCounter()
	{
		TextMeshProUGUI t = LossCounter.GetComponentInChildren<TextMeshProUGUI>();
		if (t != null)
		{
			if (Game.instance.Casualties == 0)
			{
				LossCounter.gameObject.SetActive(false);
				return;
			}
			LossCounter.gameObject.SetActive(true);
			
			t.text = Game.instance.Casualties.ToString();	
		}
		
	}



	public  List <OneCardManager> GetCurrentEncounter()
	{
		OneCardManager[] cards = Visual.instance.CurrentEncounter.GetComponentsInChildren<OneCardManager>();
		List<OneCardManager>  result=new List<OneCardManager>();
		foreach (OneCardManager card in cards)
		{
			
			if (card.isPreview)
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

	public CardManager.Card GetCardByNumberFromCurrentEncounter(int index)
	{
		List<OneCardManager> encList = GetCurrentEncounter();
		foreach (OneCardManager cm in encList)
		{
			if (cm.cardAsset.cardnumber == index)
			{
				return cm.cardAsset;
			}
		}

		return null;
	}

	public CardManager.Card GetCurrentEnemyCard()
	{
		return GetCardByNumberFromCurrentEncounter(Game.instance.CurrentEnemyIndex);
	}
	


	public void UpdateCounters()
	{
		UpdateCrewCounter();
		UpdateLossCounter();
	}

	public List<OneCardManager> GetCurrentDeck()
	{
		OneCardManager[] cards = Visual.instance.CardDeckFrame.GetComponentsInChildren<OneCardManager>();
		List<OneCardManager>  result=new List<OneCardManager>();
		foreach (OneCardManager card in cards)
		{
			
			if (card.isPreview)
			{
				continue;    
			}
			result.Add(card);
		}
		return result;		
	}


	public void MainVisualTest()
	{
		TestTools.VisualTest();
	}

	public List<OneCardManager> GetCurrentTreasures()
	{
		OneCardManager[] cards = Visual.instance.TreasureHand.GetComponentsInChildren<OneCardManager>();
		List<OneCardManager>  result=new List<OneCardManager>();
		foreach (OneCardManager card in cards)
		{
			
			if (card.isPreview)
			{
				continue;    
			}
			result.Add(card);
		}
		return result;
	}

	

	public void TestButtonAboveEverything()
	{
		Debug.Log("ButtonAboveEverything Worked!");
	}

	public void disableInput(bool b)
	{
		transparentModalWindow.SetActive(b);
	}

	public static bool CardIsEncounter(OneCardManager oneCardManager)
	{
		List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
		return enclist.Contains(oneCardManager);
	}
}
