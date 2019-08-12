namespace Model
{
    public enum GamePhase
    {
        StartNewTurn, 
        Draw3QuestCards,
        DrawWrathCards,
        CrewAssignment,
        Win,
        Lose, 
        BattleView,
        Battle,
        EndTurn,
        DeckWin, 
        ScyllaEncounter,
	    ResumeGame,
	    StartNewGame,
        BattleEnd
    }
    
    public enum CardType{
        monster,
        treasure,
        blessing,
        wrath,
		
    }
	
    public enum UseType{
        single,
        continuous
    }
	
    public enum ResolvedType{
        notresolved,
        resolved_win,
        resolved_lost,
        
    }
    
    
    
    
}