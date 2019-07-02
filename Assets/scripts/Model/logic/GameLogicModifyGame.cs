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
    }
    
    
    
}