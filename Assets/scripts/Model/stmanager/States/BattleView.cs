using System.Collections.Generic;
using System.Linq;
using command;
using screen;
using tools;
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
            UpdateCurrentEncounterCMs();
            
            new MoveTreasureToHand().AddToQueue();
            
            ResolveCurrentEnemyEffect();
            new CustomActionCommand(new UnityAction(delegate { UpdateUIElements(); })).AddToQueue();            
            
        }

        private void ResolveCurrentEnemyEffect()
        {
            if (Game.instance.CurrentEnemyIndex == -1)
            {
                return;
            }
            CardManager.Card card=Visual.instance.GetCurrentEnemyCard();

            RaiseEnemyEffect(card);
        }

        private void RaiseEnemyEffect(CardManager.Card card)
        {
            if (card == null)
            {
                return;
            }

           
            if (card.resolved != ResolvedType.resolved_win)
            {
                return;
            }



            bool isActivatedMonsterEffect = Effect.monsterSingleUsedEffects.Contains(card.effecttype);
            if (isActivatedMonsterEffect)
            {
                GameLogicEvents.eventNewEffect.Invoke(card.effecttype);    
            }
        }

        

        private void UpdateUIElements()
        {
            AddResolveCardByRollDiceComponent();
            DeckGameControlPanel.instance.Show();
            
        }

        private void AddResolveCardByRollDiceComponent()
        {
            List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
            foreach (OneCardManager cm in enclist)
            {
                    cm.gameObject.AddComponent<ResolveCardByDiceRoll>();
            }
            
        }

        public void OnExit()
        {
            
        }
        
        
        private void UpdateCurrentEncounterCMs()
        {
            List<OneCardManager> encList = Visual.instance.GetCurrentEncounter();
            
            foreach (OneCardManager card in encList)
            {
                
                card.cardAsset.needToUpdate = true;
            }
        }
        
        
        private void AutoBattleResolve()
        {
            
            AutoResolveEvent.RemoveAllListeners();
            List<OneCardManager> currentEncoutnerList = Visual.instance.GetCurrentEncounter();
            
            
            foreach (OneCardManager cardManager in currentEncoutnerList)
            {

                if (cardManager.cardAsset.resolved != ResolvedType.notresolved)
                {
                    continue;
                }
                if (GameLogic.cardIsMonsterOrTreasure(cardManager.cardAsset))
                {
                    GameLogicModifyGame.AutoResolveCard(cardManager.cardAsset);
                    AutoResolveEvent.AddListener(cardManager.ShowResolve);
                    AutoResolveEvent.AddListener(cardManager.AnimateResolve);
                    AutoResolveEvent.AddListener(()=>RaiseEnemyEffect(cardManager.cardAsset));         
                }
            }
            AutoResolveEvent.Invoke();
        }
        
        
        

        private void MoveCardManagerToTreasure(OneCardManager cardManager)
        {
            
        }
    }
}