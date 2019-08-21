using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListChooser : MonoBehaviour
{

	public static CardListChooser instance;
	public GameObject CardScrollList;

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
}
