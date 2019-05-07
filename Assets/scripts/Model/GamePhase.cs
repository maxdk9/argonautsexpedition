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
        ScyllaEncounter
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
        resolved_lost
    }
    
    
    public enum EffectType{
		Defeat_ColchianDragon_single ,
		WingedSandals_ReturnAdventureCard_single ,
		Cornucopia_Recover2Crew_single ,
		PansFlute_DiscardTop2Cards_single,
		OrpheusLyre_StopLevelUpMonsterInVictoryPile_single ,
		HelmOfHades_MoveMonsterToDiscardPile_single ,
		Ambrosia_Recover3Crew_single ,
		AegisOfZeus_IgnoreDeadliness_single ,
		ApolloBow_RollDice6_single ,
		CloakOfHeracles_monsterdifficulty_m1_cont ,
		PoseydonTrident_ConvertWrathToBlessing_cont ,
		Argo_TreasureRolls_p1_cont ,
		SwordOfPeleus_MonsterRolls_p1_cont ,
		DaedalusWing_RerollDieOncePerTurn_cont ,
		Ignore_Scylla ,
		Mirrored_Shield ,
		Ignore_Charybdis 
	}
    
}