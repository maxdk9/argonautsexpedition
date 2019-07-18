using System;
using System.Collections;
using System.Collections.Generic;
using common;
using GameActors;
using Model;
using screen;
using tools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null; // Экземпляр объекта
	private Game currentGame;
	
	
	public GameObject MonsterCardPrefab;
	public GameObject ItemCardPrefab;
	public GameObject BlessingCardPrefab;
	public GameObject DamageEffectPrefab;
	public Camera MainCamera;
	public Camera UICamera;
	

	
	void Start () {
		if (instance == null) { 
			instance = this; 
			currentGame=new Game();
		} else if(instance == this){ 
			Destroy(gameObject); 
		}
		DontDestroyOnLoad(gameObject);
		InitializeManager();
	}

	
	private void InitializeManager()
	{

		MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		UICamera = GameObject.Find("UIcamera").GetComponent<Camera>();
		Const.CalculateSize();
		GameLogicEvents.SubscribeEvents();
		CardManager.Instance().Init();
		ScreenManager.instance.Show(ScreenManager.ScreenType.Mainmenu);
	}

	public void SetCurrentState(GamePhase type)
	{
		Game.instance.CurrentState = type;
	}


	public void DestroyOldObjects()
	{
		StopAllCoroutines();
		Command.ClearCommandQueue();
		DestroyOldCardObjects();
	}

	public void StartNewGame()
	{
		
		DestroyOldObjects();
		Game.instance.StartNewGame();

		new GoToNextGamePhase(GamePhase.StartNewGame).AddToQueue();

	}

	private void DestroyOldCardObjects()
	{
		OneCardManager[] entities = Resources.FindObjectsOfTypeAll<OneCardManager>();
		foreach (OneCardManager entity in entities)
		{
			if (entity.gameObject.tag.Equals("prefab"))
			{
				continue;
			}
			else
			{
				GameObject.DestroyImmediate(entity.gameObject);
			}		
		}
	}


	public void RemoveStateComponentsFromActor()
	{
		tempTouchComponent[] tempTouchComponents =Resources.FindObjectsOfTypeAll<tempTouchComponent>();

		
		
		
		foreach (tempTouchComponent sc in tempTouchComponents)
		{
			GameObject.Destroy(sc);
		}
	}


	private void Update()
	{
		StateManager.getInstance().Update(1);
	}
}
