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

            ResetGameParameters();
            if (GameLogic.EndDeck())
            {
                new GoToNextGamePhase(GamePhase.DeckWin);
                
            }
            else
            {
                new GoToNextGamePhase(GamePhase.Draw3QuestCards).AddToQueue();
            }
        }

        private void ResetGameParameters()
        {
            Game.instance.CurrentEnemyIndex = -1;
        }

        public void OnExit()
        {
            
        }
    }
}