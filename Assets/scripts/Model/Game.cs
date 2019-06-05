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
	
	private int crewNumber;
	private int casualties;
	private bool rerollDaedalusWing=false;
	private int winnedHD;
	private int heroicCount=0;
	
	public List<HeroicDeed> HeroicDeedList=new List<HeroicDeed>();
	
	private List <Effect> CardEffects=new List<Effect>();
	
	public int ToWork=0;
	public int TutorialCounter=0;
	private int scyllaCasualties;
	
		
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
