﻿using System.Collections;
using System.Collections.Generic;
using GameActors;
using Model;
using screen;
using tools;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null; // Экземпляр объекта
	
	public GameObject MonsterCardPrefab;
	public GameObject ItemCardPrefab;
	public GameObject BlessingCardPrefab;
	public GameObject DamageEffectPrefab;
	
	

	
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

	public void SetCurrentState(GamePhase type)
	{
		Game.instance.CurrentState = type;
	}


	public void StartNewGame()
	{
		DestroyOldCardObjects();
		Game.instance.StartNewGame();
		StateManager.getInstance().MoveNext(GamePhase.StartNewGame);

	}

	private void DestroyOldCardObjects()
	{
		DestroyableEntity[] entities = ScreenManager.instance.DeckgameCanvas.GetComponentsInChildren<DestroyableEntity>();

		foreach (DestroyableEntity entity in entities)
		{
			//entity.Kill();
			GameObject.Destroy(entity.gameObject);
			
		}
		
	}


	public void RemoveStateComponentsFromActor()
	{
		StateComponent[] stateComponents = ScreenManager.instance.DeckgameCanvas.GetComponentsInChildren<StateComponent>();
		foreach (StateComponent sc in stateComponents)
		{
			GameObject.Destroy(sc);
		}
	}


	private void Update()
	{
		StateManager.getInstance().Update(1);
	}
}
