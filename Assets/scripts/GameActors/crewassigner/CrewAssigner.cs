using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CrewAssigner : MonoBehaviour
{
	public static CrewAssigner instance;
	
	public OneCardManager Target;

	public CrewItem[] CrewItems;


	private void Awake()
	{
	
	}


	// Use this for initialization
	void Start () {
		if (instance == null) { 
			instance = this;  
		} else if(instance == this){ 
			Destroy(gameObject); 
		}
		DontDestroyOnLoad(gameObject);
		instance.gameObject.SetActive(false);
	}
	
	
	
	void Update () {
		
	}

	public void Show(OneCardManager t)
	{
		
		Target = t;
		this.UpdateCrewItems();
		this.transform.position = t.gameObject.transform.position;
		this.transform.DOLocalMoveY(-300, 0);
		this.transform.DOScale(.5f, 0);
		this.gameObject.SetActive(true);
		this.transform.DOScale(1f, .5f);
	}

	private void UpdateCrewItems()
	{
		
	}
}
