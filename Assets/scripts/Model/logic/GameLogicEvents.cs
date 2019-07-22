using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class GameLogicEvents
    {

        public static UnityEvent eventUpdateCurrentEncounter=new UnityEvent();
        public static UnityEvent eventUpdateLossCounter=new UnityEvent();
        public static UnityEvent eventUpdateCrewCounter=new UnityEvent();

        

        public static void SubscribeEvents()
        {
            eventUpdateCurrentEncounter.RemoveAllListeners();
            eventUpdateCurrentEncounter.AddListener(new UnityAction(GameLogicEvents.UpdateCurrentEncounter));
            eventUpdateLossCounter.RemoveAllListeners();
            eventUpdateLossCounter.AddListener(new UnityAction(Visual.instance.UpdateLossCounter));
            eventUpdateCrewCounter.RemoveAllListeners();
            eventUpdateCrewCounter.AddListener(new UnityAction(Visual.instance.UpdateCrewCounter));
            
        }

        private static void UpdateCurrentEncounter()
        {
            foreach (CardManager.Card card in Game.instance.currentEncounter)
            {
                card.needToUpdate = true;
            }
        }


        public static void CopyGameActorsToCurrentGame()
        {
            if (Game.instance.CurrentState == GamePhase.ResumeGame)
            {
                return;
            }
            if (Game.instance.CurrentState == GamePhase.StartNewGame)
            {
                return;
            }

            AddToCardList(Visual.instance.CardPointDiscard, Game.instance.discardPile);
            AddToCardList(Visual.instance.CardPointWinning, Game.instance.winningPile);
            
            DestroyOneCardManager(Visual.instance.CardPointDiscard);
            DestroyOneCardManager(Visual.instance.CardPointWinning);
            
            UpdateCardList(Visual.instance.CurrentEncounter, Game.instance.currentEncounter);
            UpdateCardList(Visual.instance.CardDeckFrame, Game.instance.currentDeck);
            UpdateCardList(Visual.instance.TreasureHand,Game.instance.TreasureHand);
            
        }

        private static void AddToCardList(GameObject objectGroup, List<CardManager.Card> cardlist)
        {
            OneCardManager[] array = objectGroup.GetComponentsInChildren<OneCardManager>();
            foreach (OneCardManager cardManager in array)
            {
                if (cardManager.isPreview)
                {
                    continue;
                }
                cardlist.Add(cardManager.cardAsset);
            }
        }

        private static void DestroyOneCardManager(GameObject parent)
        {
            OneCardManager[] entities = parent.GetComponentsInChildren<OneCardManager>();
            foreach (OneCardManager entity in entities)
            {
                    GameObject.DestroyImmediate(entity.gameObject);   		
            }
        }
        

        private static void UpdateCardList(GameObject objectGroup, List<CardManager.Card> cardlist)
        {
            cardlist.Clear();
            OneCardManager[] array = objectGroup.GetComponentsInChildren<OneCardManager>();
            foreach (OneCardManager cardManager in array)
            {
                if (cardManager.isPreview)
                {
                    continue;
                }
                cardlist.Add(cardManager.cardAsset);
            }
        }


        public static int GetDeployedCrew()
        {
            OneCardManager[] cards = Visual.instance.CurrentEncounter.GetComponentsInChildren<OneCardManager>();
            int deployedCrew = 0;
            foreach (OneCardManager card in cards)
            {
                if (card.PreviewManager == null)
                {
                    continue;
                }
                deployedCrew += card.cardAsset.crewNumber;
            }
            return deployedCrew;
        }
        public static void DeployCrew()
        {
            int deployedCrew = GetDeployedCrew();
            Game.instance.DeployedCrew = deployedCrew;
            Visual.instance.UpdateCrewCounter();
        }

       
        
        
    }
}