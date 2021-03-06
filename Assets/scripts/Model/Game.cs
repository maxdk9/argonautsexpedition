﻿using System.Collections;
using System.Collections.Generic;
using Model;
using tools;
using UnityEngine;

[System.Serializable]
public class Game 
{
	
	public List <CardManager.Card> currentDeck=new List<CardManager.Card>();
	
	public List <CardManager.Card> reserveDeck=new List<CardManager.Card>();
	
	public List <CardManager.Card> currentEncounter=new List<CardManager.Card>();
	
	public List <CardManager.Card> wrathCards=new List<CardManager.Card>();
	
	public List <CardManager.Card> TreasureHand=new List<CardManager.Card>();
	
	public List <CardManager.Card> discardPile=new List<CardManager.Card>();
	
	public List <CardManager.Card> winningPile=new List<CardManager.Card>();
	
	public List<HeroicDeed> HeroicDeedList=new List<HeroicDeed>();
	public List <Effect> CardEffects=new List<Effect>();
	
	
	
	[SerializeField]
	private int currentEnemyIndex = 0;
	[SerializeField]
	private int crewNumber;
	[SerializeField]
	private int casualties;
	[SerializeField]
	private bool rerollDaedalusWing=false;
	[SerializeField]
	private int winnedHD;
	[SerializeField]
	private int heroicCount=0;
	[SerializeField]
	private int scyllaCasualties;
	[SerializeField]
	private int ToWork=0;
	[SerializeField]
	private int TutorialCounter=0;
	[SerializeField]
	private GamePhase currentState;
	[SerializeField]
	private int deployedCrew=0;
	

	public int CrewNumber
	{
		get { return crewNumber; }
		set { crewNumber = value; }
	}

	public int Casualties
	{
		get { return casualties; }
		set
		{
			
			casualties = value;
			GameLogicEvents.eventUpdateLossCounter.Invoke();
		}
	}

	public bool RerollDaedalusWing
	{
		get { return rerollDaedalusWing; }
		set { rerollDaedalusWing = value; }
	}

	public int WinnedHd
	{
		get { return winnedHD; }
		set { winnedHD = value; }
	}

	public int HeroicCount
	{
		get { return heroicCount; }
		set { heroicCount = value; }
	}

	public int ScyllaCasualties
	{
		get
		{
			return scyllaCasualties; 
		}
		set { scyllaCasualties = value; }
	}
	
	
	//CONSTANTS
	public static int CREWNUMBERSTART=12;
	
	
	public static Game instance;

	public Game()
	{
		instance = this;
	}

	public GamePhase CurrentState
	{
		get { return currentState; }
		set { currentState = value; }
	}

	public int DeployedCrew
	{
		get { return deployedCrew; }
		set { deployedCrew = value; }
	}


	public int CurrentEnemyIndex
	{
		get { return currentEnemyIndex; }
		set { currentEnemyIndex = value; }
	}

	public  void StartNewGame()
	{
		currentDeck.Clear();
		reserveDeck.Clear();
		currentEncounter.Clear();
		wrathCards.Clear();
		TreasureHand.Clear();
		discardPile.Clear();
		winningPile.Clear();
		HeroicDeedList.Clear();
		CardEffects.Clear();
		
		casualties = 0;
		rerollDaedalusWing=false;
		winnedHD=0;
		heroicCount=0;
		scyllaCasualties=0;
		ToWork=0;
		deployedCrew = 0;

		
		
		crewNumber = CREWNUMBERSTART;
		
		CardManager.Instance().Shuffle();

		foreach (CardManager.Card card in CardManager.Instance().shuffledList)
		{

			CardManager.ResetCard(card);
			if (card.reserve)
			{
				reserveDeck.Add(card);
			}
			else
			{
				currentDeck.Add(card);	
			}
			
		}
		
		
		
		
	}
}
