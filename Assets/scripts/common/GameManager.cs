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
		Const.CalculateSize();
		CardManager.Instance().Init();
		ScreenManager.instance.Show(ScreenManager.ScreenType.Mainmenu);
	}

	public void SetCurrentState(GamePhase type)
	{
		Game.instance.CurrentState = type;
	}


	public void StartNewGame()
	{
		StopAllCoroutines();
		Command.ClearCommandQueue();
		DestroyOldCardObjects();
		
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
		StateComponent[] stateComponents =Resources.FindObjectsOfTypeAll<StateComponent>();

		
		
		
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
