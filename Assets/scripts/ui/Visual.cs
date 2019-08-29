using System.Collections;
using System.Collections.Generic;
using GameActors;
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
	
	[Header("CardPoints")]
	public GameObject CardPoint;
	public GameObject CardPointOutside;
	public GameObject CardPointDiscard;
	public GameObject CardPointWinning;
	public GameObject CardPointShuffle;
	
	[Header("VisualObjects")]
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
	public GameObject cardListChooser;
	
	

	public Sprite ThumbsUp;
	public Sprite ThumbsDown;

	[Header("Prefabs")]
	public GameObject particleHeal;
	public GameObject particleHealCrew;
	public GameObject prefabCardListChooser;
	


	private void Awake()
	{
		instance = this;	
	}

	public void DisableVisualElementsOnStateEnter()
	{
		
		CardDeckFrame.gameObject.SetActive(false);
		ResultPanel.instance.Hide();
		RollDiceResultBar.instance.Hide();
		DeckGameControlPanel.instance.Hide();
		Tooltip.instance.HideTooltip();
		HoverPreview.StopAllPreviews();
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
		return GetCardManagerListFromParent(Visual.instance.CurrentEncounter.transform);
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
		
		return GetCardManagerListFromParent(Visual.instance.CardDeckFrame.transform);
	}


	public void MainVisualTest()
	{
		TestTools.VisualTest();
	}

	public List<OneCardManager> GetCurrentTreasures()
	{
		return GetCardManagerListFromParent(Visual.instance.TreasureHand.transform);
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

	public void InitializeGameObjects()
	{
		cardListChooser = Instantiate(prefabCardListChooser,ScreenManager.instance.DeckgameCanvas.transform,false);
	}

	public List<OneCardManager> GetCardManagerListFromParent(Transform parent)
	{
		OneCardManager[] cards = parent.GetComponentsInChildren<OneCardManager>();
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
	
	
	
	
}
