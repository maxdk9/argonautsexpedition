namespace Model.States
{
    public class StartNewTurn:iState
    {
        public static StartNewTurn ourInstance=new StartNewTurn();
        
        public void Execute(double time)
        {
            
        }

        public void OnEnter()
        {
            if (GameLogic.EndDeck())
            {
                new GoToNextGamePhase(GamePhase.DeckWin);
                
            }
            else
            {
                new GoToNextGamePhase(GamePhase.Draw3QuestCards).AddToQueue();
            }
        }

        public void OnExit()
        {
            
        }
    }
}