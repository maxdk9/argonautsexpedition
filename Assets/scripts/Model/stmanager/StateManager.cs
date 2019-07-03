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
		dictionary.Add(GamePhase.Battle,Battle.ourInstance);		
		dictionary.Add(GamePhase.Lose,Lose.ourInstance);
		dictionary.Add(GamePhase.Win,Win.ourInstance);
		dictionary.Add(GamePhase.BattleView,BattleView.ourInstance);
		dictionary.Add(GamePhase.CrewAssignment,CrewAssignment.ourInstance);
		dictionary.Add(GamePhase.DeckWin,DeckWin.ourInstance);
		dictionary.Add(GamePhase.EndTurn,EndTurn.ourInstance);
		dictionary.Add(GamePhase.ResumeGame,ResumeGame.ourInstance);
		dictionary.Add(GamePhase.ScyllaEncounter,ScyllaEncounter.ourInstance);
		dictionary.Add(GamePhase.DrawWrathCards,DrawWrathCards.ourInstance);
		dictionary.Add(GamePhase.StartNewTurn,StartNewTurn.ourInstance);
		dictionary.Add(GamePhase.StartNewGame,StartNewGame.ourInstance);
		
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
				Debug.Log(e.Message);
			}
			Visual.instance.DisableVisualElementsOnStateEnter();
			GameManager.instance.SetCurrentState( type);
			GameLogicEvents.CopyGameActorsToCurrentGame();
			SaveLoadHelper.Save(SaveLoadHelper.defaultPrefixString);
			GameManager.instance.RemoveStateComponentsFromActor();
			Visual.instance.UpdateCrewCounter();
		}

		currentState = dictionary[type];

	
		currentState.OnEnter();

	}

	
}
