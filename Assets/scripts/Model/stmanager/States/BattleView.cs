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
        
        
        private void UpdateOneCardManagerVisibility()
        {
            List<OneCardManager> encList = Visual.instance.GetCurrentEncounter();
            foreach (OneCardManager card in encList)
            {
                card.SetVisibility();
            }
        }
        
        
        private void AutoBattleResolve()
        {
            List<OneCardManager> currentEncoutnerList = Visual.instance.GetCurrentEncounter();
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