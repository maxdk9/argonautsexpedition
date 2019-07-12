using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class GameLogicEvents
    {

        public static UnityEvent eventUpdateCurrentEncounter=new UnityEvent();
        public static UnityEvent eventUpdateLossCounter=new UnityEvent();

        

        public static void SubscribeEvents()
        {
            eventUpdateCurrentEncounter.RemoveAllListeners();
            eventUpdateCurrentEncounter.AddListener(new UnityAction(GameLogicEvents.UpdateCurrentEncounter));
            eventUpdateLossCounter.RemoveAllListeners();
            eventUpdateLossCounter.AddListener(new UnityAction(Visual.instance.UpdateLossCounter));
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
            
            
            UpdateCardList(Visual.instance.CurrentEncounter, Game.instance.currentEncounter);
            UpdateCardList(Visual.instance.CardDeckFrame, Game.instance.currentDeck);
            
        }

        private static void UpdateCardList(GameObject objectGroup, List<CardManager.Card> cardlist)
        {
            cardlist.Clear();
            OneCardManager[] array = objectGroup.GetComponentsInChildren<OneCardManager>();
            foreach (OneCardManager cardManager in array)
            {
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