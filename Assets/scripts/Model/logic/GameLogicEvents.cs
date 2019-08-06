using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Model.States;
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
        public static myEvents.EffectEvent eventNewEffect=new myEvents.EffectEvent();
        public static UnityEvent eventRemoveSingleEffects=new UnityEvent();
        public static  UnityEvent eventAddSingleUsedTreausreTouchListener=new UnityEvent();
        public static myEvents.CardVisualEvent eventCardVisual =new myEvents.CardVisualEvent();
        
        
        
        
        


        public static void SubscribeEvents()
        {
            eventUpdateCurrentEncounter.RemoveAllListeners();
            eventUpdateCurrentEncounter.AddListener(GameLogicEvents.UpdateCurrentEncounter);
            eventUpdateLossCounter.RemoveAllListeners();
            eventUpdateLossCounter.AddListener(Visual.instance.UpdateLossCounter);
            eventUpdateCrewCounter.RemoveAllListeners();
            eventUpdateCrewCounter.AddListener(Visual.instance.UpdateCrewCounter);
            eventNewEffect.RemoveAllListeners();
            
            eventNewEffect.AddListener(raiseNewEffect);
            eventRemoveSingleEffects.RemoveAllListeners();
            
            eventRemoveSingleEffects.AddListener(removeSingleEffects);
            
            eventAddSingleUsedTreausreTouchListener.RemoveAllListeners();
            eventAddSingleUsedTreausreTouchListener.AddListener(AddSingleUsedTreasureTouchListener);
            
            
            eventCardVisual.RemoveAllListeners();
            eventCardVisual.AddListener(ShowCardVisualEvent);
            
            
            
        }

        private static void ShowCardVisualEvent(OneCardManager cardManager)
        {
            GameObject cardVisualEffectPrefab = GetCardVisualEffectPrefab(cardManager);
            GameObject cardVisualEffect = GameObject.Instantiate(cardVisualEffectPrefab, cardManager.transform);
        }

        private static GameObject GetCardVisualEffectPrefab(OneCardManager cardManager)
        {
            return Visual.instance.particleHeal;
        }

        private static void AddSingleUsedTreasureTouchListener()
        {
            ActivateSingleUsedTreasureTouchListener.AddComponentToCurrentHand();
        }

        private static void removeSingleEffects()
        {
            EffectActor[] listOfEffectActors = Visual.instance.EffectGroup.GetComponentsInChildren<EffectActor>();
            foreach (EffectActor effectActor in listOfEffectActors)
            {
                Effect.EffectType t = effectActor.effect.Type;
                if (Effect.contEffects.Contains(t))
                {
                    continue;
                }

                GameManager.instance.StartCoroutine(RemoveSingleEffectCoroutine(effectActor));



            }
        }

        private static IEnumerator RemoveSingleEffectCoroutine(EffectActor effectActor)
        {
            float duration = 1.5f;
            yield return new WaitForSeconds(.01f);
            Sequence sequence = DOTween.Sequence();
            effectActor.transform.parent = null;
            sequence.Append(effectActor.transform.DOScale(.1f, duration));
            sequence.Insert(0, effectActor.transform.DORotate(new Vector3(0,0,355), duration));
            sequence.Append(effectActor.transform.DOMove(Visual.instance.CardPointDiscard.transform.position, .01f));
            sequence.AppendCallback(() =>
            {
                effectActor.transform.SetParent(Visual.instance.CardPointDiscard.transform);
            });

        }


        private static void raiseNewEffect(Effect.EffectType effectType)
        {
            Effect effect=new Effect(effectType);
            EffectActor actor=EffectActor.CreateNewEffectActor(effect).GetComponent<EffectActor>();
            actor.ShowHalo();

            EffectEvents.DoEffect(effectType);


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