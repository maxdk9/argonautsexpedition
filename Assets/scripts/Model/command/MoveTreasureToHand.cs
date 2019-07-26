using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace command
{
    public class MoveTreasureToHand:Command
    {
        float TimeMovement1 = .6f;
        

       public override void StartCommandExecution()
        {
            GameManager.instance.StartCoroutine(MoveTreasureToHandCoroutine());
        }


        private IEnumerator MoveTreasureToHandCoroutine()
        {
            List<OneCardManager> trList = new List<OneCardManager>();


            List<OneCardManager> curEnc = Visual.instance.GetCurrentEncounter();
            foreach (OneCardManager cardManager in curEnc)
            {
                if((cardManager.cardAsset.type==CardType.treasure)&& (cardManager.cardAsset.resolved==ResolvedType.resolved_win))
                {
                    trList.Add(cardManager);
                }
            }

            if (trList.Count == 0)
            {
                yield return  new WaitForSeconds(.05f);
            }
            else
            {
                
                SameDistanceChildren distance = Visual.instance.TreasureHand.GetComponent<SameDistanceChildren>();
                int emptySlotIndex = distance.GetOccupiedSlotsNumber();
                
                foreach (OneCardManager cardManager in trList)
                {
                    cardManager.transform.SetParent(null);
                    Sequence sequence = DOTween.Sequence();
                    GameObject slot = distance.slots[emptySlotIndex];
                    emptySlotIndex++;
                    sequence.Append(cardManager.transform.DOMove(slot.transform.position, TimeMovement1));
                    sequence.OnComplete(() =>
                    {
                        MoveCardToCurrentEncounterGroup(cardManager, slot.transform);
                        
                        GameLogicEvents.eventNewEffect.Invoke(cardManager.cardAsset.effecttype);
                           
                    });
                    
                }
                yield return new WaitForSeconds(TimeMovement1 );
            }

            
            
            Command.CommandExecutionComplete();
        }

        public void MoveCardToCurrentEncounterGroup([CanBeNull] OneCardManager card, Transform parent)
        {
            card.transform.SetParent(parent);
        }
    }
}