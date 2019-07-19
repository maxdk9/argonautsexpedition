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
		Vector3 offsetPosition=Vector3.Scale(new Vector3(30,10,0),GetOffset(pos));
		newposition += offsetPosition;
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


	public static Vector3 GetOffset(Vector2 position)
	{
		if (position.x > (Screen.width / 2))
		{
			if (position.y > (Screen.height / 2))
			{
				return  new Vector3(-1,-1,0);
			}
			else
			{
				return  new Vector3(-1,1,0);

			}
		}
		else
		{
			if (position.y > (Screen.height / 2))
			{
				return  new Vector3(1,-1,0);
			}
			else
			{
				return  new Vector3(1,1,0);
			}
		}
		
		
		
	}
	
	
}
