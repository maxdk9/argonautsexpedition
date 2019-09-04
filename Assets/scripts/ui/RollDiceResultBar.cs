using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using Model;
using Model.States;
using TMPro;
using ui;
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
	private int ShowY = -50;
	private int HideY = -400;


	public static RollDiceResultBar instance;

	private void Awake()
	{
		instance = this;
		Hide();
	}

	public void Show1()
	{
		this.transform.DOLocalMoveY(HideY, 0);
		this.gameObject.SetActive(true);
		CardManager.Card card = Visual.instance.GetCurrentEnemyCard();

		bool showPowerUp = GameLogic.GetPowerUp(card) != 0;		
		PowerUpImage.gameObject.SetActive(showPowerUp);
		PowerUpCounter.gameObject.SetActive(showPowerUp);

		CrewCounter.text = card.crewNumber.ToString();
		MonsterCounter.text = GameLogic.GetCurrentDifficulty(card).ToString();
		
		if (showPowerUp)
		{
			PowerUpCounter.text = GameLogic.GetPowerUp(card).ToString();
		}

		IconDice.sprite = FlatDiceImages[card.rollResult-1];
		
		this.transform.DOLocalMoveY(ShowY,.7f);

	}
	
	
	public void Show()
	{
		
		this.transform.DOLocalMoveY(ShowY,0f);
		this.gameObject.SetActive(true);
		CanvasGroup canvasgroup = this.GetComponent<CanvasGroup>();
		canvasgroup.alpha = 0;
		
		 
		
		
		CardManager.Card card = Visual.instance.GetCurrentEnemyCard();

		bool showPowerUp = GameLogic.GetPowerUp(card) != 0;		
		PowerUpImage.gameObject.SetActive(showPowerUp);
		PowerUpCounter.gameObject.SetActive(showPowerUp);

		CrewCounter.text = card.crewNumber.ToString();
		MonsterCounter.text = GameLogic.GetCurrentDifficulty(card).ToString();
		
		if (showPowerUp)
		{
			PowerUpCounter.text = GameLogic.GetPowerUp(card).ToString();
		}

		IconDice.sprite = FlatDiceImages[card.rollResult-1];
		FadeAlphaGraphicUI.CrossFadeAlphaFixed(canvasgroup,100,.7f,null);
		

	}

	public void Hide()
	{
		this.gameObject.SetActive(false);
	}
	
}
