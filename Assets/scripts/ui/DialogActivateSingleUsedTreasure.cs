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
		Vector2 pos = activatedCard.transform.position;
		Vector3 newposition=GameManager.instance.UICamera.ScreenToWorldPoint(new Vector3(pos.x,pos.y,GameManager.instance.UICamera.nearClipPlane));
		Vector3 offsetPosition=Vector3.Scale(new Vector3(30,10,0), new Vector3(1,1,0));
		newposition += offsetPosition;
		//Vector3 newposition1 = GameManager.instance.UICamera.WorldToScreenPoint(newposition);
		
		this.transform.position = newposition;
		this.gameObject.SetActive(true);
		
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
