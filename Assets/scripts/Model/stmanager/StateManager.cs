using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using Model.States;
using UnityEngine;

public class StateManager
{

	private static StateManager instance;

	private iState currentState;
	private IDictionary<GamePhase,iState> dictionary;
	

	public static StateManager getInstance()
	{
		if (instance == null)
		{
			instance=new StateManager();
			instance.init();
		}

		return instance;
	}
	
	
	
	

	private void init()
	{
		dictionary=new Dictionary<GamePhase, iState>();
		dictionary.Add(GamePhase.Draw3QuestCards,Draw3QuestCard.ourInstance);
		
		
		
	}


	public void Update(double time)
	{
		if (currentState == null)
		{
			return;
		}
		
		currentState.Execute(time);
	}


	public void MoveNext(GamePhase type)
	{

		if (currentState != null)
		{
			
			
			Debug.Log("MoveNext first state "+currentState.ToString());
            
			currentState.OnExit();
		}

		if (type != GamePhase.ResumeGame)
		{
			try
			{
				String commentary = "State manager go to the state " + type.ToString();

				
			}
			catch (Exception e)
			{
				
			}
			GameLogicEvents.CopyGameActorsToCurrentGame();
			
			GameManager.instance.SetCurrentState( type);
			SaveLoadHelper.Save(SaveLoadHelper.defaultPrefixString);
			GameManager.instance.RemoveStateComponentsFromActor();
		}

		currentState = dictionary[type];

	
		currentState.OnEnter();

	}

	
}
