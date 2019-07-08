using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{

	public Canvas panelCanvas;
	public TextMeshProUGUI label;

	public static ResultPanel instance;

	private void Awake()
	{
		instance = this;
		panelCanvas.gameObject.SetActive(false);
	}
	public void ShowMessage(string Message)
	{
		
		
		
		
		GameManager.instance.StartCoroutine(ShowMessageCoroutine(Message));
	}

	
	
	
	IEnumerator ShowMessageCoroutine(string Message)
	{
		label.text = Message;
		panelCanvas.gameObject.SetActive(true);
		panelCanvas.transform.DOScale(.2f, 0);
		panelCanvas.transform.DOScale(1, 1.5f);
		yield return new WaitForSeconds(.1f); 
	}
}
