using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class ResultPanel : MonoBehaviour
{

	public Canvas panelCanvas;
	public TextMeshProUGUI label;
	public Image backgroundImage;

	private int hiddenY = 400;
	private int showY = 220;
	
	public static ResultPanel instance;

	private void Awake()
	{
		instance = this;
		this.backgroundImage.transform.DOLocalMoveY(hiddenY, 0);
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
		Sequence sequence= DOTween.Sequence();
		sequence.Append(backgroundImage.transform.DOLocalMoveY(220, .3f));
		sequence.Play();
		
		
		yield return new WaitForSeconds(1.1f); 
	}
}
