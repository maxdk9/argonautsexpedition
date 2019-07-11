using System.Collections.Generic;
using screen;
using UnityEngine.Events;

namespace Model.States
{
    public class BattleView:iState
    {
        public static BattleView ourInstance=new BattleView();
        
        private UnityEvent AutoResolveEvent=new UnityEvent();
        
        
        public void Execute(double time)
        {
        }

        


        public void OnEnter()
        {
            
            ScreenManager.instance.Show(ScreenManager.ScreenType.Deckgame);
            HoverPreview.StopAllPreviews();
            AutoBattleResolve();
            UpdateOneCardManagerVisibility();
            AddResolveCardByRollDiceComponent();
            DeckGameControlPanel.instance.Show();
            
        }

        private void AddResolveCardByRollDiceComponent()
        {
            List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
            foreach (OneCardManager cm in enclist)
            {
                if (cm.cardAsset.resolved == ResolvedType.resolved_lost |
                    cm.cardAsset.resolved == ResolvedType.resolved_win)
                {
                    continue;
                }

                cm.gameObject.AddComponent<ResolveCardByDiceRoll>();


            }
            
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
            
            AutoResolveEvent.RemoveAllListeners();
            List<OneCardManager> currentEncoutnerList = Visual.instance.GetCurrentEncounter();
            
            
            foreach (OneCardManager cardManager in currentEncoutnerList)
            {
                if (GameLogic.cardIsMonsterOrTreasure(cardManager.cardAsset))
                {
                    GameLogicModifyGame.AutoResolveCard(cardManager.cardAsset);
                    AutoResolveEvent.AddListener(cardManager.ShowResolve);
                    AutoResolveEvent.AddListener(cardManager.AnimateResolve);
                }
            }
            AutoResolveEvent.Invoke();
        }
        
        
        
        
        
        
        
        
        
        
        
        
    }
}