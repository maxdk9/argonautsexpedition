using System;

namespace Model
{
    public class GameLogicModifyGame
    {
        
        public static void AutoResolveCard(CardManager.Card card)
        {

            if (card.resolved != ResolvedType.notresolved)
            {
                return;
            }
            int difficulty = GameLogic.GetCurrentDifficulty(card);
            int diceresult = card.crewNumber+GameLogic.GetModifiedDiceResult(card,1);
            if (diceresult >= difficulty)
            {
                card.resolved = ResolvedType.resolved_win;
            }

            if (card.crewNumber == 0)
            {
                card.resolved = ResolvedType.resolved_lost;
                UpdateCasualties(card);
            }
            
        }

        private static void UpdateCasualties(CardManager.Card card)
        {
            if (card.resolved == ResolvedType.resolved_lost)
            {
                Game.instance.Casualties += GameLogic.GetDeadliness(card);
            }
        }


        public static void CalculateDiceRollResult()
        {
            Game.instance.DiceEncounterNumber =
                Visual.instance.mainDice.GetComponentInParent<DisplayCurrentDiceValue>().Value;
            
        }

        public static void ResolveDiceEncounter()
        {
            
            CardManager.Card card = Visual.instance.GetCurrentEnemyCard();
            bool win = GameLogic.CurrentChallengeWin();
            if (win)
            {
                card.resolved = ResolvedType.resolved_win;
            }
            else
            {
                card.resolved = ResolvedType.resolved_lost;
                UpdateCasualties(card);
            }
        }

        public static void DoCasualties()
        {
            Game.instance.DeployedCrew = 0;
            Game.instance.CrewNumber = Game.instance.CrewNumber - Game.instance.Casualties;
            Game.instance.Casualties = 0;
        }


        public static void ResetParametersOnStartNewTurn()
        {
            Game.instance.DeployedCrew = 0;
            Game.instance.Casualties = 0;
        }

        public static void RestoreCrew(Effect.EffectType effectType)
        {
            int treasureCrewValue = 0;
            if (effectType == Effect.EffectType.Ambrosia_Recover3Crew_single)
            {
                treasureCrewValue = 3;
            }

            if (effectType == Effect.EffectType.Cornucopia_Recover2Crew_single)
            {
                treasureCrewValue = 2;
            }


            int newCrewValue = Game.instance.CrewNumber + treasureCrewValue;
            newCrewValue = Math.Min(newCrewValue, GameLogic.GetCrewStartingCount());
            Game.instance.CrewNumber = newCrewValue;
        }
    }
    
    
    
}