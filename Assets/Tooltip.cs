using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour,IPointerDownHandler
{

	public RectTransform backgroundRectTransform;
	public TextMeshProUGUI textLabel;
	public Canvas canvas;
	float duration=4;

	public static  Tooltip instance;

	private void Awake()
	{
		instance = this;
		HideTooltip();
	}


	public void ShowTooltip(String text,Vector2 pos)
	{

		
		Vector3 newposition=GameManager.instance.UICamera.ScreenToWorldPoint(new Vector3(pos.x,pos.y,GameManager.instance.UICamera.nearClipPlane));
		newposition += new Vector3(30, -10, 0);
		//Vector3 newposition1 = GameManager.instance.UICamera.WorldToScreenPoint(newposition);
		
		this.transform.position = newposition;
		this.gameObject.SetActive(true);
		textLabel.text = text;
		//this.StartCoroutine(HideTooltipCoroutine());
	}

	private IEnumerator HideTooltipCoroutine()
	{
		
		yield return new WaitForSeconds(duration);
		HideTooltip();
	}


	public void HideTooltip()
	{
		this.gameObject.SetActive(false);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		HideTooltip();
	}
}
