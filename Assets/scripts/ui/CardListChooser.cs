using System;
using System.Collections;
using System.Collections.Generic;
using GameActors;
using Model;
using UnityEngine;

public class CardListChooser : MonoBehaviour
{

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
		this.gameObject.SetActive(true);
	}

	public void Hide()
	{
		this.gameObject.SetActive(false);
	}

	public void FillByCards(List<CardManager.Card> cards)
	{
		foreach (CardManager.Card VARIABLE in cards)

		{
			GameObject cmObject = OneCardManager.CreateOneCardManager(VARIABLE, CardListContent);
		}
	}
	
}
