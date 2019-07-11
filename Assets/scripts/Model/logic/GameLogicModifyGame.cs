using System;

namespace Model
{
    public class GameLogicModifyGame
    {
        
        public static void AutoResolveCard(CardManager.Card card)
        {
            int difficulty = GameLogic.GetCurrentDifficulty(card);
            int diceresult = card.crewNumber+GameLogic.GetModifiedDiceResult(card,1);
            if (diceresult >= difficulty)
            {
                card.resolved = ResolvedType.resolved_win;
            }

            if (card.crewNumber == 0)
            {
                card.resolved = ResolvedType.resolved_lost;
            }
        }


        public static void CalculateDiceRollResult()
        {
            Game.instance.DiceEncounterNumber =
                Visual.instance.mainDice.GetComponentInParent<DisplayCurrentDiceValue>().Value;
            
        }

        public static void ResolveDiceEncounter()
        {
            bool isResolved = GameLogic.CurrentChallengeWin();
            CardManager.Card card = Visual.instance.GetCardByNumberFromCurrentEncounter();
            
            if (isResolved)
            {
                card.resolved = ResolvedType.resolved_win;
            }
            else
            {
                card.resolved = ResolvedType.resolved_lost;
            }
        }
    }
    
    
    
}