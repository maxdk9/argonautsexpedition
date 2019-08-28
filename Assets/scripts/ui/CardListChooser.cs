using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using common;
using GameActors;
using Model;
using screen;
using ui;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardListChooser : ModalPanel{

	public static CardListChooser instance;
	public GameObject CardScrollList;
	public GameObject CardListContent;

	private void Awake()
	{
		instance = this;
		this.gameObject.SetActive(false);
	}

	public void Show()
	{
		//base.Show();
		this.gameObject.SetActive(true);
		turnControls(false);
	}

	public void turnControls(bool enable)
	{

		Tooltipable[] tooltipables = ScreenManager.instance.DeckgameCanvas.GetComponentsInChildren<Tooltipable>();
		foreach (var VARIABLE in tooltipables)
		{
			VARIABLE.enabled = enable;
		}

		tempTouchComponent[] tempTouchComponents =
			ScreenManager.instance.DeckgameCanvas.GetComponentsInChildren<tempTouchComponent>();
		foreach (var VARIABLE in tempTouchComponents)
		{
			VARIABLE.enabled = enable;
		}
	
		Button[] buttons =
			Visual.instance.GetComponentsInChildren<Button>();
		foreach (var VARIABLE in tempTouchComponents)
		{
			VARIABLE.enabled = enable;
		}

	}
	
	
	public void Hide()
	{
		//base.Hide();
		turnControls(true);
		this.gameObject.SetActive(false);
	}
	public void FillByCards(List<CardManager.Card> cards)
	{
		foreach (CardManager.Card VARIABLE in cards)

		{
			GameObject cmObject = OneCardManager.CreateOneCardManager(VARIABLE, CardListContent);
		}
	}

	public void AddComponentToCards<T>() where T : Component
	{
		List<OneCardManager> cardList = Visual.instance.GetCardManagerListFromParent(this.CardListContent.transform);
		foreach (OneCardManager cm in cardList)
		{
			cm.gameObject.AddComponent<T>();
			
		}
		
	}
}
