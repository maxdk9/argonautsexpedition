using System.Collections;
using System.Collections.Generic;
using Model;
using screen;
using tools;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null; // Экземпляр объекта
	public GameObject MonsterCardPrefab;
	public GameObject ItemCardPrefab;
	
	
	

	
	void Start () {
		if (instance == null) { 
			instance = this;  
		} else if(instance == this){ 
			Destroy(gameObject); 
		}
		DontDestroyOnLoad(gameObject);
		InitializeManager();
	}

	
	private void InitializeManager()
	{
		
		CardManager.Instance().Init();
		ScreenManager.instance.Show(ScreenManager.ScreenType.Mainmenu);
	}
}
