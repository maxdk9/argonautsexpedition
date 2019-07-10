using screen;
using UnityEngine;
using UnityEngine.Events;

namespace Model.States
{
    public class BattleEnd:iState
    {
        public static BattleEnd ourInstance=new BattleEnd();
        
        
        
        
        
        public void Execute(double time)
        {
            
        }

        public void OnEnter()
        {
            ScreenManager.instance.Show(ScreenManager.ScreenType.Rolldice);
            Visual.instance.mainDice.SetActive(false);
            Battle.ourInstance.SetCurrentDiceEncounterObject();
            ResultPanel.instance.ShowMessage(GameLogic.GetResultMessage());
            RollDiceResultBar.instance.Show();
        }

        private void ShowDetailedResult()
        {
            
        }

        private void ShowUIAfterDiceRolled()
        {
            
        }


        public void OnExit()
        {
            
        }
    }
}