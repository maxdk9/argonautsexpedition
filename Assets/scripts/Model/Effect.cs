using System.Linq;

namespace Model
{
	[System.Serializable]
    public class Effect
	{
		public Effect(EffectType t)
		{
			type = t;
		}
		
		
		private EffectType[] singleUsedEffects =
		{
			EffectType.Defeat_ColchianDragon_single,
			EffectType.WingedSandals_ReturnAdventureCard_single,
			EffectType.Cornucopia_Recover2Crew_single,
			EffectType.PansFlute_DiscardTop2Cards_single,
			EffectType.OrpheusLyre_StopLevelUpMonsterInVictoryPile_single,
			EffectType.HelmOfHades_MoveMonsterToDiscardPile_single,
			EffectType.Ambrosia_Recover3Crew_single,
			EffectType.AegisOfZeus_IgnoreDeadliness_single,
			EffectType.ApolloBow_RollDice6_single,
			
		};
	    
		private EffectType[] contEffects =
		{
			EffectType.CloakOfHeracles_monsterdifficulty_m1_cont,
			EffectType.Argo_TreasureRolls_p1_cont,
			EffectType.SwordOfPeleus_MonsterRolls_p1_cont,
			EffectType.PoseydonTrident_ConvertWrathToBlessing_cont,
			EffectType.DaedalusWing_RerollDieOncePerTurn_cont,
			EffectType.Mirrored_Shield,
			EffectType.Golden_Fleece
			
		};
	    
        public enum EffectType{
		Defeat_ColchianDragon_single ,
		WingedSandals_ReturnAdventureCard_single ,
		Cornucopia_Recover2Crew_single ,
		PansFlute_DiscardTop2Cards_single ,
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
		Ignore_Charybdis,
	    Golden_Fleece,
	    empty
	}

	    private EffectType type;


	    public EffectType Type
	    {
		    get { return type; }
		    set { type = value; }
	    }

		public bool IsSingleUsed()
		{
			return  singleUsedEffects.Contains(this.type);
		}
	    
		public bool IsCont()
		{
			return  contEffects.Contains(this.type);
		}
		
    }
}