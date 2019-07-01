using System.Collections.Generic;

namespace Model.States
{
    public class BattleView:iState
    {
        public static BattleView ourInstance=new BattleView();
        
        public void Execute(double time)
        {
            AutoBattleResolve();
            UpdateOneCardManagerVisibility();

        }

        

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }
        
        
        private void AutoBattleResolve()
        {
            List<OneCardManager> currentEncoutnerList = Visual.GetCurrentEncounter();
            foreach (OneCardManager cardManager in currentEncoutnerList)
            {
                if (GameLogic.cardIsMonsterOrTreasure(cardManager.cardAsset))
                {
                    int difficulty = GameLogic.GetCurrentDifficulty(cardManager.cardAsset);
                    int diceresult = GameLogic.GetModifiedDiceResult(cardManager.cardAsset,1);

                }
            }
        }
    }
}