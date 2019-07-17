using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class ResultPanel : MonoBehaviour
{

	
	public TextMeshProUGUI label;
	public Image backgroundImage;

	private float defaultY=190;
	private float viewMoveDuration = .2f;
	
	public static ResultPanel instance;

	private void Awake()
	{
		
		Debug.Log("ResultImageY "+defaultY.ToString());
		instance = this;
		Hide();
		
		
	}


	

	public void ShowMessage(string Message)
	{
		this.gameObject.SetActive(true);
		GameManager.instance.StartCoroutine(ShowMessageCoroutine(Message));
	}

	
	
	
	IEnumerator ShowMessageCoroutine(string Message)
	{
		label.text = Message;
		yield return new WaitForSeconds(.1f);
		Sequence sequence= DOTween.Sequence();
		sequence.Append(this.transform.DOLocalMoveY(defaultY, viewMoveDuration));
		sequence.Play();
		yield return new WaitForSeconds(viewMoveDuration+.01f); 
	}

	public void Hide()
	{
		this.transform.DOLocalMoveY(defaultY+200, 0);
		this.gameObject.SetActive(false);
	}
	
}
