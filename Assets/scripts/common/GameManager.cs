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
		Const.CalculateSize();
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
		DestroyableEntity[] entities = ScreenManager.instance.DeckgameCanvas.GetComponentsInChildren<DestroyableEntity>();

		foreach (DestroyableEntity entity in entities)
		{
			//entity.Kill();
			GameObject.Destroy(entity.gameObject);
			
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
