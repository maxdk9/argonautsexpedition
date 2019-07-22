using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class EffectActor : MonoBehaviour
{

	private Effect effect;
	public Image image;
	
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
}
