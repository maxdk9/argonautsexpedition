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
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null; // Экземпляр объекта
	private Game currentGame;
	
	
	public GameObject MonsterCardPrefab;
	public GameObject ItemCardPrefab;
	public GameObject BlessingCardPrefab;
	public GameObject DamageEffectPrefab;
	public GameObject EffectActorPrefab;
	public Camera MainCamera;
	public Camera UICamera;
	public List<GameObject> listToDestroy;
	 


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
		EffectActor[] actors = Visual.instance.EffectGroup.GetComponentsInChildren<EffectActor>();
		foreach (EffectActor entity in actors)
		{
			
			
				GameObject.DestroyImmediate(entity.gameObject);
					
		}
	}
	
	
	


	public void RemoveStateComponentsFromActor()
	{
		tempTouchComponent[] tempTouchComponents =Resources.FindObjectsOfTypeAll<tempTouchComponent>();

		
		
		
		foreach (tempTouchComponent sc in tempTouchComponents)
		{
			GameObject.Destroy(sc);
		}

		foreach (GameObject ob in GameManager.instance.listToDestroy)
		{
			GameObject.Destroy(ob);
		}
		

	}


	private void Update()
	{
		StateManager.getInstance().Update(1);
	}




	public void RemoveTouchComponentsExceptSelf(OneCardManager target, tempTouchComponent exceptionComponent)
	{
		tempTouchComponent[] arrTouchcomponent = target.GetComponents<tempTouchComponent>();
		foreach (var VARIABLE in arrTouchcomponent)
		{
			if (VARIABLE == exceptionComponent)
			{
				continue;
			}
			GameObject.DestroyImmediate(VARIABLE);
		}
		
	}
}
