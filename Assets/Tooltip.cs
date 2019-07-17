using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{

	public RectTransform backgroundRectTransform;
	public TextMeshProUGUI textLabel;
	public Canvas canvas;

	public static  Tooltip instance;

	private void Awake()
	{
		instance = this;
		HideTooltip();
	}


	public void ShowTooltip(String text)
	{
		this.gameObject.SetActive(true);
		textLabel.text = text;
	}


	public void HideTooltip()
	{
		this.gameObject.SetActive(false);
	}
}
