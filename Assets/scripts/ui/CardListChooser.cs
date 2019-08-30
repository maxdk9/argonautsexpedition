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
using Object = System.Object;

public class CardListChooser : ModalPanel{

	public static CardListChooser instance;
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
	}

	
	
	
	public void Hide()
	{
		//base.Hide();
		this.gameObject.SetActive(false);
	}
	public void FillByCards(List<CardManager.Card> cards)
	{
		VisualTool.RemoveChildrensFromTransform(CardListContent.transform);
		
		foreach (CardManager.Card VARIABLE in cards)

		{	
			GameObject slot=Instantiate(Visual.instance.prefabBasicRect,CardListContent.transform);
			RectTransform transform  =slot.GetComponent<RectTransform>();
			VisualTool.SetAnchorPreset(transform);
			
			GameObject cmObject = OneCardManager.CreateOneCardManager(VARIABLE, slot);
			VisualTool.SetAnchorPreset(cmObject.GetComponent<RectTransform>());
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
