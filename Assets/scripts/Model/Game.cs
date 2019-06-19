using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class Game : MonoBehaviour
{
	private int currentEnemyIndex = 0;
	private List <CardManager.Card> currentDeck=new List<CardManager.Card>();
	private List <CardManager.Card> reserveDeck=new List<CardManager.Card>();
	private List <CardManager.Card> currentEncounter=new List<CardManager.Card>();
	private List <CardManager.Card> wrathCards=new List<CardManager.Card>();
	private List <CardManager.Card> userItems=new List<CardManager.Card>();
	private List <CardManager.Card> discardPile=new List<CardManager.Card>();
	private List <CardManager.Card> winningPile=new List<CardManager.Card>();
	
	public List<HeroicDeed> HeroicDeedList=new List<HeroicDeed>();
	private List <Effect> CardEffects=new List<Effect>();
	
	
	private int crewNumber;
	private int casualties;
	private bool rerollDaedalusWing=false;
	private int winnedHD;
	private int heroicCount=0;
	private int scyllaCasualties;
	
	public int ToWork=0;
	public int TutorialCounter=0;
	
	
	
	
	
	
	
	
	//CONSTANTS
	public static int CREWNUMBERSTART;



	public static Game instance;
	

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
