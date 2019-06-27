using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class Game : MonoBehaviour
{
	private int currentEnemyIndex = 0;
	public List <CardManager.Card> currentDeck=new List<CardManager.Card>();
	
	public List <CardManager.Card> reserveDeck=new List<CardManager.Card>();
	
	public List <CardManager.Card> currentEncounter=new List<CardManager.Card>();
	
	public List <CardManager.Card> wrathCards=new List<CardManager.Card>();
	
	public List <CardManager.Card> userItems=new List<CardManager.Card>();
	
	public List <CardManager.Card> discardPile=new List<CardManager.Card>();
	
	public List <CardManager.Card> winningPile=new List<CardManager.Card>();
	
	public List<HeroicDeed> HeroicDeedList=new List<HeroicDeed>();
	public List <Effect> CardEffects=new List<Effect>();
	
	
	private int crewNumber;
	private int casualties;
	private bool rerollDaedalusWing=false;
	private int winnedHD;
	private int heroicCount=0;
	private int scyllaCasualties;
	
	private int ToWork=0;
	private int TutorialCounter=0;
	
	private GamePhase currentState;
	
	private int deployedCrew=0;
	

	public int CrewNumber
	{
		get { return crewNumber; }
		set { crewNumber = value; }
	}

	public int Casualties
	{
		get { return casualties; }
		set { casualties = value; }
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
		get { return scyllaCasualties; }
		set { scyllaCasualties = value; }
	}

	


	
	

	
	
	
	
	
	
	
	
	//CONSTANTS
	public static int CREWNUMBERSTART=12;



	public static Game instance;

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

	public  void StartNewGame()
	{
		currentDeck.Clear();
		reserveDeck.Clear();
		currentEncounter.Clear();
		wrathCards.Clear();
		userItems.Clear();
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
