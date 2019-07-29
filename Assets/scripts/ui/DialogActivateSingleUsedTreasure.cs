using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogActivateSingleUsedTreasure : MonoBehaviour
{

	public static DialogActivateSingleUsedTreasure instance;
	public TextMeshProUGUI header;
	public Button buttonOk;
	public Button buttonCancel;
	public GameObject EffectActorObject;
	public OneCardManager activatedCard;
	


	private void Awake()
	{
		instance = this;
		Hide();
	}

	public void Hide()
	{
		this.gameObject.SetActive(false);
	}

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	
	
	
	
	public void ButtonOk()
	{
		
	}

	public void ButtonCancel()
	{
		
	}
	
}
