namespace Model.States
{
    public class ResumeGame:iState
    {
        public static ResumeGame ourInstance=new ResumeGame();
        
        public void Execute(double time)
        {
            
        }

        public void OnEnter()
        {
            new PrepareCardResumeGame().AddToQueue();
            
            new GoToNextGamePhase(Game.instance.CurrentState).AddToQueue();
        }

        public void OnExit()
        {
            
        }
    }
}