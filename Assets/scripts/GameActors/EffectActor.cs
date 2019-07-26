using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class EffectActor : MonoBehaviour
{

	public  Effect effect;
	public Image image;
	public GameObject halo;
	public Transform root;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public static GameObject CreateNewEffectActor(Effect e)
	{
		
		GameObject effectActorObject=GameObject.Instantiate(GameManager.instance.EffectActorPrefab,Visual.instance.EffectGroup.transform);
		effectActorObject.GetComponent<EffectActor>().ReadEffect(e);
		
		return effectActorObject;
	}

	private void ReadEffect(Effect e)
	{
		this.effect = e;
		this.GetComponent<Tooltipable>().tooltipKey = "ttip_" + effect.Type.ToString();
		String path= "items/" + effect.Type.ToString();

		this.image.sprite = Resources.Load<Sprite>(path);
	}
	
	public void ShowHalo()
	{
		halo.SetActive(true);
		root.DOScale(.1f, 0);
		Sequence sequence = DOTween.Sequence();
		sequence.Append(root.DOScale(1, .5f));
		sequence.AppendInterval(2);
		
		sequence.OnComplete(() =>
		{
			HideHalo();
                           
		});




	}

	public void HideHalo()
	{
		Debug.Log("HideHalo");
			
		halo.SetActive(false);
	}
	
}
