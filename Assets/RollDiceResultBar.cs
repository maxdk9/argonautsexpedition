using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using Model;
using Model.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RollDiceResultBar : MonoBehaviour
{


	public Image IconCrew;
	public TextMeshProUGUI CrewCounter;
	public Image IconDice;
	public Image IconMonster;
	public TextMeshProUGUI MonsterCounter;
	public Image PowerUpImage;
	public TextMeshProUGUI PowerUpCounter;
	public Sprite [] FlatDiceImages;
	private int ShowY = -100;
	private int HideY = -400;


	public static RollDiceResultBar instance;

	private void Awake()
	{
		instance = this;
		this.gameObject.SetActive(false);
	}

	public void Show()
	{
		this.transform.DOLocalMoveY(HideY, 0);
		
		CardManager.Card card = Battle.ourInstance.currentDiceEncounterOneCardManager.cardAsset;

		bool showPowerUp = GameLogic.GetPowerUp(card) != 0;		
		PowerUpImage.gameObject.SetActive(showPowerUp);
		PowerUpCounter.gameObject.SetActive(showPowerUp);

		CrewCounter.text = card.crewNumber.ToString();
		MonsterCounter.text = GameLogic.GetCurrentDifficulty(card).ToString();
		
		if (showPowerUp)
		{
			PowerUpCounter.text = GameLogic.GetPowerUp(card).ToString();
		}

		IconDice.sprite = FlatDiceImages[Game.instance.DiceEncounterNumber-1];
		this.gameObject.SetActive(true);
		this.transform.DOLocalMoveY(ShowY,.7f);

	}

	public void Hide()
	{
		this.gameObject.SetActive(false);
	}
	
}
