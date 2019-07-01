using System.Collections;
using System.Collections.Generic;
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
	public GameObject CardDeck;
	public GameObject CardDeckFrame;
	public GameObject CrewCounter;
	public GameObject CurrentEncounter;
	public Button buttonToBattle;

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
		CardDeck.gameObject.SetActive(false);
	}
	
	
	
	public void UpdateCrewCounter()
	{
		TextMeshProUGUI t = CrewCounter.GetComponentInChildren<TextMeshProUGUI>();
		int c = Game.instance.CrewNumber - Game.instance.DeployedCrew;
		t.text = c.ToString();
	}


	public void ToBattelButtonClick()
	{
		CrewAssignment.ourInstance.ToBattle();
	}


	public static List <OneCardManager> GetCurrentEncounter()
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
}
