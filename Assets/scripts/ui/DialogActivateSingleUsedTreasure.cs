using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization;
using Model;
using TMPro;
using ui;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogActivateSingleUsedTreasure : ModalPanel
{

	public static DialogActivateSingleUsedTreasure instance;
	public TextMeshProUGUI header;
	public Button buttonOk;
	public Button buttonCancel;
	public GameObject EffectActorObject;
	public OneCardManager activatedCard;
	public EffectActor effectActor;
	
	

	

	private void Awake()
	{
		instance = this;
		effectActor = this.EffectActorObject.GetComponent<EffectActor>();
		Hide();
	}


	public void Hide()
	{
		base.Hide();
		this.gameObject.SetActive(false);
	}

	public void Show(Vector2 pos)
	{
		base.Show();
		effectActor.ReadEffect(new Effect(activatedCard.cardAsset.effecttype));
		Vector3 newposition=GameManager.instance.UICamera.ScreenToWorldPoint(new Vector3(pos.x,pos.y,GameManager.instance.UICamera.nearClipPlane));
		Vector3 offsetPosition=Vector3.Scale(new Vector3(30,10,0), new Vector3(1,1,0));
		newposition += offsetPosition;
		newposition.z = 0;
		this.transform.position = newposition;
		bool effectUsable=GameLogic.CanUseEffectInThisPhase(activatedCard.cardAsset.effecttype);
		buttonOk.gameObject.SetActive(effectUsable);


		LocalizedTextMeshPro locale = header.GetComponent<LocalizedTextMeshPro>();
		if (effectUsable)
		{
			locale.SetLocalizationKey("questionActivate");
			
		}
		else
		{
			locale.SetLocalizationKey( "effectNotUsable");
		}
		
		
		this.gameObject.SetActive(true);
	}
	
	public void ButtonOk()
	{
		
	}

	public void ButtonCancel()
	{
		Hide();
	}

	
}
