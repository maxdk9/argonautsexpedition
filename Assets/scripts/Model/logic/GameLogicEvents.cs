using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Model
{
    public class GameLogicEvents
    {

        public static UnityEvent eventUpdateCurrentEncounter=new UnityEvent();
        public static UnityEvent eventUpdateLossCounter=new UnityEvent();
        public static UnityEvent eventUpdateCrewCounter=new UnityEvent();
        public static myEvents.EffectEvent<Effect.EffectType> eventNewEffect =new myEvents.EffectEvent<Effect.EffectType>();

        

        public static void SubscribeEvents()
        {
            eventUpdateCurrentEncounter.RemoveAllListeners();
            eventUpdateCurrentEncounter.AddListener(GameLogicEvents.UpdateCurrentEncounter);
            eventUpdateLossCounter.RemoveAllListeners();
            eventUpdateLossCounter.AddListener(Visual.instance.UpdateLossCounter);
            eventUpdateCrewCounter.RemoveAllListeners();
            eventUpdateCrewCounter.AddListener(Visual.instance.UpdateCrewCounter);
            eventNewEffect.RemoveAllListeners();
            
            
            eventNewEffect.AddListener((int n) =>
            {
                if (n <= 0) throw new ArgumentOutOfRangeException("n");
                raiseNewEffect(n);
            });
            
        }
         static  void raiseNewEffect(int n)
        {
            Debug.Log(n.ToString());
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