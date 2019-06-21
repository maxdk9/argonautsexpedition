using command;
using UnityEngine.Events;

namespace Model.States
{
    public class StartNewGame:iState
    {
        
        
        
        public static StartNewGame ourInstance=new StartNewGame();
        
        public void Execute(double time)
        {
            
        }

        private void PrepareCardsForNewGame()
        {
            new PrepareCardForNewGame().AddToQueue();
            new MoveCardsFromOutsideToDeck().AddToQueue();
            new GoToNextGamePhase(GamePhase.Draw3QuestCards).AddToQueue();
        }

        public void OnEnter()
        {
            PrepareCardsForNewGame();
        }

        public void OnExit()
        {
           
        }
    }
    
    
}